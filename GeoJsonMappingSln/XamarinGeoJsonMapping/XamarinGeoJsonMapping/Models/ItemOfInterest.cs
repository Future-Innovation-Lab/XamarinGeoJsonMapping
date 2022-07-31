using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace XamarinGeoJsonMapping.Models
{
    public class ItemOfInterest
    {
        
        public string InterestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public Position Position { get; set; }
    }
}
