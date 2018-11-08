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
            // 画面遷移を行う
            // 今回の本題とは関係ないので説明略
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ContentRegion", nameof(ViewA));
        }

        // ここでコンテナへの登録作業を行う
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // ContainerRegistryが抽象化されたコンテナへの登録用Interface

            // GetContainerでUnityのコンテナに直接アクセスできる
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