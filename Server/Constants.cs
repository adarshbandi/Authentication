using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public static class Constants
    {
        public static string Audience = "https://localhost:44391/";
        public static string Issuer = Audience;
        public static string Secret = "not_too_short_secret_otherwise_its_easy_to_crackdown";
    }
}
