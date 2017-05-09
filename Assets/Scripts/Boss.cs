using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public float speed = 15f;
    public float maxSpeed = 5;
    private Rigidbody2D rb2d;
	void Start ()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        rb2d.AddForce(Vector2.right * speed);
	}
    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.80f;

        rb2d.AddForce((Vector2.right * speed));
        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
    }
}
