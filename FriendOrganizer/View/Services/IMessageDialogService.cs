namespace FriendOrganizer.View.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOkCancelDialog(string content, string title);
    }
}