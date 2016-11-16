using Mvp.Passive.Default.Midelware.Presenter;
using Mvp.Passive.View.Base2.Midelware.IView.Application;
using Mvp.Passive.View.Base2.Model;
using Mvp.Passive.View.Base2.Model.Application;
using System;
using System.Timers;

namespace Mvp.Passive.View.Base2.Midelware.Presenter.Application
{
    public abstract class ApplicationPresenter : DefaultPresenter<IApplicationRepository, IApplicationView>
    {
        public abstract event EventHandler<ConnectionEventArgs> ConnectionHandler;

        public abstract event EventHandler<InvalidInputEventArgs> InvalidInputHandler;

        protected ApplicationPresenter(IApplicationRepository repository, IApplicationView view)
            : base(repository, view)
        {
            view.Presenter = this;
        }

        protected virtual void Action(Action action)
        {
            try
            {
                this.View.IsWaiting = true;

                action();
            }
            finally
            {
                this.View.IsWaiting = false;
            }
        }

        protected virtual void Action(int interval, Action action)
        {
            var timer = new Timer(interval);

            timer.Enabled = true;
            timer.Elapsed += delegate
            {
                this.Queue.QueueTask(action);
            };

            timer.Start();
        }
    }
}
