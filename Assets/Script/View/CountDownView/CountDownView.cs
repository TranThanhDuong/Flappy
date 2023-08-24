using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownView : BaseView
{
    public TextMeshProUGUI text;
    private float countdown = 0;
    public override void OnSetup(ViewParam param)
    {
        countdown = 3;
        base.OnSetup(param);
    }
    public void Update()
    {
        countdown -= Time.deltaTime;
        text.text = "" + (int)countdown;

        if(countdown <= 0)
            ViewManager.instances.OnSwitchView(ViewIndex.GameView);
    }
}
