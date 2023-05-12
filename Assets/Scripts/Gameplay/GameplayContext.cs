using Assets.Scripts.Core;
using Assets.Scripts.DependencyInjection;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameplayContext : DependencyContext
    {
        [SerializeField] private FallTrigger _fallTrigger;

        protected override void Inject(IContainer container)
        {
            var injector = new MainInjector(container);
            foreach (var component in GetComponentsInChildren<MonoBehaviour>())
                injector.Inject(component);
        }

        protected override IContainer Setup()
        {
            IContainerBuilder builder = new MainContainerBuilder();
            builder
                .RegistryContainer(ProjectContext.Container)
                .RegisterSingleton<ICoinCounter, CoinCounter>()
                .RegisterSingleton<ILoseCondition, FallLoseCondition>()
                .RegisterSingleton<IFallTrigger>(_fallTrigger)
                ;

            return builder.Build();
        }
    }
}
