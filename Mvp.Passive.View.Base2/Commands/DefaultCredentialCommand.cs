using ManyConsole;
using Mvp.Passive.Default.Midelware.Core;
using Mvp.Passive.Default.Midelware.Extension;

namespace Mvp.Passive.View.Base2.Commands
{
    internal abstract class DefaultCredentialCommand : ConsoleCommand
    {
        private readonly Credential credential = new Credential();

        protected Credential Credential
        {
            get
            {
                return new Credential
                {
                    Id = credential.GetHashCode(),
                    Hostname = credential.Hostname,
                    Username = credential.Username,
                    Password = credential.Password
                };
            }
        }

        protected DefaultCredentialCommand()
        {
            this.HasOption("h|hostname=", "Hostname", o => this.credential.Hostname = o);
            this.HasOption("u|username=", "Username", o => this.credential.Username = o);
            this.HasOption("p|password=", "Password", o => this.credential.Password = o.ToEncryptString());
        }
    }
}
