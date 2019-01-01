using UnityEngine;
using System.Collections;

static class bl_UMGExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bl_UMGWindow GetWindow(this GameObject go)
    {

        return go.GetComponent<bl_UMGWindow>();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="go"></param>
    /// <param name="levelname"></param>
    /// <param name="preview"></param>
    /// <param name="levelNeeded"></param>
    public static void SendLevelInfo(this GameObject go, string levelname, Sprite preview,int levelNeeded)
    {
        bl_UMGLevel l = go.GetComponent<bl_UMGLevel>();
        l.GetInfo(levelname, preview, levelNeeded);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="go"></param>
    /// <returns></returns>
    public static bl_UMGLevel GetLevelScript(this GameObject go)
    {

        return go.GetComponent<bl_UMGLevel>();
    }
}