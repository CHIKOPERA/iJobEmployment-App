using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace theApp
{
    public partial class App : Application
    {
        public static int ScreenHeight { get; set; }
        public static int ScreenWidth { get; set; }
        public static string Login = "Client";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            var ReportList = JsonConvert.SerializeObject(JobRequestReport.jobRequestList);
            Application.Current.Properties["reportList"] = ReportList;
        }

        protected override void OnResume()
        {
            try
            {
                string value = Application.Current.Properties["reportList"].ToString(); ;
                JobRequestReport.jobRequestList = JsonConvert.DeserializeObject<List<JobRequest>>(value);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
