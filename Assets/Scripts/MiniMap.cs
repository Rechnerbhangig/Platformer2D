using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

    public GameObject Minimap;

    private bool OpenMap = true;
    void Start()
    {
        Minimap.SetActive(true);
    }

    void Update()
    {
        if (Input.GetButtonDown("Minimap"))
        {
            OpenMap = !OpenMap;
        }

        if (OpenMap)
        {
            Minimap.SetActive(true);
        }

        if (!OpenMap)
        {
            Minimap.SetActive(false);
        }
    }
}
