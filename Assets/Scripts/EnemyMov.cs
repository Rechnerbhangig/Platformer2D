using System.Collections;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    public bool i;
    public float speed = 25;
    private Rigidbody2D rb2d;
    public float EnHp;
    public float maxSpeed = 25;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        if (i == true)
        {
            left();
        }
        else if (i == false)
        {
            right();
        }

    }
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.80f;

        rb2d.velocity = easeVelocity;

        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        i = !i;
    }

    public void right()
    {
        rb2d.AddForce((Vector2.right * speed));
    }
    public void left()
    {
        rb2d.AddForce((Vector2.left * speed));
    }
}


