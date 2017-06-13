using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSistemaClases : MonoBehaviour {
	
	void Start () {
        GameObject sistema_clases = GameObject.Find("SistemaClases").gameObject;

        correctaCantClases(sistema_clases);
        estaClaseMago(sistema_clases);
        estaClaseGuerrero(sistema_clases);

        IntegrationTest.Pass();
	}

    private void correctaCantClases(GameObject sist_clases)
    {
        int cant = sist_clases.transform.childCount;
        if (cant != 2)
        {
            Debug.Log("Se esperaba 2 clases y se encontraron " + cant);
            IntegrationTest.Fail();
        }
    }

    private void estaClaseMago(GameObject sist_clases)
    {
        GameObject clase = sist_clases.transform.GetChild(0).gameObject;

        string nombre = clase.name;
        if (nombre != "Mago")
        {
            Debug.Log("Se esperaba nombre Mago y se encontro: " + nombre);
            IntegrationTest.Fail();
        }
    }

    private void estaClaseGuerrero(GameObject sist_clases)
    {
        GameObject clase = sist_clases.transform.GetChild(1).gameObject;

        string nombre = clase.name;
        if (nombre != "Guerrero")
        {
            Debug.Log("Se esperaba nombre Guerrero y se encontro: " + nombre);
            IntegrationTest.Fail();
        }
    }

}
