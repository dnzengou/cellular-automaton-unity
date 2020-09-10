using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public bool bDragging;
    Vector3 oldPos;
    Vector3 panOrigin;
    float panSpeed;
    _GM gameManager;

    // Start is called before the first frame update
    void Start()
    {

       gameManager = GameObject.Find("GameManager").GetComponent<_GM>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetAxis("Mouse ScrollWheel") > 0 & this.gameObject.GetComponent<Camera>().orthographicSize > 1.25)
        {

            this.gameObject.GetComponent<Camera>().orthographicSize--;

        } else if (Input.GetAxis("Mouse ScrollWheel") < 0 & this.gameObject.GetComponent<Camera>().orthographicSize < (gameManager.y + 0.5f))
        {

            this.gameObject.GetComponent<Camera>().orthographicSize++;

        }

        panSpeed = Camera.main.orthographicSize * 2.5f;

        if (Input.GetMouseButtonDown(1))
        {
            bDragging = true;
            oldPos = transform.position;
            panOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);                    //Get the ScreenVector the mouse clicked
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - panOrigin;    //Get the difference between where the mouse clicked and where it moved
            transform.position = oldPos + -pos * panSpeed;                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
        }

        if (Input.GetMouseButtonUp(1))
        {
            bDragging = false;
        }

    }
}
