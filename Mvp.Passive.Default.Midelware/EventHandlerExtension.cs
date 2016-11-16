using System;

namespace Mvp.Passive.Default.Midelware
{
    public static class EventHandlerExtension
    {
        public static void Raise<T>(this EventHandler<T> handler, object sender, T args) where T : EventArgs
        {
            if (handler != null)
            {
                handler(sender, args);
            }
        }
    }
}
