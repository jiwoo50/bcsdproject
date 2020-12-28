using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecontrol : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        position.y = position.y + 10.0f * vertical * Time.deltaTime;
        Vector2 move = new Vector2(horizontal, vertical);
        Vector2 lookDirection = new Vector2(0, 0);
        lookDirection.Set(move.x, move.y);
        lookDirection.Normalize();
        animator.SetFloat("MOVE X", lookDirection.x);
        animator.SetFloat("MOVE Y", lookDirection.y);/*
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            
        }*/
        
        transform.position = position;
    }
    
}
