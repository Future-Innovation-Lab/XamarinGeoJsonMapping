using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;
using XamarinGeoJsonMapping.Models;

namespace XamarinGeoJsonMapping.Services
{

    
    public class PositioningService
    {
        private List<ItemOfInterest> _itemsOfInterest;
        public PositioningService()
        {
            GenerateMockData();
        }

        private void GenerateMockData()
        {
            _itemsOfInterest = new List<ItemOfInterest>();

            var itemOfInterest = new ItemOfInterest();

            itemOfInterest.Name = "Place 1";
            itemOfInterest.Position = new Position(-33.933329, 18.6333308);
            _itemsOfInterest.Add(itemOfInterest);

            itemOfInterest = new ItemOfInterest();
            itemOfInterest.Name = "Place 2";
            itemOfInterest.Position = new Position(-33.931, 18.6331);
            _itemsOfInterest.Add(itemOfInterest);

            itemOfInterest = new ItemOfInterest();
            itemOfInterest.Name = "Place 3";
            itemOfInterest.Position = new Position(-33.932322, 18.632);
            _itemsOfInterest.Add(itemOfInterest);

            itemOfInterest = new ItemOfInterest();
            itemOfInterest.Name = "Place 4";
            itemOfInterest.Position = new Position(-33.934, 18.6300);
            _itemsOfInterest.Add(itemOfInterest);


        }

        public List<ItemOfInterest> GetPointsOfInterest()
        {
            return _itemsOfInterest;
        }

        public Position GetCurrentPosition()
        {
            var pos = new Position(-33.933329, 18.6300);


            return pos;

        }
    }
}
