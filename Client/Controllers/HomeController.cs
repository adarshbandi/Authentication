﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var serverResponse = await _client.GetAsync("https://localhost:44391/secret/index");

            var apiResponse = await _client.GetAsync("https://localhost:44362/secret/index");


            return View();
        }
    }
}