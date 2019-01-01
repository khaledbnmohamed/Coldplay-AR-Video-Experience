using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class bl_UMGManager : MonoBehaviour {


    public string scenename;
    bool Loaded = false;

    Scene sceneToLoad;
    Scene sceneToUnload;
  
    // Use this for initialization


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }



    IEnumerator ChangeScene()
    {
        Debug.Log("sceneName to load: " + scenename);

        SceneManager.LoadScene(scenename, LoadSceneMode.Additive);
        sceneToLoad = SceneManager.GetSceneByName(scenename);
        sceneToUnload = SceneManager.GetActiveScene();

        //OnSceneLoaded(sceneToLoad, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;


        yield return null;


        //  var spawnPoint = GameObject.FindWithTag("SpawnPoint").transform;
        // other.transform.position = spawnPoint.position;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Loaded = true;
        SceneManager.UnloadSceneAsync(0);
        Debug.Log("Scene " + sceneToLoad + " Loaded");

    }

    /// <summary>
    /// Change this var with your own player level or points
    /// </summary>
    public static int PlayerLevel = 10;
    /// <summary>
    /// The level to load
    /// </summary>
    public static string LevelSelect = "";

    public List<GameObject> Windows = new List<GameObject>();
    [Space(5)]
    public List<LevelInfo> Levels = new List<LevelInfo>();
    public GameObject LevelPrefab;
    public Transform LevelPanel = null;
    [Space(5)]
    public GameObject m_CurrentWindow = null;

    [HideInInspector]
    public List<bl_UMGLevel> LevelsCache = new List<bl_UMGLevel>();
    private static bl_UMGManager _instance;
    private string LevelToLoad = "";

//Get singleton
    public static bl_UMGManager instance
{
    get
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<bl_UMGManager>();
        }
        return _instance;
    }
}
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        ChangeWindow(0);
        //If current window disabled, then enabled
        if (m_CurrentWindow != null && !m_CurrentWindow.activeSelf)
        {
            m_CurrentWindow.SetActive(true);
        }
    }

    /// <summary>
    /// Change window 
    /// </summary>
    /// <param name="id"></param>
    public void ChangeWindow(int id)
    {
        if (id <= Windows.Count && Windows[id] != null)
        {
            if (Windows[id] == m_CurrentWindow)
                return;

            Windows[id].SetActive(true);
            //Hide current window
            if (m_CurrentWindow != null)
            {
                m_CurrentWindow.GetWindow().Hide();
            }
            m_CurrentWindow = Windows[id];
        }
    }
    /// <summary>
    /// Instance all levels in list in the list panel
    /// </summary>

    /// <summary>
    /// 
    /// </summary>
    public void DelectAllOther(string level)
    {
        for (int i = 0; i < LevelsCache.Count; i++)
        {
            if (LevelsCache[i].LevelName != level)
            {
                LevelsCache[i].isSelect = true;
                LevelsCache[i].Select();
            }
        }
        LevelToLoad = level;
    }
    /// <summary>
    /// 
    /// </summary>
    public void LoadLevel()
    {
        if (LevelToLoad != string.Empty)
        {
            Application.LoadLevel(LevelToLoad);
        }
        else
        {
            Debug.Log("Select a level to load");
        }
    }

    public void  onButtonPlayClicke()
    {

        StartCoroutine(ChangeScene());

    }
    [System.Serializable]
    public class LevelInfo
    {
        public string LevelName = "Level";
        public Sprite Preview = null;
        public int LevelNeeded = 1;
    }
}