using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private Vector3 gridSize;

    private Camera cam;


    private void Start()
    {
        cam = Camera.main;
    }


    private void Update()
    {
        // The world position of the cursor
        Vector3 cursorPos = cam.ScreenToWorldPoint(Vector3.forward * cam.nearClipPlane);

        Vector3 gridCursorPos = new Vector3(cursorPos.x - (cursorPos.x % gridSize.x),
                                            cursorPos.x - (cursorPos.x % gridSize.x),
                                            cursorPos.x - (cursorPos.x % gridSize.x));

    }
}
