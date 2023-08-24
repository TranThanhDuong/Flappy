using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartView : BaseView
{
    public override void OnSetup(ViewParam param)
    {
        GameManager.instances.B_GamePause = true;
    }

    public void OnStartGame()
    {
        ViewManager.instances.OnSwitchView(ViewIndex.CountDownView);
    }
}
