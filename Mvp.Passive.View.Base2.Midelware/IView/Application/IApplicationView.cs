using Mvp.Passive.Default.Midelware.IView;
using Mvp.Passive.View.Base2.Midelware.Presenter.Application;

namespace Mvp.Passive.View.Base2.Midelware.IView.Application
{
    public interface IApplicationView : IDefaultView
    {
        ApplicationPresenter Presenter { get; set; }
    }
}
