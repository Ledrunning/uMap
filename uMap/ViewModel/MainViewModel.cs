using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Threading;
using DevExpress.Xpf.Map;
using uMap.Project.Observer;

namespace uMap.Project.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        private const int TimerIntervalInSec = 1;
        private string _currentTime;
        private MapImageDataProviderBase _imageLayer;
        private OpenStreetMapKind _selectedKind;
        private string _url;

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

        public DispatcherTimer Timer;

        public MainViewModel()
        {
            GetCurrentTime();
            FillComboBox();
        }

        public CollectionView OsmMapKind { get; private set; }

        public OpenStreetMapKind SelectedKind
        {
            get => _selectedKind;
            set
            {
                if (_selectedKind == value)
                {
                    return;
                }

                _selectedKind = value;
                OnPropertyChanged(nameof(SelectedKind));
            }
        }

        public MapImageDataProviderBase MapImageLayer
        {
            get => _imageLayer;
            set
            {
                _imageLayer = value;
                OnPropertyChanged(nameof(MapImageLayer));
            }
        }

        public string CurrentTimeDate
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged(nameof(Url));
            }
        }


        public string OsmServerUri { get; } = ConfigurationManager.AppSettings.Get("tileServer");

        private void FillComboBox()
        {
            OsmMapKind = new CollectionView(ListOfOsmKinds);
        }

        private void GetCurrentTime()
        {
            Timer = new DispatcherTimer(DispatcherPriority.Render)
            {
                Interval = TimeSpan.FromSeconds(TimerIntervalInSec)
            };
            Timer.Tick += (sender, args) => { CurrentTimeDate = DateTime.Now.ToString(CultureInfo.InvariantCulture); };
            Timer.Start();
        }
    }
}