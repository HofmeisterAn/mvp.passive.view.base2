using Mvp.Passive.View.Base2.Midelware.IView.Application;
using Mvp.Passive.View.Base2.Midelware.Presenter.Application;
using Mvp.Passive.View.Base2.Model;
using System;
using System.Windows.Forms;

namespace Mvp.Passive.View.Base2.View.Application
{
    public partial class ApplicationView : Form, IApplicationView
    {
        private ApplicationPresenter presenter;

        public bool IsWaiting
        {
            get
            {
                return this.Cursor == Cursors.WaitCursor;
            }
            set
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() => { this.IsWaiting = value; }));
                }
                else
                {
                    this.Cursor = value ? Cursors.WaitCursor : Cursors.Default;
                }
            }
        }

        public ApplicationPresenter Presenter
        {
            get
            {
                return this.presenter;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                if (this.presenter != null)
                {
                    throw new InvalidOperationException("Presenter is already set.");
                }

                this.presenter = value;

                // EventHandler von ApplicationPresenter registrieren.
                // this.presenter.EventHandler1 += EventHandler1;
                // this.presenter.EventHandler2 += EventHandler2;

                this.presenter.ConnectionHandler += OnConnectionHandler;
                this.presenter.InvalidInputHandler += OnInvalidInput;

                if (this.IsHandleCreated)
                {
                    this.Presenter.Initialization();
                }
                else
                {
                    this.HandleCreated += delegate { this.Presenter.Initialization(); };
                }
            }
        }

        public ApplicationView()
        {
            InitializeComponent();
        }

        private void OnConnectionHandler(object sender, ConnectionEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnInvalidInput(object sender, InvalidInputEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
