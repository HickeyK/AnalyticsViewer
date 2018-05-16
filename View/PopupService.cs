using System;
using System.Windows;
using AvViewModel;

namespace AnalyticsViewer
{
    class PopupService : IPopupService
    {
        public void ShowPopup(object dataContext)
        {

            if (Application.Current.MainWindow.IsLoaded)
            {
                var popUp = new PopupWindow();

                PopupWindow popupWin = new PopupWindow
                {
                    Owner = Application.Current.MainWindow,
                    DataContext = dataContext
                };
            }
        }
    }
}
