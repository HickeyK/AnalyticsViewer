using AvDataAccess;
using AvEntities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using DirectoryServices;

namespace AvViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {

        #region Properties

        public AvDataContext AvDataContext { get; set; }


        private IInputBox _inputBox;

        public IInputBox InputBox
        {
            get { return _inputBox; }
            set { _inputBox = value; }
        }

        public RequestByRunDateViewModel RequestByRunDateViewModel { get; set; }
        public RequestBySecurityViewModel RequestBySecurityViewModel { get; set; }
        public LogFileViewModel LogFileViewModel { get; set; }

        #endregion


        #region Constructor

        public MainWindowViewModel(IInputBox inputBox)
        {
            var databaseConfigFileName = "AnalyticViewer.database.config";
            var installationDirectory = @"c:\Dev\AnalyticsViewer\AvDataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            AvDataContext = new AvDataContext("Data Source=lonbscadsqlbl01;Initial Catalog=CADIS_E2E01;Integrated Security=True", mappingSource, false, 30);

            InputBox = inputBox;

            RequestByRunDateViewModel = new RequestByRunDateViewModel(AvDataContext);
            RequestBySecurityViewModel = new RequestBySecurityViewModel(AvDataContext);
            LogFileViewModel = new LogFileViewModel(InputBox);

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
            AvDataContext.Dispose();
        }
    }

}
