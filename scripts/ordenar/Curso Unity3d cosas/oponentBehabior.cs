using UnityEngine;
using System.Collections;

public class oponentBehabior : MonoBehaviour
{
    public float speed;
    public GameObject ball;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position= new Vector3()

        if (ball.transform.position.x>0 && ball.GetComponent<Rigidbody>().velocity.x>0)
        {
            if (ball.transform.position.y>this.transform.position.y)
            {
                Vector3 nextWantedPosition = this.transform.position + new Vector3(0f, speed, 0f);
                //this.transform.position = nextWantedPosition;

                this.transform.position = Vector3.Lerp(this.transform.position, nextWantedPosition, 0.5f * Time.deltaTime);
            }
            else if(ball.transform.position.y < this.transform.position.y)
            {
                Vector3 nextWantedPosition = this.transform.position + new Vector3(0f, -speed, 0f);
                //this.transform.position = nextWantedPosition;
                this.transform.position = Vector3.Lerp(this.transform.position, nextWantedPosition, 0.5f * Time.deltaTime);
            }
           

            
        }


        if (this.transform.position.y > 0.5)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
        }

        if (this.transform.position.y < -0.5)
        {
            this.transform.position = new Vector3(this.transform.position.x, -0.5f, this.transform.position.z);
        }



    }
}
