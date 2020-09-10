using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{

    int blockCnt;

    int tX, tY, bX, bY, lX, lY, rX, rY, tlX, tlY, trX, trY, blX, blY, brX, brY;


    // Start is called before the first frame update
    void Start()
    {

        // My Block
        int myX = System.Int32.Parse(this.gameObject.name.Substring(0, this.gameObject.name.IndexOf(",")));
        int myY = System.Int32.Parse(this.gameObject.name.Substring(this.gameObject.name.IndexOf(",") + 1, this.gameObject.name.Length - this.gameObject.name.IndexOf(",") - 1));


        // Block Above
        tX = myX;
        tY = myY + 1;

        // Block Below
        bX = myX;
        bY = myY - 1;

        // Block Left
        lX = myX - 1;
        lY = myY;

        // Block Right
        rX = myX + 1;
        rY = myY;

        // Block TL
        tlX = myX - 1;
        tlY = myY + 1;

        // Block TR
        trX = myX + 1;
        trY = myY + 1;

        // Block BL
        blX = myX - 1;
        blY = myY - 1;

        // Block BR
        brX = myX + 1;
        brY = myY - 1;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
