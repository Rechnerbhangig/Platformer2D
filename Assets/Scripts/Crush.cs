using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour {

    public bool grounded;

    private Player player;

	void Start ()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        grounded = true;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        grounded = false;
    }
    void Update ()
    {

		if (player.grounded && grounded)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
