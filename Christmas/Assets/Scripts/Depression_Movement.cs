using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;
using UnityEngine.UI;

public class Depression_Movement : MonoBehaviour
{
    public float speed = 5f;
    public Animator depressionAnimation;
    public Vector2 spawnPoint;
    public AIPath aiPath;
    public Level_Manager manager;
    public bool kill = false;
    public Player_Movement player;
    public audioManager am;
    public Animator panel;

    // Start is called before the first frame update
    void Start()
    {
        depressionAnimation = GetComponent<Animator>();
        manager = FindObjectOfType<Level_Manager>();
        player = FindObjectOfType<Player_Movement>();
        am = FindObjectOfType<audioManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        depressionAnimation.SetFloat("speed_horizontal", aiPath.desiredVelocity.x);
        depressionAnimation.SetFloat("speed_vertical", aiPath.desiredVelocity.y);
        depressionAnimation.SetFloat("speed", Mathf.Abs(aiPath.desiredVelocity.magnitude * speed));

        if(kill == true){
            kill = false;
            manager.depressionMode = false;
            player.transform.position = player.checkpoint;
            DateTime newTarget = System.DateTime.Now;
            manager.target = newTarget.Hour*60*60 + newTarget.Minute*60 + newTarget.Second + 15;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            am.Play("death");
            kill = true;
            panel.SetTrigger("swat");
            
        }
    }
}
