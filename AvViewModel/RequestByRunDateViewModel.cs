using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AvDataAccess;
using AvEntities;

namespace AvViewModel
{
    public class RequestByRunDateViewModel : INotifyPropertyChanged, IDisposable
    {

        public RequestByRunDateViewModel(AvDataContext avDataContext)
        {
            AvDataContext = avDataContext;
            RequestGroups = new ObservableCollection<StoreYbAnalyticReq>(AvDataContext.RequestGroup());
        }


        public AvDataContext AvDataContext { get; set; }

        private StoreYbAnalyticReq _selectedRequestGroup;

        public StoreYbAnalyticReq SelectedRequestGroup
        {
            get { return _selectedRequestGroup; }
            set
            {
                _selectedRequestGroup = value;
                GetRequests();
            }
        }


        private bool _includePortfolio1 = true;
        private bool _includePortfolio2;
        private bool _includePortfolio3;
        private bool _includePortfolio4;

        public bool IncludePortfolio1
        {
            get { return _includePortfolio1; }
            set
            {
                _includePortfolio1 = value;
                GetRequests();
            }
        }

        public bool IncludePortfolio2
        {
            get { return _includePortfolio2; }
            set
            {
                _includePortfolio2 = value;
                GetRequests();
            }
        }

        public bool IncludePortfolio3
        {
            get { return _includePortfolio3; }
            set
            {
                _includePortfolio3 = value;
                GetRequests();
            }
        }

        public bool IncludePortfolio4
        {
            get { return _includePortfolio4; }
            set
            {
                _includePortfolio4 = value;
                GetRequests();
            }
        }


        public ObservableCollection<StoreYbAnalyticReq> Requests { get; set; }


        public ObservableCollection<DateTime> RunDates { get; set; }

        public ObservableCollection<StoreYbAnalyticReq> RequestGroups { get; set; }


        private void GetRequests()
        {
            short portfolio = 1;
            if (IncludePortfolio2) portfolio = 2;
            if (IncludePortfolio3) portfolio = 3;
            if (IncludePortfolio4) portfolio = 4;

            var param = new StoreYbAnalyticReq()
            {
                RunDate = SelectedRequestGroup.RunDate,
                ValDate = SelectedRequestGroup.ValDate,
                Slot = SelectedRequestGroup.Slot,
                PortfolioId = portfolio
            };

            Requests = new ObservableCollection<StoreYbAnalyticReq>(AvDataContext.GetRequests(param));
            OnPropertyChanged("Requests");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Dispose()
        {
            AvDataContext.Dispose();
        }
    }
}
