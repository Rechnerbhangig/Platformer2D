using UnityEngine;
using System.Collections;

public class WallJump : MonoBehaviour
{

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    //trigger activates only once... if i jump on the wall i cant do so again unless i leave and comeback
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("WallJump"))
        {
            player.wallJump = true;
            //player.hWallJump = false;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("WallJump") && player.grounded)
        {
            player.wallJump = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("WallJump"))
        {
            player.wallJump = false;
            //player.hWallJump = false;
        }
    }
}