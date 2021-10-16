using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_Behaviour : MonoBehaviour
{
    public audioManager am;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Start");
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlaySound(){
        am.Play("idea");
    }
}
