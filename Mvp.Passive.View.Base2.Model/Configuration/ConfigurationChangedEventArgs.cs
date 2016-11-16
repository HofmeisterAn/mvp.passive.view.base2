using Mvp.Passive.Default.Midelware.Core;
using System;
using System.Collections.Generic;

namespace Mvp.Passive.View.Base2.Model.Configuration
{
    public class ConfigurationChangedEventArgs : EventArgs
    {
        public List<Credential> ChangedCredentials { get; set; }

        public ConfigurationChangedEventArgs(Credential credential)
        {
            this.ChangedCredentials = new List<Credential> { credential };
        }

        public ConfigurationChangedEventArgs(List<Credential> credentials)
        {
            this.ChangedCredentials = credentials;
        }
    }
}
