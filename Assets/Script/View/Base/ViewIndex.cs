using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    StartView = 0,
    GameView,
    EndView,
    CountDownView,
}
public class ViewConfig
{
    public static ViewIndex[] viewIndices =
    {
        ViewIndex.StartView,
        ViewIndex.GameView,
        ViewIndex.EndView,
        ViewIndex.CountDownView,
    };
}

public class ViewParam
{

}