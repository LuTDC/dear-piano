using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public int hugCounter = 0;
    public int ideaCounter = 0;
    public bool depressionMode = false;
    public GameObject depression;
    public Camera camera;
    Bloom bloom;
    Vignette vignette;
    public PostProcessVolume volume;
    public Idea_Behaviour[] ideias = new Idea_Behaviour[5];
    public int target;
    public Text txt;
    public GameObject shift;
    bool isFirstShift = true;
    Depression_Movement depMove;
    bool fade = false;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out vignette);
        depression.SetActive(false);
        bloom.intensity.value = 0f;
        vignette.intensity.value = 0f;
        DateTime newTarget = System.DateTime.Now;
        target = newTarget.Hour*60*60 + newTarget.Minute*60 + newTarget.Second + 30;
        txt.text = ideaCounter + "/5";
        shift.SetActive(false);
        depMove = FindObjectOfType<Depression_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(depressionMode == true){
            depression.SetActive(true);
            bloom.intensity.value = 59f;
            vignette.intensity.value = 0.59f;
            for(int i = 0; i < 5; i++) ideias[i].gameObject.SetActive(false);
            
            if(Input.GetKey(KeyCode.LeftShift)) shift.SetActive(false);
            else if(isFirstShift){
                shift.SetActive(true);
                isFirstShift = false;
                fade = true;
            }
        }
        else{
            shift.SetActive(false);
            depression.SetActive(false);
            fade = false;
            bloom.intensity.value = 0f;
            vignette.intensity.value = 0f;
            for(int i = 0; i < 5; i++){
                if(ideias[i].collected == false) ideias[i].gameObject.SetActive(true);
            }
        }
        
        DateTime newNow = System.DateTime.Now;
        int now = newNow.Hour * 60 * 60 + newNow.Minute * 60 + newNow.Second;

        if(target - now <= 0 && depressionMode == false && ideaCounter < 5) depressionMode = true;
    }
}
