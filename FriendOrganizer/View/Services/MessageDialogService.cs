using System.Windows;

namespace FriendOrganizer.View.Services
{
    public class MessageDialogService : IMessageDialogService
    {
        public MessageDialogResult ShowOkCancelDialog(string content, string title)
        {
            var result = MessageBox.Show(content, title, MessageBoxButton.OKCancel);
            return result == MessageBoxResult.OK ?
                MessageDialogResult.Ok :
                MessageDialogResult.Cancel;
        }
    }

    public enum MessageDialogResult
    {
        Ok,
        Cancel
    }
}
