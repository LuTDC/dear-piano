using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class cutscneceManager : MonoBehaviour
{
    public Animator panel;
    public Text txt;
    private string sentence;
    int index = 0;
    char letter;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetTrigger("swat");
        //sentence = "I have to submit a new composition next month, but I don't even know from where to begin...\nMaybe I shoul walk around and see if a get some ideas...\nWish me luck,  Franz.";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("interact")) SceneManager.LoadScene("SampleScene");
    }
}
