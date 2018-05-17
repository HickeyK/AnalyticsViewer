using System.Windows.Controls;

namespace AnalyticsViewer
{
    /// <summary>
    /// Interaction logic for RequestByRunDateView.xaml
    /// </summary>
    public partial class RequestByRunDateView : UserControl
    {
        public RequestByRunDateView()
        {
            InitializeComponent();
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
