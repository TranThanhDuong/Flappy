using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ViewManager : Singleton<ViewManager>
{
    public event Action<BaseView> OnSwitchNewView;
    public ViewIndex currenViewIndex;
    public BaseView currentView;
    public BaseView previousView;
    public Dictionary<ViewIndex, BaseView> dicView = new Dictionary<ViewIndex, BaseView>();
    public RectTransform anchorParent;

    void Start()
    {
        foreach(ViewIndex e in ViewConfig.viewIndices)
        {
            string nameView = e.ToString();
            GameObject goView = Instantiate(Resources.Load("View/" + nameView, typeof(GameObject))) as GameObject;
            goView.transform.SetParent(anchorParent, false);
            BaseView view = goView.GetComponent<BaseView>();
            dicView[e] = view;
            view.gameObject.SetActive(false);
        }
        OnSwitchView(currenViewIndex);
    }

    public void OnSwitchView(ViewIndex viewIndex, ViewParam param = null, Action callback = null)
    {
        if(currentView != null)
        {
            if (currentView.viewIndex == viewIndex)
                return;
            previousView = currentView;
            previousView.OnHide(() =>
            {
                previousView.gameObject.SetActive(false);

                currentView = dicView[viewIndex];
                OnSwitchNewView?.Invoke(currentView);

                currentView.gameObject.SetActive(true);
                currentView.OnSetup(param);
                currentView.OnShow(callback);
            });
        }
        else
        {
            currentView = dicView[viewIndex];
            OnSwitchNewView?.Invoke(currentView);

            currentView.gameObject.SetActive(true);
            currentView.OnSetup(param);
            currentView.OnShow(callback);
        }
    }
    public void OnSwitchPreviousView(ViewIndex viewIndex, ViewParam param = null, Action callback = null)
    {
        if(previousView != null)
        {
            BaseView temp = previousView;
            previousView = currentView;
            previousView.OnHide(() =>
            {
                previousView.gameObject.SetActive(false);

                currentView = temp;
                OnSwitchNewView?.Invoke(currentView);

                currentView.gameObject.SetActive(true);
                currentView.OnSetup(param);
                currentView.OnShow(callback);
            });
        }    
    }
}
