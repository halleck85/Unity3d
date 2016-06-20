using UnityEngine;
using System.Collections;

public class playerBehabior : MonoBehaviour {

    public float velocidad;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, velocidad, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -velocidad, 0) * Time.deltaTime);
        }

        if (this.transform.position.y>0.5)
        {
            this.transform.position = new Vector3(this.transform.position.x, 0.5f, this.transform.position.z);
        }

        if (this.transform.position.y < -0.5)
        {
            this.transform.position = new Vector3(this.transform.position.x, -0.5f, this.transform.position.z);
        }
    }
}
