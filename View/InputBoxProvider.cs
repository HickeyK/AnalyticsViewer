using System.Windows;
using AvViewModel;

namespace AnalyticsViewer
{
    class InputBoxProvider : IInputBox
    {
        public string RequestPassword()
        {
            if (Application.Current.MainWindow.IsLoaded)
            {
                PasswordDialog pwDialog = new PasswordDialog
                {
                    Owner = Application.Current.MainWindow,
                };
                pwDialog.ShowDialog();

                if (pwDialog.DialogResult.HasValue && pwDialog.DialogResult.Value)
                    return pwDialog.PasswordBox.Password;

            }
            return null;
        }
    }
}
