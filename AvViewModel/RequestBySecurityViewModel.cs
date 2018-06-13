using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AvDataAccess;
using AvEntities;

namespace AvViewModel
{
    public class RequestBySecurityViewModel : IRequestBySecurityViewModel, INotifyPropertyChanged, IDisposable
    {
        public IUnitOfWork AvDataContext { get; set; }


        public ObservableCollection<StoreYbAnalyticReq> Requests { get; set; }

        public DelegateCommand<string> RetrieveByCadisIdCommand { get; private set; }

        public DelegateCommand<string> RetrieveByYieldbookIdCommand { get; private set; }


        public RequestBySecurityViewModel(IUnitOfWork avDataContext)
        {
            AvDataContext = avDataContext;

            RetrieveByCadisIdCommand = new DelegateCommand<string>(new Action<string>(i =>
            {
                int cadisId;
                if (int.TryParse(i, out cadisId))
                {
                    Requests = new ObservableCollection<StoreYbAnalyticReq>(AvDataContext.GetRequestsByCadisId(cadisId));
                    OnPropertyChanged("Requests");
                }
            }));


            RetrieveByYieldbookIdCommand = new DelegateCommand<string>(new Action<string>(i =>
            {
                Requests = new ObservableCollection<StoreYbAnalyticReq>(AvDataContext.GetRequestsByYieldbookId(i));
                OnPropertyChanged("Requests");
            }));

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
