using System.Windows;

namespace uMap.Project.Observer
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