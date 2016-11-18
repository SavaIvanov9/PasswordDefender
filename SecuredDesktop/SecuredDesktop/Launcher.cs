namespace SecuredDesktop
{
    using Core;
    using Core.Providers;
    using Core.Providers.ClipBoardProvider;

    class Launcher
    {
        static void Main()
        {
            Engine.Instance(
                new WriterProvider(),
                new PasswordReceiver(),
                new ClipboardProvider())
                .Start();
        }
    }
}
