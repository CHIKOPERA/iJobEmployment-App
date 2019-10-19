using System;
using System.Collections.Generic;
using System.Text;

namespace theApp
{
   public  class ClientObject
    {
   
        public string ClientID      { get; set ;  }
        public string FirsName      { get; set; }
        public string Surname       { get; set; }
        public string DOB            { get; set; }
        public string Gender        { get; set; }
        public string StreetAddress { get; set; }
        public string City           { get; set; }
        public string Province      { get; set; }
        public int      ZipCode     { get; set; }
        public string Email          { get; set; }
        public string Password       { get; set; }

        public ClientObject()
        {// constructor to fill in the client instance iwth the client's information
            //ClientID     = Client.ClientID ;
            //FirsName     =Client.FirsName ;
            //Surname      =Client.Surname ;
            //DOB          =Client.DOB ;
            //Gender       =Client.Gender ;
            //StreetAddress=Client.StreetAddress ;
            //City         =Client.City;
            //Province     =Client.Province ;
            //ZipCode    =Client.ZipCode ;
            //Email        =Client.Email;
            //Password     =Client.Password ;
        }
    }
}
