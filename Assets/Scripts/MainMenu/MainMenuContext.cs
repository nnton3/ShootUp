using Assets.Scripts;
using Assets.Scripts.Core;
using Assets.Scripts.DependencyInjection;
using UnityEngine;

public class MainMenuContext : DependencyContext
{
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
            ;

        return builder.Build();
    }
}
