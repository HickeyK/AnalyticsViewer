using AvDataAccess;
using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Runtime.CompilerServices;

namespace AvViewModel
{
    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged, IDisposable
    {

        #region Properties

        public IUnitOfWork Repository { get; set; }


        public IRequestByRunDateViewModel RequestByRunDateViewModel { get; set; }
        public IRequestBySecurityViewModel RequestBySecurityViewModel { get; set; }
        public ILogFileViewModel LogFileViewModel { get; set; }

        #endregion


        #region Constructor

        public MainWindowViewModel(IUnitOfWork repository, 
                                   IRequestByRunDateViewModel requestByRunDateViewModel,
                                   IRequestBySecurityViewModel requestBySecurityViewModel,
                                   ILogFileViewModel logFileViewModel)
        {

            Repository = repository;

            RequestByRunDateViewModel = requestByRunDateViewModel; 
            RequestBySecurityViewModel = requestBySecurityViewModel;
            LogFileViewModel = logFileViewModel; 

        }

        #endregion


        #region Event Handling

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void Dispose()
        {
            Repository.Dispose();
        }
    }

}
