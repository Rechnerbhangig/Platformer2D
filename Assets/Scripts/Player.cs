using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    //Floats
    public float maxSpeed = 5;
    public float speed = 50;
    public float jumpPower = 500;

    //Boleans
    public bool grounded;
    public bool canDoubleJump;
    public bool wallJump;
    public bool hWallJump;
    public bool fall;

    //Stats
    public int curHealth;
    public int maxHealth = 5;
    public int coin = 0;
    //References
    private Rigidbody2D rb2d;
    private Animator anim;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
        rb2d = gameObject.GetComponent<Rigidbody2D>();

        curHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("KnockBack"))
        {
            rb2d.AddForce(Vector2.up * 350);
        }
        if (col.CompareTag("Coin"))
        {
            coin++;
        }
        
    }
    void Update()
    {

        if(rb2d.velocity.y >= 8 && fall)
        {
            Damage(5);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;

            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                rb2d.AddForce(Vector2.up * jumpPower);
            }
            else if (wallJump)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                wallJump = false;
            }

        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.80f;

        float h = Input.GetAxis("Horizontal");


        //fake Friction / easing the x speed of our player
        if (grounded)
        {
            rb2d.velocity = easeVelocity;
        }

        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        //Limiting the speed of the player
        rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
    }

    void Die()
    {
        //Restart
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        StartCoroutine(FlashRed(3, 0.1f));
    }

    public void KnockbackSingle(float knockbackPwr, Vector3 knockbackDir)
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(new Vector3(knockbackDir.x * -50, knockbackPwr, 0));
    }

    public IEnumerator FlashRed(int times, float interval)
    {
        int index = 0;
        while (index < times)
        {
            index++;
            spriteRenderer.material.color = new Color(1f, 0.5f, 0.5f);
            yield return new WaitForSeconds(interval);
            spriteRenderer.material.color = Color.white;
            yield return new WaitForSeconds(interval);
        }
    }
}