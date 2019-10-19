using System;
using System.Collections.Generic;
using System.Text;

namespace theApp
{
    /// <summary>
    /// This class is only used for recieving jason objects from the web API
    /// it should not be confused with the other JobRequest class that deals with client
    /// Job request
    /// </summary>
    public class JobRequests
    {
        public string ClientID { get; set; }
        public string Date { get; set; }
        public string TimeStart { get; set; }
        public string TimeEnd { get; set; }
        public string Category { get; set; }
        public int NumOfLabs { get; set; }
        public string JobSpec { get; set; }
        public string Location { get; set; }
        public bool TranspotStatus { get; set; }
        public bool IsAssigned { get; set; }
        public decimal Cost { get; set; }
    }
}
