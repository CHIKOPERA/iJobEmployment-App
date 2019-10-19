using System;
using System.Collections.Generic;
using System.Text;

namespace theApp
{  
        public class JobRequest
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
        //When the ctr runs, the static index in the JOBREQUESTREPORT class is
        // incremented and then the value is set to the property below ,
        //this will be used to determine the report to open based o inded
        //. 
            public int Index { get; set; }


        //Remove the ctr
        public JobRequest()
        {
            //ID of the registered client
        
            JobRequestReport.index++;

        }
        }
    
}
