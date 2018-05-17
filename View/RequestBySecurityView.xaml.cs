using System.Windows.Controls;

namespace AnalyticsViewer
{
    /// <summary>
    /// Interaction logic for RequestBySecurityView.xaml
    /// </summary>
    public partial class RequestBySecurityView : UserControl
    {
        public RequestBySecurityView()
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
