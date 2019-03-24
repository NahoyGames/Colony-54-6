using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject[] walls;
    [SerializeField] private Material buildingMat;
    [SerializeField] private Vector3 gridSize;
    [SerializeField] private float buildDistance;

    private Camera cam;

    private GameObject selected;
    private int index;

    private bool active = false;

    private void Start()
    {
        cam = Camera.main;

        SelectWall(walls[0]);
        active = true;
    }

    private void SelectWall(GameObject w)
    {
        Destroy(selected);
        wall = w;
        selected = Instantiate(w);
        foreach (MeshRenderer m in selected.GetComponentsInChildren<MeshRenderer>())
        {
            m.material = buildingMat;
        }
        selected.layer = 9;
        Destroy(selected.GetComponent<Destructible>());
    }

    private void Update()
    {
        if (active)
        {
            // Distance of Building
            float dist;

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, buildDistance))
            {
                dist = Mathf.Max(hit.distance - (hit.normal * gridSize.magnitude).magnitude, cam.nearClipPlane);
            }
            else
            {
                dist = buildDistance;
            }

            // The world position of the cursor
            Vector3 cursorPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, dist));

            // THe world position of the cursor, adjusted to the grid
            Vector3 gridCursorPos = new Vector3(cursorPos.x - (cursorPos.x % gridSize.x),
                                                cursorPos.y - (cursorPos.y % gridSize.y),
                                                cursorPos.z - (cursorPos.z % gridSize.z));

            if (Physics.Raycast(transform.position, gridCursorPos - transform.position, out hit, dist, 1 << 10))
            {
                Debug.Log("Changed!");
                /*dist -= gridSize.magnitude;

                cursorPos = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, dist));
                gridCursorPos = new Vector3(cursorPos.x - (cursorPos.x % gridSize.x),
                                                cursorPos.y - (cursorPos.y % gridSize.y),
                                                cursorPos.z - (cursorPos.z % gridSize.z));*/

                gridCursorPos = hit.collider.gameObject.transform.position - (hit.normal * gridSize.x);
            }

            selected.transform.position = gridCursorPos;

            if (Input.GetButtonDown("Fire3"))
            {
                Instantiate(wall, gridCursorPos, selected.transform.rotation);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!Input.GetAxis("Switch").Equals(0))
        {
            index += (int)Input.GetAxis("Switch");

            if (index >= walls.Length)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = walls.Length - 1;
            }

            SelectWall(walls[index]);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (active)
            {
                active = false;
                Destroy(selected);
            }
            else
            {
                active = true;

                SelectWall(walls[index]);
            }
        }
    }
}
