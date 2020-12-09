﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{

    public Animator anim;
    public string sceneToLoad;

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Team Intro Scene")
        {
            if (Input.GetMouseButtonDown(0))
            {
                FadeToLevel(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("FadeOut");
        SceneManager.LoadScene(sceneToLoad);
    }

    //Used to fade between scenes
    public void FadeToLevel(string sceneName)
    {
        sceneToLoad = sceneName;
        anim.SetTrigger("FadeOut");

    }

    //Used for menu buttons -> No need to fade
    public void GoToScene(string sceneName)
    {
        sceneToLoad = sceneName;
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        FadeToLevel(sceneToLoad);
    }
}
