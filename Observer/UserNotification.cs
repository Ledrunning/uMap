using System.Windows;

namespace Arsis.MapUtility.Observer
{
    public class UserNotification
    {
        private string message;

        public UserNotification()
        {
        }

        public UserNotification(string message)
        {
            this.message = message;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Упс!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}