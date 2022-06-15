using System;

namespace API_TEST.Core
{
    public class Manager : IDisposable
    {
        public readonly Models.ModelDataContext Factory;

        public Manager() => Factory = new Models.ModelDataContext();

        public void Connect() => Factory.Connection.Open();
        public void Dispose() => Factory.Connection.Dispose();
    }
}