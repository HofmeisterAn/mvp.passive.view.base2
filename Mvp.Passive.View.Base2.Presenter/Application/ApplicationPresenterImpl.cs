using Mvp.Passive.Default.Midelware;
using Mvp.Passive.View.Base2.Midelware.IView.Application;
using Mvp.Passive.View.Base2.Midelware.Presenter.Application;
using Mvp.Passive.View.Base2.Model;
using Mvp.Passive.View.Base2.Model.Application;
using Mvp.Passive.View.Base2.Model.Configuration;
using System;

namespace Mvp.Passive.View.Base2.Presenter.Application
{
    public class ApplicationPresenterImpl : ApplicationPresenter
    {
        public override event EventHandler<ConnectionEventArgs> ConnectionHandler;

        public override event EventHandler<InvalidInputEventArgs> InvalidInputHandler;

        public ApplicationPresenterImpl(IApplicationRepository repository, IApplicationView view)
            : base(repository, view)
        {
            DefaultConfiguration.ConfigurationChanged += OnConfigurationChanged;
        }

        public override void Initialization()
        {
            // Wird ausgeführt, sobald das Handle für das Objekt ApplicationView erstellt wurde.
            // Das Handle wird erstellt, wenn das Control zum ersten Mal angezeigt wird.

            if (this.Repository.IsConnected)
            {
                // todo: Ausführen, wenn eine Serververbindung aufgebaut wurde.
            }
            else
            {
                this.ConnectionHandler.Raise(null, new ConnectionEventArgs());
            }
        }

        private void OnConfigurationChanged(object sender, ConfigurationChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Join("\n", e.ChangedCredentials));
        }
    }
}
