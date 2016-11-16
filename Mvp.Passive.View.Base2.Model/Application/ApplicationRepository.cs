using System;

namespace Mvp.Passive.View.Base2.Model.Application
{
    public class ApplicationRepository : IApplicationRepository
    {
        private bool disposed;

        public bool IsConnected { get { return true; } }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
            }

            disposed = true;
        }
    }
}
