using Mvp.Passive.Default.Midelware.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mvp.Passive.View.Base2.Model.Configuration
{
    public abstract class DefaultSettings
    {
        public List<Credential> Credentials { get; set; }

        public bool Equals(DefaultSettings obj)
        {
            return (obj != null) && this.Credentials.SequenceEqual(obj.Credentials);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DefaultSettings);
        }

        public override int GetHashCode()
        {
            return this.Credentials.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Credentials);
        }
    }
}
