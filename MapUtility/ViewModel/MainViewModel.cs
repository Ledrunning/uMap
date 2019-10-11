using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Data;
using System.Windows.Threading;
using Arsis.MapUtility.MapProviders;
using Arsis.MapUtility.Observer;
using DevExpress.Xpf.Map;

namespace Arsis.MapUtility.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        private readonly UserNotification notification = new UserNotification();
        private string cacheDirectory;

        private string currentTime;

        private MapImageDataProviderBase imageLayer;

        public IList<OpenStreetMapKind> ListOfOsmKinds = new List<OpenStreetMapKind>
        {
            OpenStreetMapKind.CycleMap,
            OpenStreetMapKind.CyclingRoutes,
            OpenStreetMapKind.GrayScale,
            OpenStreetMapKind.HikingRoutes,
            OpenStreetMapKind.Hot,
            OpenStreetMapKind.PublicTransport,
            OpenStreetMapKind.Transport,
            OpenStreetMapKind.SeaMarks,
            //OpenStreetMapKind.Basic
        };

        private OpenStreetMapKind selectedKind;

        private string tilesDirectory;
        public DispatcherTimer timer;

        public MainViewModel()
        {
            GetCurrentTime();
            SetDirectory();
            imageLayer = new CustomMapDataProvider();
            FillComboBox();
        }

        public string FirstTabItem { get; } = "Кеширование карты";
        public string SecondTabItem { get; } = "Локальная карта";

        public CollectionView OsmMapKind { get; private set; }

        public OpenStreetMapKind SelectedKind
        {
            get => selectedKind;
            set
            {
                if (selectedKind == value) return;
                selectedKind = value;
                OnPropertyChanged(nameof(SelectedKind));
            }
        }

        public string TilesDirectory
        {
            get => tilesDirectory;
            set
            {
                cacheDirectory = value;

                OnPropertyChanged(nameof(TilesDirectory));
            }
        }

        public MapImageDataProviderBase MapImageLayer
        {
            get => imageLayer;
            set
            {
                imageLayer = value;
                OnPropertyChanged(nameof(MapImageLayer));
            }
        }

        public string CurrentTimeDate
        {
            get => currentTime;
            set
            {
                currentTime = value;
                OnPropertyChanged();
            }
        }

        private string url;

        public string Url
        {
            get =>url;
            set
            {

                    url = value;
                    OnPropertyChanged(nameof(Url));

            }
        }


    public string OsmServerUri { get; } = ConfigurationSettings.AppSettings.Get("tileServer");

        private void FillComboBox()
        {
            OsmMapKind = new CollectionView(ListOfOsmKinds);
        }

        /// <summary>
        ///     Метод для установки кеширования в определенную директорию
        /// </summary>
        private void SetDirectory()
        {
            try
            {
                tilesDirectory = ConfigurationSettings.AppSettings.Get("cacheDirectory");
            }
            catch
            {
                notification.ShowErrorMessage("Ошибка конфигурации или директория не найдена!");
            }
        }

        private void GetCurrentTime()
        {
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) => { CurrentTimeDate = DateTime.Now.ToString(); };
            timer.Start();
        }
    }
}