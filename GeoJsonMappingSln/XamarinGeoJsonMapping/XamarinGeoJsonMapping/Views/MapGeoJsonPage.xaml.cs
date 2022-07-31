using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using XamarinGeoJsonMapping.ViewModel;

namespace XamarinGeoJsonMapping.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapGeoJsonPage : ContentPage
    {
        public MapGeoJsonPage()
        {
            InitializeComponent();

            var vm = new MapGeoJsonViewModel(Navigation);

            BindingContext = vm;

            CreateFence();

            Map.MoveToRegion(vm.MapCenter);
                       

        }

        private void CreateFence()
        {
            var vm = BindingContext as MapGeoJsonViewModel;

            if (vm != null)
            {

                var polygon = new Polygon();

                polygon.FillColor = Color.Red;
                polygon.StrokeColor = Color.Black;
                polygon.StrokeWidth = 2;

                if (vm.MapGeoFence != null)
                {
                    List<Position> positions = vm.MapGeoFence;

                    foreach (var position in positions)
                        polygon.Geopath.Add(position);
                }
                

                Map.MapElements.Add(polygon);
            }
        }
    }
}