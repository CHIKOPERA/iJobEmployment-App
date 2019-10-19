using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace theApp
{
    public class CustomMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}
