﻿using BankingXamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinGeoJsonMapping.Models;
using XamarinGeoJsonMapping.Services;

namespace XamarinGeoJsonMapping.ViewModel
{
    public class MapGeoJsonViewModel : BaseViewModel
    {
        private ObservableCollection<ItemOfInterest> _locations;
        private PositioningService _positioningService;
        private GeoJsonFencingService _geoJsonFencingService;

        private List<Position> _mapGeoFence;

        public List<Position> MapGeoFence
        {
            get { return _mapGeoFence; }
            set { _mapGeoFence = value; }
        }



        private MapSpan _mapCenter;

        public MapSpan MapCenter
        {
            get { return _mapCenter; }
            set
            {
                _mapCenter = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<ItemOfInterest> Locations
        {
            get { return _locations; }
            set {
                _locations = value;
                OnPropertyChanged();
            }
        }


        public MapGeoJsonViewModel(INavigation navigation) : base(navigation)
        {
            _positioningService = new PositioningService();
            _geoJsonFencingService = new GeoJsonFencingService();

            CreateMapPins();
           CenterOnMapPosition();

            FetchGeoFence();
        }


        private void CreateMapPins()
        {
          

            var points = _positioningService.GetPointsOfInterest();

            Locations = new ObservableCollection<ItemOfInterest>(points);



        }

        private void CenterOnMapPosition()
        {
           var pos = _positioningService.GetCurrentPosition();

            MapCenter = MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromMiles(0.5));
        }
        
        private void FetchGeoFence()
        {
            
            var geoJsonFence = _geoJsonFencingService.GetFencePosition();
            var polypoints = geoJsonFence.features[0].geometry.coordinates[0];

            _mapGeoFence = new List<Position>();

            foreach(var polyPoint in polypoints)
            {
                var position = new Position(polyPoint[1], polyPoint[0]);
                _mapGeoFence.Add(position);
            }
        }

        
    }
}
