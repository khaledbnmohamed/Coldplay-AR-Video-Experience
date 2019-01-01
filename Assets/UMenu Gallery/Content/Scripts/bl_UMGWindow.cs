using UnityEngine;
using System.Collections;

public class bl_UMGWindow : MonoBehaviour {

    public Animation Anim;
    public string StartAnim = "Start";
    public bool useReverse = true;
    public string HideAnim = "Hide";

    /// <summary>
    /// 
    /// </summary>
    void OnEnable()
    {
        if (Anim != null)
        {
            Anim[StartAnim].time = 0;
            Anim[StartAnim].speed = 1.0f;
            Anim.Play(StartAnim);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Hide()
    {
        if (Anim != null)
        {
            if (!useReverse)
            {
                Anim.Play(HideAnim);
            }
            else
            {
                Anim[StartAnim].time = Anim[StartAnim].length;
                Anim[StartAnim].speed = -1.0f;
                Anim.Play(StartAnim);
                StartCoroutine(Desactive());
            }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public void AutoDesactive()
    {
        this.gameObject.SetActive(false);
    }

    IEnumerator Desactive()
    {
       float s =  Anim[StartAnim].length;
       yield return new WaitForSeconds(s);
       AutoDesactive();

    }
}