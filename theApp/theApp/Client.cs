using System;
using System.Collections.Generic;
using System.Text;

namespace theApp
{
    public static class Client
    {
        //this id is temporaray and should be removed
      // public  static string theID =        "1199861119159";
        public static string ClientID       { get; set; }
        public static string FirsName        { get; set; }
        public static string Surname        { get; set; }
        public static string DOB            { get; set; }
        public static string Gender         { get; set; }
        public static string StreetAddress { get; set; }
        public static string City           { get; set; }
        public static string Province        { get; set; }
        public static int    ZipCode                { get; set; }
        public static string Email                   { get; set; }
        public static string Password           { get; set; }

        //swith to determine which sceen to go too after requesting a job request
        public static bool isDriving = false;
       
    }
}
