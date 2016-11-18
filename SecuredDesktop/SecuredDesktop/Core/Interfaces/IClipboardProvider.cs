namespace SecuredDesktop.Core.Interfaces
{
    public interface IClipboardProvider
    {
        void SetTextToClipboard(string format, object data);
    }
}
