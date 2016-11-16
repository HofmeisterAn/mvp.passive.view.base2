using System;

namespace Mvp.Passive.Default.Midelware.IView
{
    public interface IDefaultView : IDisposable
    {
        bool IsWaiting { get; set; }
    }
}
