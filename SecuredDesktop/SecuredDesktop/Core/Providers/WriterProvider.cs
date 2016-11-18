namespace SecuredDesktop.Core.Providers
{
    using System;
    using Interfaces;

    public class WriterProvider : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
