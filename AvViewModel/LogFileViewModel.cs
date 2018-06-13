using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using DirectoryServices;

namespace AvViewModel
{
    public class LogFileViewModel : ILogFileViewModel, INotifyPropertyChanged, IDisposable
    {


        public FileStorageLocations FileStoreLocations { get; set; }


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



        public ObservableCollection<FileInfo> Files { get; set; }

        public DelegateCommand<FileInfo> OpenFileCommand { get; private set; }

        private FileInfo _selectedFile;
        public FileInfo SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;

                if (DirectoryAccess.Password == null)
                {
                    this.InputBox.RequestPassword();
                }

                FileText = _selectedFile == null ? "" : DirectoryAccess.GetFileContent(_selectedFile.FullName);
                OnPropertyChanged();
            }
        }

        private string _fileText;
        public string FileText
        {
            get { return _fileText; }
            set
            {
                _fileText = value;
                OnPropertyChanged();
            }
        }


        private IInputBox _inputBox;

        public IInputBox InputBox
        {
            get { return _inputBox; }
            set { _inputBox = value; }
        }


        public LogFileViewModel(IInputBox inputBox)
        {
            InputBox = inputBox;

            FileStoreLocations = FileStorageLocations.Create();




            OpenFileCommand = new DelegateCommand<FileInfo>(new Action<FileInfo>(fi =>
            {
                FileText = DirectoryAccess.GetFileContent(fi.FullName);

                this.OnDisplayPopupWindow(FileText);
                OnPropertyChanged("FileText");

            }));

        }


        private void GetFiles()
        {
            if (DirectoryAccess.Password == null)
            {
                var pw = this.InputBox.RequestPassword();
                if (pw == null)
                {
                    return;
                }
                DirectoryAccess.Password = pw;
            }


            Files = new ObservableCollection<FileInfo>(
                DirectoryAccess.GetDirContent(SelectedFileStoreLocation.Location, SelectedFileStoreLocation.Filter));
            OnPropertyChanged("Files");
        }


        // Main Window will subscribe and open popup when event fires
        public event EventHandler<PopupWindowEventArgs> DisplayPopupWindow = delegate { };

        protected virtual void OnDisplayPopupWindow(string message)
        {
            var vm = new TextDisplayWindowViewModel { Text = message };
            DisplayPopupWindow.Invoke(this, new PopupWindowEventArgs(vm));
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void Dispose()
        {
        }

    }
}
