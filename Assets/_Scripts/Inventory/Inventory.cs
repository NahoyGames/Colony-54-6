using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Canvas cv;
    public bool shown = true;
    // Start is called before the first frame update
    void Start()
    {
        cv = GetComponent<Canvas>();
    }
    void Open() {
        cv.enabled = true;
        shown = true;
    }
    void Close() {
        Debug.Log("Hey");
        cv.enabled = false;
        shown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Middle")) {
            if (shown == true)
            { 
            Close(); 
            }
            else
            {
                Open(); 
             }
        }
    }

}
