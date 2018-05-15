using AvViewModel;
using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace AnalyticsViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel mvm;
        
        public MainWindow()
        {
            InitializeComponent();
            mvm = new MainWindowViewModel();
            this.DataContext = mvm;

            mvm.DisplayPopupWindow += DisplayPopupWindow;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (DataContext !=null)
            {
                MainWindowViewModel vm =(MainWindowViewModel) DataContext;
                vm.Dispose();
            }
        }

        private void RequestsDataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
            {
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyy";
            }
        }

        private void DisplayPopupWindow(object sender, EventArgs e)
        {
            PopupWindow popupWin = new PopupWindow {Owner = this};


            var textDisplayUserControl = new TextDisplayUserControl();
            popupWin.DataContext = mvm;
            //popupWin.PopupUserControl = textDisplayUserControl;
            popupWin.TestDisplayUserControl.DataContext = mvm;


            popupWin.Show();
            

        }
    }
}
