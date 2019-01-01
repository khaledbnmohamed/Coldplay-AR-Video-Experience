using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bl_UMGLevel : MonoBehaviour {

    public string LevelName = "Level";
    public Text NameText = null;
    public Image PreviewImage = null;
    public Image LockImage;
    public bool Unlock = true;
    /// <summary>
    /// Level(XP,Kills,Point,etc...) needed for unlock this level
    /// </summary>
    public int LevelNeeded = 0;
    [Space(5)]
    public Color SelectColor = new Color(0.2f, 0.2f, 0.2f, 0.9f);
    [HideInInspector]
    public bool isSelect = false;
    //Private
    private Color DefaultColor;
   

    void Start()
    {
        DefaultColor = PreviewImage.color;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Select()
    {
        if (!Unlock)//if not unlocked, not can select
            return;

        isSelect = !isSelect;
        if (isSelect)
        {
            PreviewImage.color = SelectColor;
            bl_UMGManager.instance.DelectAllOther(LevelName);
        }
        else
        {
            PreviewImage.color = DefaultColor;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Lname"></param>
    /// <param name="preview"></param>
    /// <param name="LNeeded"></param>
    public void GetInfo(string Lname, Sprite preview,int LNeeded)
    {
        this.LevelName = Lname;
        PreviewImage.sprite = preview;
        LevelNeeded = LNeeded;
        NameText.text = LevelName;
        if (LevelNeeded > bl_UMGManager.PlayerLevel)
        {
            Unlock = false;
            if (LockImage != null)
            {
                LockImage.gameObject.SetActive(true);
            }
        }
        else
        {
            Unlock = true;
            if (LockImage != null)
            {
                LockImage.gameObject.SetActive(false);
            }
        }
    }
}
