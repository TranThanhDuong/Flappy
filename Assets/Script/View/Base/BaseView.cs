using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseView : MonoBehaviour
{
    public ViewIndex viewIndex;
    public string nameView;

    [SerializeField]
    protected BaseViewAnimation baseViewAnimation;

    private void Awake()
    {
        baseViewAnimation = gameObject.GetComponentInChildren<BaseViewAnimation>();
        
    }
    public void OnAwake()
    {

    }    

    public virtual void OnSetup(ViewParam param)
    { }
    
    public void OnShow(Action callback)
    {
        baseViewAnimation.OnShowAnimation(() =>
        {
            OnShowView();
            callback?.Invoke();
        });
    }
    public void OnHide(Action callback)
    {
        baseViewAnimation.OnHideAnimation(() =>
        {
            OnHideView();
            callback?.Invoke();
        });
    }

    public virtual void OnShowView()
    { }   
    
    public virtual void OnHideView()
    { } 
}
