using UnityEngine;
using System.Collections;

public class LanzaDados : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        int contador = 0;


        for (int i = 0; i < 50; i++)
        {

            if (Random.Range(1, 20) == 1)
            {
                contador++;
            }


        }

        Debug.Log("total de unos:" + contador.ToString());
    }

    // Update is called once per frame
    void Update()
    {
       


    }
}
