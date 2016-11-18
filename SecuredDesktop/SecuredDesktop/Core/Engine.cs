namespace SecuredDesktop.Core
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Interfaces;

    public class Engine
    {
        private readonly IWriterProvider _writer;
        private readonly IPasswordReceiver _passwordReceiver;
        private readonly IClipboardProvider _clipboardProvider;

        private Engine(IWriterProvider textWriter, IPasswordReceiver passwordReceiver, IClipboardProvider clipboardProvider)
        {
            this._writer = textWriter;
            this._passwordReceiver = passwordReceiver;
            this._clipboardProvider = clipboardProvider;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Engine Instance(IWriterProvider writerProvider, IPasswordReceiver passwordReceiver, IClipboardProvider clipboardProvider)
        {
            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer cannot be null.");
            }

            if (passwordReceiver == null)
            {
                throw new ArgumentNullException($"Password Receiver cannot be null.");
            }

            if (clipboardProvider == null)
            {
                throw new ArgumentNullException($"Clipboard provider cannot be null.");
            }

            return new Engine(writerProvider, passwordReceiver, clipboardProvider);
        }

        public void Start()
        {
            var password = _passwordReceiver.ReceivePassword();

            _clipboardProvider.SetTextToClipboard(DataFormats.Text, password);

            _writer.WriteLine("Password saved to clipboard.");
        }
    }
}
