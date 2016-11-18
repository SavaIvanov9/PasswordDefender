using System;
using System.Threading;
using System.Windows.Forms;
using SecuredDesktop.Core.Interfaces;
using SecuredDesktop.Core.Providers;

namespace SecuredDesktop
{
    using Core;

    class Launcher
    {
        static void Main()
        {
            Engine.Instance(
                new WriterProvider(),
                new PasswordReceiver())
                .Start();
        }
    }
}
