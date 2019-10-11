using System;
using System.Windows;
using DevExpress.Xpf.Map;

namespace Arsis.MapUtility.MapProviders
{
    public class CustomMapDataProvider : MapDataProviderBase
    {
        private readonly SphericalMercatorProjection projection = new SphericalMercatorProjection();

        public CustomMapDataProvider()
        {
            SetTileSource(new CustomTileSource());
        }

        public override ProjectionBase Projection => projection;

        protected override MapDependencyObject CreateObject()
        {
            return new CustomMapDataProvider();
        }

        public override Size GetMapSizeInPixels(double zoomLevel)
        {
            return new Size(Math.Pow(2.0, zoomLevel) * OpenStreetMapTileSource.tileSize,
                Math.Pow(2.0, zoomLevel) * OpenStreetMapTileSource.tileSize);
        }
    }
}