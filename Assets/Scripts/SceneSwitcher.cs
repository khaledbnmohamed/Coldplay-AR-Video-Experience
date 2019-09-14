using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public string scenename;
    bool Loaded = false;

    Scene sceneToLoad;
    Scene sceneToUnload;
 
    // Use this for initialization


   public  void OnButtonClick()
    {


            StartCoroutine(ChangeScene());

            Debug.Log("I clicked back");
        
    }
 


    IEnumerator ChangeScene()
    {
            Debug.Log("sceneName to load: " + scenename);

            SceneManager.LoadScene(scenename);
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
        SceneManager.UnloadSceneAsync(sceneToUnload);


    }

    // Update is called once per frame
    void Update()
    {

    }
}