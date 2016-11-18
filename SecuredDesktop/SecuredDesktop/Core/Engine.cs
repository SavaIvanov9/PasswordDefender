using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecuredDesktop.Core.Interfaces;

namespace SecuredDesktop.Core
{
    public class Engine
    {
        private readonly IWriter _writer;
        private readonly IPasswordReceiver _passwordReceiver;
        
        private Engine(IWriter textWriter, IPasswordReceiver passwordReceiver)
        {
            this._writer = textWriter;
            this._passwordReceiver = passwordReceiver;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Engine Instance(IWriter writerProvider, IPasswordReceiver passwordReceiver)
        {
            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer cannot be null.");
            }

            if (passwordReceiver == null)
            {
                throw new ArgumentNullException($"Password Receiver cannot be null.");
            }

            return new Engine(writerProvider, passwordReceiver);
        }

        public void Start()
        {
            var password = _passwordReceiver.ReceivePassword();

            new SetClipboardHelper(DataFormats.Text, password).Start();

            _writer.WriteLine("Password saved to clipboard.");
            Console.ReadLine();
        }
    }
}
