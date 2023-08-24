using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndView : BaseView
{
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
    }

    public void RestartGame()
    {
        GameManager.instances.RestartGame();
        ViewManager.instances.OnSwitchView(ViewIndex.CountDownView);
    }    
}
