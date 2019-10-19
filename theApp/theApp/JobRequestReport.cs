using System;
using System.Collections.Generic;
using System.Text;

namespace theApp
{
   public static class JobRequestReport
    {//for saving the current request that is in progess
        public static string ClientID { get; set; }
        public static string Date { get; set; }
        public static string TimeStart { get; set; }
        public static string TimeEnd { get; set; }
        public static string Category { get; set; }
        public static int NumOfLabs { get; set; }
        public static string JobSpec { get; set; }
        public static string Location { get; set; }
        public static bool TranspotStatus { get; set; }
        public static bool IsAssigned { get; set; }
        public static decimal Cost { get { return Cost; } set { Cost = 0; } }
        public static List<string> Labourers = new List<string>() { "Steve Johns", "David Sanders", "Frank Galiger" };

       //used to set the style id of the button
        public static int index = 0;

        //variable that will be use to load
        //the selected report based on index;
        public static int selectedndex = 0;
        //List of all job requests
        public static List<JobRequest> jobRequestList = new List<JobRequest>();       
        #region .
        public static string[] Labs = { "Takudzwa Steve", "Edward Ncube", "Sam Calid", "Cader Smith", "Zolisanani Phiri", "Eddie Hara", "Tom Harry", "John Makulela", "Mary Longford", "Steve Johns" };
        public static string[] Agents = { "Tanyaradzwa Chikopera", "Sonwabo Funde", "Vuyokazi Mbekela", "Thandokazi Dakuse" };

        #endregion


    }
}
