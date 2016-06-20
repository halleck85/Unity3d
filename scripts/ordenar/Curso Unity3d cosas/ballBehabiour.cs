using UnityEngine;
using System.Collections;

public class ballBehabiour : MonoBehaviour {

    private Vector3 _vel1;
    private Vector3 _vel2;
    public float cspeed;
    private float _speeder;
    private bool _bPlay;



    void Awake()
    {
        _bPlay = false;
        _speeder = 1.1f;

    }

    // Use this for initialization
    void Start () {
        StartCoroutine("arranque");
       
        
	}
	
	// Update is called once per frame
	void Update () {
        if (_bPlay)
        {
            _vel1 = GetComponent<Rigidbody>().velocity;
            _vel2 = _vel1.normalized * cspeed * _speeder;
            this.GetComponent<Rigidbody>().velocity = _vel2;
            _speeder += 0.1f * Time.deltaTime;
           // this.GetComponent<Rigidbody>().AddTorque(5.0f, 5.0f, 5.0f);

        }

        ////nos han marcado
        //if (this.transform.position.x<-1)
        //{
        //    StartCoroutine("arranque");
        //}
        //
        ////hemos marcado
        //if (this.transform.position.x > 1)
        //{
        //    StartCoroutine("arranque");
        //}
        //
        ////rebote superior
        //if(this.transform.position.y < -1)
        //{
        //    StartCoroutine("arranque");
        //}


    }

    IEnumerator arranque()
    {
        this.transform.position = Vector3.zero;
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _bPlay = false;
        yield return new WaitForSeconds(1.0f);
        _bPlay = true;
        float ydir = Random.Range(-25, 25);
        this.GetComponent<Rigidbody>().AddForce(100.0f, ydir, 0f);
       
    }
}
