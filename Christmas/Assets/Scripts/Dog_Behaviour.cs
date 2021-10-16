using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dog_Behaviour : MonoBehaviour
{
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
            manager.hugCounter++;
            am.Play("out");
            manager.depressionMode = false;
            DateTime newTarget = System.DateTime.Now;
            manager.target = newTarget.Hour*60*60 + newTarget.Minute*60 + newTarget.Second + 20;
            //player.playerAnimation.SetBool("hug", true);
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
