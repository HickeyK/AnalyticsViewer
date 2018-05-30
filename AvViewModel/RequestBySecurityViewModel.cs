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
    public class RequestBySecurityViewModel : INotifyPropertyChanged, IDisposable
    {
        public AvDataContext AvDataContext { get; set; }


        public ObservableCollection<StoreYbAnalyticReq> Requests { get; set; }

        public DelegateCommand<string> RetrieveByCadisIdCommand { get; private set; }

        public DelegateCommand<string> RetrieveByYieldbookIdCommand { get; private set; }


        public RequestBySecurityViewModel(AvDataContext avDataContext)
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
