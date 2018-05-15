using AvViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AnalyticsViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
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
    }
}
