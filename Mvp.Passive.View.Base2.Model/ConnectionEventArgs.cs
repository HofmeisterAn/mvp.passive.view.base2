using System;

namespace Mvp.Passive.View.Base2.Model
{
    public class ConnectionEventArgs : EventArgs
    {
        public bool IsConnected { get; set; }

        public ConnectionEventArgs(bool isConnected = false)
        {
            this.IsConnected = false;
        }
    }
}
