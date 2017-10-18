using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    public int i, j;
    public bool died = false;
    public int Challenge_type;
    float time;
    public float[] px = new float[50];
    public float[] py = new float[50];
    public float[] pz = new float[50];
    public GameObject G_Over;
    public GameObject AllStairs;
    // Use this for initialization
    void Start()
    {
      //  GameObject.Find("Panel").SetActive(false);
        i = -1;
        for (j = 0; j < 50; j++)
        {
            px[j] = GameObject.Find("Cube (" + j + ")").transform.position.x;
            py[j] = GameObject.Find("Cube (" + j + ")").transform.position.y;
            pz[j] = GameObject.Find("Cube (" + j + ")").transform.position.z;
        }
        Challenge(); 
    }
    // Update is called once per frame
    void Update()
    {

		Challenge(); 

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * 100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 10 * Time.deltaTime);
        }


        //time += Time.deltaTime;
        if (i > -1 && i < 40 && died == false)
        {
            GameObject.Find("Cube (" + i + ")").transform.Translate(Vector3.down * 10 * Time.deltaTime);

        }
        if (i > -1 && i < 40 && died == false&&i !=-1)
        {
            if ((GameObject.Find("Cube (" + (i+1) + ")").transform.position.y) - transform.position.y > 5)
            {
                print("true!!");
                G_Over.SetActive(true);
                AllStairs.SetActive(false);
                died = true;
            }
        }
                if (transform.position.y >= 45)
                {
                    print("Move");
                    if (i > -1 && i < 50)
                    {
                        print("Recover");
                        for (int k = 0; k < 50; k++)
                        {
                            GameObject.Find("Cube (" + k + ")").transform.position = new Vector3(px[k], py[k], pz[k]);
                        }
                transform.position = new Vector3(transform.position.x, 2, 0);
                        i = -1;
                print("iiiiiii");
                    }
                }



    
    

    }



		private void OnCollisionEnter(Collision collision)
        {

            if (collision.collider.CompareTag("up") && Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }

       // GameObject.Find("Cube (" + i + ")").transform.position = new Vector3(10000, 10000, 10000);
           

        }

        private void OnCollisionExit(Collision col)
        {
        for (int k = 0; k < 50; k++)
        {
            if (col.gameObject.name == "Cube (" + k + ")"&&(col.gameObject.name != "Cube (" + 40 + ")"))
            {
                i = k;
            }
        }
        }


	public void Restart()
	{
        AllStairs.SetActive(true);
		for (int k = 0; k < 50; k++)
		{
			GameObject.Find("Cube (" + k + ")").transform.position = new Vector3(px[k], py[k], pz[k]);
		}
    		G_Over.SetActive(false);
            transform.rotation = Quaternion.identity;
            transform.position = new Vector3(0, 3, 0);
            i = -1;
            died = false;
            print("start");
        }

    public void Challenge(){
        if (Input.GetKeyDown(KeyCode.L))
        {
            Challenge_type = (int)Random.Range(0, 5);
            print(Challenge_type); 
            transform.position = new Vector3(0, 3, 0);
        }
    }
     
}