using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StartViewAnimation : BaseViewAnimation
{
    public Animator animator;
    private Action callback;
    // Start is called before the first frame update
    public override void OnHideAnimation(Action callback)
    {
        this.callback = callback;
        animator.SetTrigger("OnShow");
        StartCoroutine(OnShowDone());
    }

    public override void OnShowAnimation(Action callback)
    {
        this.callback = callback;
        animator.SetTrigger("OnHide");
        StartCoroutine(OnHideDone());
    }

    IEnumerator OnShowDone()
    {
        yield return new WaitForSeconds(1);
        callback?.Invoke();
    }
    IEnumerator OnHideDone()
    {
        yield return new WaitForSeconds(1);
        callback?.Invoke();
    }
}
