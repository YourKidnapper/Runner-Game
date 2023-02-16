using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6.5f;
    public Rigidbody2D player;
    Vector2 movement;
    public bool isInBattle = false;

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.tag = "Player";
        movement.x = Input.GetAxisRaw("Horizontal");
    }
    
        
    void FixedUpdate()
    {
        if(!isInBattle){
            player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

}
