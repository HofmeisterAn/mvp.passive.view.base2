using Mvp.Passive.View.Base2.Model.Configuration;

namespace Mvp.Passive.View.Base2.Commands
{
    internal class AddDefaultCredential : DefaultCredentialCommand
    {
        public AddDefaultCredential()
        {
            this.IsCommand("add-credential", "This command adds the credential information encrypted to the user settings.");
        }

        public override int Run(string[] remainingArguments)
        {
            var settings = new DefaultSettingsImpl();

            DefaultConfiguration.Settings.Credentials.ForEach(settings.Credentials.Add);

            settings.Credentials.Add(this.Credential);

            DefaultConfiguration.Settings = settings;

            return 0;
        }
    }
}
