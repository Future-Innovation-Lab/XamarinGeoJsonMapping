using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using XamarinGeoJsonMapping.Models;

namespace XamarinGeoJsonMapping.Services
{
    public class GeoJsonFencingService
    {

        public GeoJsonFencingService()
        {
        }

        
        public GeoFence GetFencePosition()
        {
            // could be a database this is an embedded resource example


            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(GeoFence)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("XamarinGeoJsonMapping.Geostore.geofence.json");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();

                var geoFence = JsonConvert.DeserializeObject<GeoFence>(text);

                return geoFence;
            }
        }
        
    }
}
