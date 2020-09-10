using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _GM : MonoBehaviour
{

    public int x;
    public int y;

    public int i;

    public GameObject myPrefab;

    public Camera mainCam;

    public bool isStarted = false;

    int blockCnt;

    int tX, tY, bX, bY, lX, lY, rX, rY, tlX, tlY, trX, trY, blX, blY, brX, brY;

    // Start is called before the first frame update
    void Start()
    {

        for(int i = -x; i < x + 1; i++)
        {
            for (int o = y; o > -y - 1; o--)
            {

                GameObject newBox = (GameObject)Instantiate(myPrefab, new Vector3(i, o, 0), Quaternion.identity);

                newBox.name = i + "," + o;

            }
        }

        mainCam.orthographicSize = ((y + 0.5f));

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if (isStarted == false)
            {

                isStarted = true;
                Debug.Log("running");

                StartCoroutine(Activate());

                    } else
            {

                isStarted = false;
                Debug.Log("stopped");

            }

        }

    }

    IEnumerator Activate()
    {

        List<GameObject> allObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(allObjects);

        do
        {


            yield return new WaitForSeconds(0.0f);

            for (int i = 2; i < allObjects.Count; ++i)
            {

                Debug.Log(allObjects[i].gameObject.name);
                GameObject gameObject = allObjects[i];
                {
                    blockCnt = 0;
                    int myX = System.Int32.Parse(gameObject.name.Substring(0, gameObject.name.IndexOf(",")));
                    int myY = System.Int32.Parse(gameObject.name.Substring(gameObject.name.IndexOf(",") + 1, gameObject.name.Length - gameObject.name.IndexOf(",") - 1));


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

                    if (GameObject.Find(tX + "," + tY) != null)
                    {
                        if (GameObject.Find(tX + "," + tY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(bX + "," + bY) != null)
                    {
                        if (GameObject.Find(bX + "," + bY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(lX + "," + lY) != null)
                    {
                        if (GameObject.Find(lX + "," + lY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(rX + "," + rY) != null)
                    {
                        if (GameObject.Find(rX + "," + rY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(tlX + "," + tlY) != null)
                    {
                        if (GameObject.Find(tlX + "," + tlY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(trX + "," + trY) != null)
                    {
                        if (GameObject.Find(trX + "," + trY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(blX + "," + blY) != null)
                    {
                        if (GameObject.Find(blX + "," + blY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (GameObject.Find(brX + "," + brY) != null)
                    {
                        if (GameObject.Find(brX + "," + brY).GetComponent<SpriteRenderer>().color == Color.white)
                        {

                            blockCnt++;

                        }
                    }

                    if (blockCnt < 2 & gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                    {


                        gameObject.GetComponent<Click>().soL = 0;

                    }
                    else if ((blockCnt == 2 || blockCnt == 3) & gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                    {

                        gameObject.GetComponent<Click>().soL = 1;

                    }
                    else if (blockCnt > 3 & gameObject.GetComponent<SpriteRenderer>().color == Color.white)
                    {


                        gameObject.GetComponent<Click>().soL = 0;

                    }
                    else if (blockCnt == 3 & gameObject.GetComponent<SpriteRenderer>().color == Color.black)
                    {


                        gameObject.GetComponent<Click>().soL = 1;
                    }
                }
            }

            for (int i = 2; i < allObjects.Count; ++i)
            {
                Debug.Log(allObjects[i].gameObject.name);
                GameObject gameObject = allObjects[i];
                {

                    if (gameObject.GetComponent<Click>().soL == 1)
                    {

                        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                        gameObject.GetComponent<Click>().isWhite = true;

                    }
                    else if (gameObject.GetComponent<Click>().soL == 0)
                    {

                        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                        gameObject.GetComponent<Click>().isWhite = false;

                    }

                }
            }



        } while (!Input.GetKeyDown(KeyCode.Space));

    }

}
