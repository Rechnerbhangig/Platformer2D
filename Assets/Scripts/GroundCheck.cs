using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    public const float fallDamageThreshold = 4;
    private Player player;
    float launchHeight;


    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        player.grounded = true;
        float fallHeight = launchHeight - player.transform.position.y;
        int dmg = (int)(fallHeight / 3);
        if (dmg > 0)
        {
            player.Damage(dmg);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        player.grounded = false;
        launchHeight = player.transform.position.y;
    }
}