using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    public bool isWhite = false;
    public int soL = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (GameObject.Find("GameManager").GetComponent<_GM>().isStarted == false)
        {
            if (Input.GetMouseButtonDown(0) & isWhite == false)
            {
                Debug.Log(this.gameObject.name);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                isWhite = true;
                soL = 1;

            }
            else if (Input.GetMouseButtonDown(0) & isWhite == true)
            {

                Debug.Log(this.gameObject.name);
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                isWhite = false;
                soL = 0;

            }
        }

    }

}
