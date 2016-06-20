using UnityEngine;
using System.Collections;

public class MarioBehavior : MonoBehaviour {

    public float velocidad;
    public float velocidadRotacion;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += (this.transform.forward * velocidad * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= (this.transform.forward * velocidad/2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(this.transform.up, -velocidadRotacion * Time.deltaTime);
                }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(this.transform.up, velocidadRotacion * Time.deltaTime);
        }
    }
}
