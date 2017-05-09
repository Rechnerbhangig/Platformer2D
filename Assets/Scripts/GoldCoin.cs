using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour
{
    public GameObject Coin1;
    public GameObject Coin;
    private Player player;

    void Start()
    {
        Coin1.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Coin.SetActive(false);
            Coin1.SetActive(true);
        }
    }

}
