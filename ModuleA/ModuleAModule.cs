using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Unity;
using Unity.Injection;

namespace ModuleA
{
    public class ModuleAModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Unityのコンテナに直接アクセスできる
            // NugetにてUnity、Prism.Unityを導入する必要あり
            var container = containerRegistry.GetContainer();

            // 普通にUnityが利用可能
            container.RegisterType<Models.ModelA>(new InjectionFactory(x =>
            {
                return new Models.ModelA("Hello, Prism 7.x !");
            }));

            // Viewの登録
            containerRegistry.RegisterForNavigation<ViewA>();
        }
    }
}