using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameView : BaseView
{
    public TextMeshProUGUI text;
    public override void OnSetup(ViewParam param)
    {
        base.OnSetup(param);
        GameManager.instances.B_GamePause = false;
    }

    public void FixedUpdate()
    {
        text.text = "" + GameManager.instances.Point;
    }
}
