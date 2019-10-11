using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Arsis.MapUtility.Observer;
using DevExpress.Xpf.Map;

namespace Arsis.MapUtility.MapProviders
{
    public class CustomTileSource : MapTileSourceBase
    {
        //private const string roadUrlTemplate =
        //    @"http://{subdomain}.tile.openstreetmap.org/{tileLevel}/{tileX}/{tileY}.png";

        public const int maxZoomLevel = 20;
        public const int tileSize = 256;

        private static readonly int imageWidth = (int) Math.Pow(2.0, maxZoomLevel) * tileSize;
        private static readonly int imageHeight = (int) Math.Pow(2.0, maxZoomLevel) * tileSize;
        private static readonly string[] subdomains = {"a", "b", "c"};
        private readonly string directoryPath;
        private readonly string fileName = ConfigurationSettings.AppSettings.Get("fileName");
        private readonly UserNotification notification = new UserNotification();

        public CustomTileSource()
            : base(imageWidth, imageHeight, tileSize, tileSize)
        {
            //var dir = new DirectoryInfo(Directory.GetCurrentDirectory());
            //directoryPath = dir.Parent.Parent.FullName;
            //directoryPath = Path.GetDirectoryName(
            //    System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase); ;

            directoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string Url { get; set; }

        public override Uri GetTileByZoomLevel(int zoomLevel, long tilePositionX, long tilePositionY)
        {
            if (zoomLevel <= maxZoomLevel)
                try
                {
                    var u = new Uri(string.Format(
                        directoryPath + "\\openstreetmap.org\\" + fileName + "_{0}_{1}_{2}.png", zoomLevel,
                        tilePositionX, tilePositionY));
                    Debug.WriteLine(u);

                    return u;
                }

                catch
                {
                    notification.ShowErrorMessage("Ошибка файла");
                }

            return null;
        }


        ///// <summary>
        ///// World wide
        ///// </summary>
        ///// <param name="zoomLevel"></param>
        ///// <param name="tilePositionX"></param>
        ///// <param name="tilePositionY"></param>
        ///// <returns></returns>
        //public override Uri GetTileByZoomLevel(int zoomLevel, long tilePositionX, long tilePositionY)
        //{
        //    var url = roadUrlTemplate;
        //    url = url.Replace("{tileX}", tilePositionX.ToString(CultureInfo.InvariantCulture));
        //    url = url.Replace("{tileY}", tilePositionY.ToString(CultureInfo.InvariantCulture));
        //    url = url.Replace("{tileLevel}", zoomLevel.ToString(CultureInfo.InvariantCulture));
        //    url = url.Replace("{subdomain}", subdomains[GetSubdomainIndex(subdomains.Length)]);
        //    return new Uri(url);
        //}
    }
}