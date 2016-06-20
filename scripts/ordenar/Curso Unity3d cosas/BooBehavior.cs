using UnityEngine;
using System.Collections;

public class BooBehavior : MonoBehaviour {

    public GameObject mario;
    private Vector3 _direccion;
    public float vel;
    // Use this for initialization
    void Start () {

        
	
	}
	
	// Update is called once per frame
	void Update () {

        //mirar hacia mario
        this.transform.LookAt(mario.transform);

        _direccion = mario.transform.position - this.transform.position;
        _direccion = new Vector3(_direccion.x, 0.0f, _direccion.z);


        if (Vector3.Dot(_direccion, mario.transform.forward)>0)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, mario.transform.position, vel * Time.deltaTime);
        }

    }
}
