using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 movement;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        player.MovePosition(player.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
