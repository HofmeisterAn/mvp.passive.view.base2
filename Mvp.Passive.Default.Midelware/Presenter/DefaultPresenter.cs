using Mvp.Passive.Default.Midelware.Core;
using Mvp.Passive.Default.Midelware.IRepository;
using Mvp.Passive.Default.Midelware.IView;
using System;

namespace Mvp.Passive.Default.Midelware.Presenter
{
    public abstract class DefaultPresenter<T, U>
        where T : IDefaultRepository
        where U : IDefaultView, IDisposable
    {
        private readonly BackgroundQueue queue = new BackgroundQueue();

        private readonly T repository;

        private readonly U view;

        private bool disposed;

        protected T Repository
        {
            get { return this.repository; }
        }

        protected U View
        {
            get { return this.view; }
        }

        protected BackgroundQueue Queue
        {
            get
            {
                return this.queue;
            }
        }

        public abstract void Initialization();

        protected DefaultPresenter(T repository, U view)
        {
            if (repository == null)
            {
                throw new ArgumentNullException();
            }

            if (view == null)
            {
                throw new ArgumentNullException();
            }

            this.repository = repository;
            this.view = view;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                this.Repository.Dispose();
            }

            disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
