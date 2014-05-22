using System;

namespace DbUpAndDown.Engine
{
    class DelegateDisposable : IDisposable
    {
        private readonly Action dispose;

        public DelegateDisposable(Action dispose)
        {
            this.dispose = dispose;
        }

        public void Dispose()
        {
            dispose();
        }
    }
}