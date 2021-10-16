using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Piano_Behaviour : MonoBehaviour
{
    public Level_Manager manager;
    public GameObject button; 
    public bool finished = false;
    public bool contact = false;
    public finalOption f;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Level_Manager>();
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.ideaCounter == 5) finished = true;

        if(finished == true){
            button.SetActive(true);
            if(contact == true && Input.GetButtonDown("interact")){
                if(manager.hugCounter > 4){
                    //SceneManager.LoadScene("Ending01");
                    f.final = 1;
                }
                else{
                    //SceneManager.LoadScene("Ending02");
                    f.final = 2;
                }
                SceneManager.LoadScene("pianoFinal");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player") contact = true;
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player") contact = false;
    }
}
