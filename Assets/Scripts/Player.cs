using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public int leave_f, j;//i是代表剛離開的階梯
    public int c;//距離下個關卡
    public int live = 5;
    public Text live_T;
    public bool died = false;//生死狀態
    public bool JumpActive = true;
    public float[] px = new float[50];//儲存階梯預設位置
    public float[] py = new float[50];
    public float[] pz = new float[50];
    public GameObject G_Over;//死亡畫面
    public GameObject AllStairs;//所有階梯
    public GameObject Middle_floor5;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        leave_f = -1;
        for (j = 0; j < 50; j++)
        {
            px[j] = GameObject.Find("Cube (" + j + ")").transform.position.x;
            py[j] = GameObject.Find("Cube (" + j + ")").transform.position.y;
            pz[j] = GameObject.Find("Cube (" + j + ")").transform.position.z;
        }
    }

    void Update()
    {


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

        if (Input.GetKeyDown(KeyCode.Space) && JumpActive == true)
		{
            rb.AddForce(0, 4000, 0);
            print("Jump");
            JumpActive = false;
		}

        if (leave_f > -1 && leave_f < 40 && died == false)
        {
            GameObject.Find("Cube (" + leave_f + ")").transform.Translate(Vector3.down * 10 * Time.deltaTime);

        }
        if (leave_f > -1 && leave_f < 40 && died == false&&leave_f !=-1)
        {
            if ((GameObject.Find("Cube (" + (leave_f+1) + ")").transform.position.y) - transform.position.y > 30)
            {
                print("died!!");
                G_Over.SetActive(true);
                live_T.text = "";
                AllStairs.SetActive(false);
                died = true;
            }
        }
                if (transform.position.y >= 45)//循環
                {
                    Middle_floor5.SetActive(true); 
                    print("Move");
                    if (leave_f > -1 && leave_f < 50)
                    {
                        print("Recover");
                        for (int k = 0; k < 50; k++)
                        {
                            GameObject.Find("Cube (" + k + ")").transform.position = new Vector3(px[k], py[k], pz[k]);
                        }
                transform.position = new Vector3(transform.position.x, 1, 0);
                        leave_f = -1;
                print("iiiiiii");
                    }
                }

       /* if(c>10){
            Challenge();
            c = 0;
        }

    */
    

    }



		private void OnCollisionEnter(Collision collision)
        {

        JumpActive = true;
            if (collision.collider.CompareTag("up") && Input.GetKey(KeyCode.W))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                c++;
            }


        if (collision.collider.CompareTag("trap"))
        {
            live--;
            switch (live){
                case 5:
                    live_T.text = "Lives:♥♥♥♥♥";
                    break;
                case 4:
                    live_T.text = "Lives:♥♥♥♥";
                    break;
                case 3:
                    live_T.text = "Lives:♥♥♥";
                    break;
                case 2:
                    live_T.text = "Lives:♥♥";
                    break;
                case 1:
                    live_T.text = "Lives:♥";
                    break;
                case 0:
                    print("died!!");
                    live_T.text = "";
                    G_Over.SetActive(true);
                    AllStairs.SetActive(false);
                    died = true;
                    break;

            }
        }

//         GameObject.Find("Cube (" + leave_f + ")").transform.position = new Vector3(10000, 10000, 10000);
           

        }



        private void OnCollisionExit(Collision col)
        {
        for (int k = 0; k < 50; k++)
        {
            if (col.gameObject.name == "Cube (" + k + ")"&&(col.gameObject.name != "Cube (" + 40 + ")"))
            {
                leave_f = k;
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
            leave_f = -1;
            died = false;
            live_T.text = "Lives:♥♥♥♥♥";
            print("start");
        }

    /*  public void Challenge(){
       
            Challenge_type = (int)Random.Range(0, 5);
            print(Challenge_type); 
            transform.position = new Vector3(0, 3, 0);
            switch (Challenge_type){
                case 0:
                    C_mosters(); 
                    break;
				case 1:
					C_mosters();
					break;
				case 2:
					C_mosters();
					break;
				case 3:
					C_mosters();
					break;
				case 4:
					C_mosters();
					break;
				case 5:
					C_mosters();
					break;


            
        }
    }*/




     
}