using System;

namespace RedditImplementation
{
    public static class RedditUtil
    {
        public const string APP_ID = "8kbLRkI0rg-o-g";

        public const string SECRET = "6csGon_lDDaiVTY6e3_r3U7h4mLepA";

        // public const string ACCESS_TOKEN = "1003082969318-2rjo-s5iJpHhvQ0hmrt9gB70M0tSgg";

        public const string REDI_URL = "https://localhost:44310/Reddit/GetToken";

        public static string code { set; get; }
        public static string state { set; get; }

        public static string ACCESS_TOKEN  { set; get; }
        public static string REFRESH_TOKEN  { set; get; }
    }
}
