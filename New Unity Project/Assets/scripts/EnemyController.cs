using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public ParticleSystem SmokeEffects;
    bool broken=false;
    private new Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        if (!broken)
        {
            return;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
            
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed;
            animator.SetFloat("MoveX", direction);
            animator.SetFloat("MoveY", 0);
        }
        if (!broken)
        {
            return;
        }
        rigidbody2D.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        rubycontroller player = other.gameObject.GetComponent<rubycontroller>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
    public void Fix()
    {
        broken = true;
        rigidbody2D.simulated = false;
        animator.SetTrigger("Fixed");
        SmokeEffects.Stop();
    }
}
