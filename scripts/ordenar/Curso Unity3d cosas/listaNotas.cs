using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class listaNotas : MonoBehaviour
{
    public List<int> listaNotasvar;
    //al ser publica se puede inicializa en el propio unity

    // listaNotasvar=new List<int>();

    // Use this for initialization
    void Start()
    {
        foreach (var item in listaNotasvar)
        {
            if (item < 5)
            {
                Debug.Log("Suspenso");
            }
            else if (item == 5)
            {
                Debug.Log("aprobado");
            }
            else if (item == 6 || item == 7)
            {
                Debug.Log("Bien");
            }
            else if (item == 8)
            {
                Debug.Log("Notable");
            }
            else if (item == 9)
            {
                Debug.Log("Sobresaliente");
            }
            else
            {
                Debug.Log("Matricula");
            }
        }


    }

    void Awake()
    { }

    // Update is called once per frame
    void Update()
    {

    }
}
