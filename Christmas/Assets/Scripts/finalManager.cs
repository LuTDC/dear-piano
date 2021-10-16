using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalManager : MonoBehaviour
{
    public finalOption f;
    public Camera camera;
    public Animator panel;
    public audioFinal af;
    music m;

    void Start(){
        af = FindObjectOfType<audioFinal>();
        m = af.Play("piano");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("interact")){
            if(f.final == 1) SceneManager.LoadScene("Ending01");
            else SceneManager.LoadScene("Ending02");
        }

        camera.orthographicSize = camera.orthographicSize + 1*Time.deltaTime;

        if(camera.orthographicSize > 21f) panel.SetTrigger("swat");

        if(camera.orthographicSize > 28f){
            if(f.final == 1) SceneManager.LoadScene("Ending01");
            else SceneManager.LoadScene("Ending02");
        }

        m.source.volume -= 0.1f*Time.deltaTime;
    }
}
