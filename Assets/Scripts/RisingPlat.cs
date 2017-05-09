using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlat : MonoBehaviour {

    public float speed = 2;
	void FixedUpdate ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime);
    }
}
