using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Data;
using System.Windows.Threading;
using DevExpress.Xpf.Map;
using uMap.Project.Observer;

namespace uMap.Project.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        private readonly UserNotification notification = new UserNotification();

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
            OpenStreetMapKind.Basic
        };

        private OpenStreetMapKind selectedKind;

        private string tilesDirectory;
        public DispatcherTimer timer;

        private string url;

        public MainViewModel()
        {
            GetCurrentTime();
            FillComboBox();
        }

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

        public string Url
        {
            get => url;
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

        private void GetCurrentTime()
        {
            timer = new DispatcherTimer(DispatcherPriority.Render);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, args) => { CurrentTimeDate = DateTime.Now.ToString(); };
            timer.Start();
        }
    }
}