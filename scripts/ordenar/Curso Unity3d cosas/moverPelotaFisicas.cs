using UnityEngine;
using System.Collections;

public class moverPelotaFisicas : MonoBehaviour {

    public float aceleration;
    public float jumpAceleration;
    private bool grounded;
    private Material matOriginal;
    public Material matVerde;

    // Use this for initialization
    void Start () {
        grounded = false;
        matOriginal = this.GetComponent<MeshRenderer>().material;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.forward * aceleration);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.back * aceleration);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.left * aceleration);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.right * aceleration);
        }

        if (Input.GetKey(KeyCode.E))
        {
            this.GetComponent<Rigidbody>().AddTorque(Vector3.up);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            this.GetComponent<Rigidbody>().AddTorque(Vector3.down);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            this.GetComponent<Rigidbody>().AddForce(jumpAceleration * Vector3.up, ForceMode.Impulse);
        }

        if (Input.GetKey(KeyCode.M))
        {
            this.GetComponent<Rigidbody>().AddExplosionForce(100,this.transform.position,40);
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            grounded = false;
            this.GetComponent<MeshRenderer>().material = matOriginal;
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            this.GetComponent<MeshRenderer>().material = matVerde;
        }
    }
}
