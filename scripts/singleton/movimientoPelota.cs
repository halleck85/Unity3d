using UnityEngine;
using System.Collections;


public class movimientoPelota : MonoBehaviour {


    public Material matRojo;
    public Material matVerde;

    private bool pelotaEnMovimiento;//var que indicqa si la pelota se esta moviendo 

	// Use this for initialization
	void Start () {
        managerJuego.Instance.pelotaEnMovimiento = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!managerJuego.Instance.pelotaEnMovimiento && Input.GetKey(KeyCode.Space))
        {
            managerJuego.Instance.pelotaEnMovimiento = true;
            StartCoroutine("dispararPelota");

            managerJuego.Instance.mensajeGameOver.enabled = false;
        }
        

    }

    IEnumerator dispararPelota()
    {
        yield return new WaitForSeconds(1.0f);//esta linea solo el yield return null, es obligato.
        float zDir = Random.Range(300f, 600f);//el angulo con el que sale disparada la pelota
        this.GetComponent<Rigidbody>().AddForce(600.0f, 0.0f, zDir);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("pelotaFuera"))
        {
            //colocar la peota en el origen
            this.transform.position = new Vector3(0.0f, 0.0f, 2.0f);

            //Parar la pelota e indicarlo
            managerJuego.Instance.pelotaEnMovimiento = false;
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;

            //restar una vida
            managerJuego.Instance.numeroVidas--;

            //si estamos sin vidas, mostrra game over
            if (managerJuego.Instance.numeroVidas == 0)
            {
                managerJuego.Instance.gameOver();
            }

            //arrancar el juego otra vez
            //lo hace solo //col.gameObject.tag = "Player";
        }

        if (col.gameObject.tag.Equals("bloqueRojo"))
        {
            //desactivamos el colider de los bloques para evitar falsos rebotes
            //esto es por el retraso de 0.2 seg metido al bloque al destruirlo
            col.gameObject.GetComponent<BoxCollider>().enabled = false;

            //destruir el bloque
            //Destroy(col.gameObject, 0.2f);

            //ocultar los bloques, pq luego poder ponerlos otra vez
            col.gameObject.SetActive(false);

            managerJuego.Instance.sumarPuntos();

            //restar el bloqe del total
            managerJuego.Instance.numeroBloques--;

            //si el numerio de bloques es 0 game over man, game over
            if (managerJuego.Instance.numeroBloques==0)
            {
                managerJuego.Instance.ganaste();
            }

        }

        if (col.gameObject.tag.Equals("bloqueVerde"))
        {
            //cambiar el material del bloque
            MeshRenderer my_renderer = col.gameObject.GetComponent<MeshRenderer>();
            my_renderer.material = matRojo;

            managerJuego.Instance.sumarPuntos();

            //cambial el tag al bloque
            col.gameObject.tag = "bloqueRojo";
        }

        if (col.gameObject.tag.Equals("bloqueAzul"))
        {
            //cambiar el material del bloque
            MeshRenderer my_renderer = col.gameObject.GetComponent<MeshRenderer>();
            my_renderer.material = matVerde;

            managerJuego.Instance.sumarPuntos();

            //cambial el tag al bloque
            col.gameObject.tag = "bloqueVerde";
        }

    }
}
