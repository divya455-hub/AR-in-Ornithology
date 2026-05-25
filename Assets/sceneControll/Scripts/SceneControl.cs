using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public string slam;
    public string imageTracker;
    public string imageTrackerCustom;
    public string Menu;
    public string ARGaze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void slamScene()
    {
        SceneManager.LoadScene(slam);
    }
    public void imageTrackerScene()
    {
        SceneManager.LoadScene(imageTracker);
    }
    public void CustomImageTrackerScene()
    {
        SceneManager.LoadScene(imageTrackerCustom);
    }
    public void MenuScene()
    {
        SceneManager.LoadScene(Menu);
    }
    public void ARGazeScene()
    {
        SceneManager.LoadScene(ARGaze);
    }
}
