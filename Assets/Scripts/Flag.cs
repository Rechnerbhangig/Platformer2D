using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    private Player player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        
        if (col.CompareTag("Player") && player.coin >= 1)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
 