﻿using AvDataAccess;
using AvEntities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DirectoryServices;
using MvvmDialogs;

namespace AvViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {

        #region Properties


        public AvDataContext AvDataContext { get; set; }

        public FileStoreLocations FileStoreLocations { get; set; }

        public ObservableCollection<DateTime> RunDates { get; set; }

        public ObservableCollection<StoreYbAnalyticReq> RequestGroups { get; set; }

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

        private FileStoreLocation _selectedFileStoreLocation;

        public FileStoreLocation SelectedFileStoreLocation
        {
            get { return _selectedFileStoreLocation; }
            set
            {
                _selectedFileStoreLocation = value;
                GetFiles();
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

        public ObservableCollection<FileInfo> Files { get; set; }

        //public ICommand RetrieveByIdCommand { get; private set; }
        public DelegateCommand<string> RetrieveByCadisIdCommand { get; private set; }
        public DelegateCommand<string> RetrieveByYieldbookIdCommand { get; private set; }
        public DelegateCommand<FileInfo> OpenFileCommand { get; private set; }

        private readonly IDialogService dialogService;

        #endregion


        #region Constructor

        public MainWindowViewModel()
        {
            var databaseConfigFileName = "AnalyticViewer.database.config";
            var installationDirectory = @"c:\Dev\AnalyticsViewer\AvDataAccess";
            var databaseConfig = System.IO.Path.Combine(installationDirectory, databaseConfigFileName);
            var mappingSource = XmlMappingSource.FromUrl(databaseConfig);
            AvDataContext = new AvDataContext("Data Source=lonbscadsqlbl01;Initial Catalog=CADIS_E2E01;Integrated Security=True", mappingSource, false, 30);

            //RunDates = new ObservableCollection<DateTime>(AvDataContext.RunDateList());

            RequestGroups = new ObservableCollection<StoreYbAnalyticReq>(AvDataContext.RequestGroup());

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

            OpenFileCommand = new DelegateCommand<FileInfo>(new Action<FileInfo>(fi =>
            {
                DisplayFile(fi);
            }));

            FileStoreLocations = new FileStoreLocations();

            this.dialogService = new DialogService();
        }

        #endregion


        #region Methods

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

        private void GetFiles()
        {
            Files = new ObservableCollection<FileInfo>(
                DirectoryAccess.GetDirContent(SelectedFileStoreLocation.Location, SelectedFileStoreLocation.Filter));
            OnPropertyChanged("Files");
        }

        private void DisplayFile(FileInfo fi)
        {
            var dialogViewModel = new TextDisplayWindowViewModel();

            bool? success = dialogService.ShowDialog(this, dialogViewModel);
            if (success == true)
            {
            }
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
