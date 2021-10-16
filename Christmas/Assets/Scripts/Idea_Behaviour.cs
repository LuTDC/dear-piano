using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idea_Behaviour : MonoBehaviour
{
    public bool collected = false;
    public bool colliding = false;
    public GameObject button;
    public Level_Manager manager;
    public Player_Movement player;
    public audioManager am;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        manager = FindObjectOfType<Level_Manager>();
        player = FindObjectOfType<Player_Movement>();
        am = FindObjectOfType<audioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(colliding == true && Input.GetButtonDown("interact")){
            manager.ideaCounter++;
            am.Play("idea");
            manager.txt.text = manager.ideaCounter + "/5";
            collected = true;
            this.gameObject.SetActive(false);
            colliding = false;
            player.checkpoint = transform.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            button.SetActive(true);
            colliding = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Player"){
            button.SetActive(false);
            colliding = false;
        }
    }
}
