using UnityEngine;
using System.Collections;
using System.Collections.Generic;//necesaria para la lista
using UnityEngine.UI;//para trabajar con la Interfaz de Usuario

public class managerJuego : Singleton<managerJuego> {

    private const int NUM_BLOQUES = 9;
    private const int NUM_VIDAS = 3;
    public int numeroBloques;
    public int numeroVidas;
    public List<GameObject> listaBloques;
    public GameObject paletaJugador;
    public Text puntuacionTexto;
    private int puntuacion;
    public Material matAzul;
    public Material matVerde;
    public GameObject pelota;
    public bool pelotaEnMovimiento;
    public Text mensajeGameOver;

    // Use this for initialization
    void Start () {
        numeroBloques = NUM_BLOQUES;
        numeroVidas = NUM_VIDAS;
        puntuacion = 0;
        pelotaEnMovimiento = false;
        mensajeGameOver.enabled=false;

    }
	
	// Update is called once per frame
	IEnumerator reponerBloques () {
        yield return new WaitForSeconds(0.5f);
        int contador = 0;
        foreach (var item in listaBloques)
        {
            item.SetActive(true);
            item.GetComponent<BoxCollider>().enabled = true;

            Debug.Log(item.name);
            if(contador < 3)
            {
            }
            else if (contador<6 /*&& contador<7*/)
            {
                item.tag = "bloqueVerde";
                MeshRenderer my_renderer = item.GetComponent<MeshRenderer>();
                my_renderer.material = matVerde;

            }
            else /*if (contador > 6 && contador < 10)*/
            {
                item.tag = "bloqueAzul";
                MeshRenderer my_renderer = item.GetComponent<MeshRenderer>();
                my_renderer.material = matAzul;
            }
            contador++;
            //
        }
	}
   

    public void ganaste()
    {

        Debug.Log("Juego acabado. a winner is you");
        //poner los bloques otra vez


        //resetear las variables de vida y de numbloques a los valores por defecto
        numeroBloques = NUM_BLOQUES;
        //numeroVidas = NUM_VIDAS;

        //reducir la pala
        float reduccionX = paletaJugador.transform.localScale.x - ((10 * paletaJugador.transform.localScale.x) / 100);
        paletaJugador.transform.localScale = new Vector3(reduccionX, paletaJugador.transform.localScale.y, paletaJugador.transform.localScale.z);

        //poner la pelota en la pos inicial y quitarle la velocidad
        pelota.transform.position = new Vector3(0.0f, 0.0f, 2.0f);

        //Parar la pelota e indicarlo
        pelotaEnMovimiento = false;
        pelota.GetComponent<Rigidbody>().velocity = Vector3.zero;

        StartCoroutine("reponerBloques");


    }

    public void gameOver() {

        Debug.Log("Game over. all your base belong to us");

        //poner los bloques otra vez
        

        //resetear las variables de vida y de numbloques a los valores por defecto
        numeroBloques = NUM_BLOQUES;
        numeroVidas = NUM_VIDAS;
        StartCoroutine("reponerBloques");
        puntuacion = 0;
        puntuacionTexto.text = "0" ;

        mensajeGameOver.enabled = true;

    }

    public void sumarPuntos()
    {
        puntuacion += 10;
        puntuacionTexto.text = (puntuacion).ToString(); ;
    }
}
