﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace theApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriverHomePage : ContentPage
    {
        public DriverHomePage()
        {
            InitializeComponent();
        }

        private void ClickGestureRecognizer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SignalArrivalPage());
        }
    }
}