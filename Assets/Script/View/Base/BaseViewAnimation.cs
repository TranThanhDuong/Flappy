using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BaseViewAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void OnShowAnimation(Action callback)
    {
        callback?.Invoke();
    }
    public virtual void OnHideAnimation(Action callback)
    {
        callback?.Invoke();
    }
}
