using System;
using System.ComponentModel;
using ui.core;

namespace ui.MWM.ViewModel
{
    internal class MainViewModel: ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public DIscoveryViewModel DiscoveryVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            { _currentView = value;
                OnpropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscoveryVM = new DIscoveryViewModel();
          
           HomeViewCommand = new RelayCommand(
              O =>
                    {
                     CurrentView = HomeVM;
                    },
                 O => true // canExecute: команда всегда доступна
                   );
            DiscoveryViewCommand = new RelayCommand(
                O =>
                {
                    CurrentView = DiscoveryVM;
                },
                O=>true
                );
        }
    }
}
