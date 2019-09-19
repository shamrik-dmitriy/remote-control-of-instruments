namespace ServiceDesktop.Services.MessageServices
{
    public interface IMessageService
    {
        void ShowMessage(string message);
        void ShowMessage(string message, string cation);
        void ShowExclamation(string message);
        void ShowExclamation(string message, string caption);
        void ShowError(string message);
        void ShowError(string message, string caption);
        void ShowWarning(string message);
        void ShowWarning(string message, string caption);
    }
}