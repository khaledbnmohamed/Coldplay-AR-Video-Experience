using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;

public class VideoPlayingScript : MonoBehaviour {


    public Text vSyncText = null;
    private int CurrentVSC = 0;
    private string[] VSCOptions = new string[] { "All I can think about is you", "A Sky Full of Stars", "Hymn for Weekend", "Something Like this" };


    public VideoPlayer myVideo1;
    public VideoPlayer myVideo2;
    public VideoPlayer myVideo3;
    public VideoPlayer myVideo4;

    VideoPlayer chosenVideo;
    GameObject chosenSphere;
    int x;
    static int y;
    public GameObject sphere1;
    public GameObject sphere2;
    public GameObject sphere3;
    public GameObject sphere4;

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
        if (b)
        {
            CurrentVSC = (CurrentVSC + 1) % 4;
        }
        else {

            if(CurrentVSC != 0)
              {
                CurrentVSC = (CurrentVSC - 1) % 4;

            }
            else
            {
                CurrentVSC = 3;
            }
        }

        

        vSyncText.text = VSCOptions[CurrentVSC];
        Debug.Log("currentVSC" + CurrentVSC);
        x = CurrentVSC;


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
        switch (y)
        {

            case 0:
                chosenVideo = myVideo1;
                chosenSphere = sphere1;
                break;
            case 1:
                chosenVideo = myVideo2;
                chosenSphere = sphere2;
                break;
            case 2:
                chosenVideo = myVideo3;
                chosenSphere = sphere3;
                break;
            case 3:
                chosenVideo = myVideo4;
                chosenSphere = sphere4;
                break;

        }
    }
}
