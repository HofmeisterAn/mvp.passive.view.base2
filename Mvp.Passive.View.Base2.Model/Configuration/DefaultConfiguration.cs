using Mvp.Passive.Default.Midelware.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvp.Passive.View.Base2.Model.Configuration
{
    public static class DefaultConfiguration
    {
        public const string DefaultPassword = "DEFAULTPASSWORD";

        public static event EventHandler<ConfigurationChangedEventArgs> ConfigurationChanged;

        private static DefaultSettingsImpl settings;

        private static DefaultSettingsImpl Default
        {
            get
            {
                return new DefaultSettingsImpl
                {
                    Credentials = new List<Credential>
                    {
                        new Credential{ Id = 0, Hostname = string.Empty, Username = string.Empty, Password = string.Empty }
                    }
                };
            }
        }

        public static DefaultSettingsImpl Settings
        {
            get { return settings; }
            set
            {
                if (value == null || value.Credentials == null)
                {
                    value = Default;
                }

                var changes = value.Credentials;

                if (settings != null)
                {
                    // Das Standardpasswort aus der GUI ersetzen.
                    foreach (var credential in value.Credentials)
                    {
                        var setting = settings.Credentials.SingleOrDefault(x => x.Equals(credential));

                        if (setting == null)
                        {
                            continue;
                        }

                        if (credential.PasswordInsecure.Equals(DefaultPassword))
                        {
                            credential.Password = setting.Password;
                        }
                    }

                    // Änderungen in der Konfiguration ermitteln.
                    changes = value.Credentials.Where(x => !settings.Credentials.Any(x.Equals)).ToList();

                    // Hat keine Änderung stattgefunden, abbrechen.
                    if (!changes.Any()) return;
                }

                settings = value;

                OnConfigurationChanged(new ConfigurationChangedEventArgs(changes));

                // Änderungen speichern.
                User.Default.UserSettings = Settings;
                User.Default.Save();
            }
        }

        static DefaultConfiguration()
        {
            Settings = User.Default.UserSettings;
        }

        private static void OnConfigurationChanged(ConfigurationChangedEventArgs e)
        {
            var handler = ConfigurationChanged;
            if (handler != null) handler(null, e);
        }
    }
}
