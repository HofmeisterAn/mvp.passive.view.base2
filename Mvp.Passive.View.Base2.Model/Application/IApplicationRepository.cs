using Mvp.Passive.Default.Midelware.IRepository;

namespace Mvp.Passive.View.Base2.Model.Application
{
    public interface IApplicationRepository : IDefaultRepository
    {
        bool IsConnected { get; }
    }
}
