using UnityEngine;
using Zenject;

public class Context : MonoInstaller
{
    #region Variables

    private MyPlayer _myPlayer;

    #endregion

    #region Function

    public override void InstallBindings()
    {
        Container.Bind<MyPlayer>().FromInstance(_myPlayer).AsSingle();
    }

    #endregion
}
