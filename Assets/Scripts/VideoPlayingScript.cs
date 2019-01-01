using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoPlayingScript : MonoBehaviour {


    public Text vSyncText = null;
    private int CurrentVSC = 0;
    private string[] VSCOptions = new string[] { "A Sky Full of Stars", "All I can think about is you" };


    public VideoPlayer myVideo1;
    public VideoPlayer myVideo2;
    VideoPlayer chosenVideo;
    GameObject chosenSphere;
    int x;
    static int y;
    public GameObject sphere1;
    public GameObject sphere2;
    bool isPlaying;
    // Use this for initialization
    void Start () {

        chosenVideo = myVideo2;
        Debug.Log("I have set my chosen Video");
        isPlaying = false;

    }
	
	// Update is called once per frame
	void Update () {


    }

    public void VideoSwitcher(bool b)
    {
        CurrentVSC = (b) ? (CurrentVSC + 1) % 2 : (CurrentVSC != 0) ? (CurrentVSC - 1) % 2 : 1;
        vSyncText.text = VSCOptions[CurrentVSC];
        switch (CurrentVSC)
        {
            case 0:
                Debug.Log("currentVSC" + CurrentVSC);
                x = 0;
                break;
            case 1:
                Debug.Log("currentVSC" + CurrentVSC);
                x = 1;
                break;

        }
    }
    public void Apply()
    {

        y = x;
        Debug.Log("my chosen VideoVideoVideoVideoVideoVideoVideoVideoVideoVideo"+ y);
    }

    public void onButtonClick()
    {
        chooseVideo();
        Debug.Log("Chosen video is " + chosenVideo);
        Debug.Log("is Playing "+ isPlaying);

        if (isPlaying== false) //not Playing now
        {

                chosenSphere.SetActive(true);
                chosenVideo.Play();
                isPlaying = !isPlaying;

 
        }
        else if(isPlaying == true)
        { // make it play

                chosenVideo.Pause();
                isPlaying = !isPlaying;
                chosenSphere.SetActive(false);
            
       
        }

    }

    private void chooseVideo()
    {
        if (y == 1)
        {
            chosenVideo = myVideo1;
            chosenSphere = sphere1;

        }
        else 
        {

            chosenVideo = myVideo2;
            chosenSphere = sphere2;
        }
    }
}
