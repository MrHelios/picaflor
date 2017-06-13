using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testInicioSistemaArmas : MonoBehaviour {

	
	void Start () {
        GameObject sistema_arma = GameObject.Find("SistemaArmas");

        testCantidadClases(sistema_arma);
        testMagoArmas(sistema_arma);
        testGuerreroArmas(sistema_arma);		
	}

    private void testCantidadClases(GameObject SA)
    {
        if (SA.transform.childCount != 2)
        {
            Debug.Log("La cantidad de clases para usar Armas es incorrecta: " + SA.transform.childCount);
            IntegrationTest.Fail();
        }
    }

    private void testMagoArmas(GameObject SA)
    {

        for (int i = 0; i < SA.transform.GetChild(0).transform.childCount; i++)
        {
            GameObject hijo = SA.transform.GetChild(0).transform.GetChild(i).gameObject;

            if (hijo.GetComponent<SpriteRenderer>() == null)
            {
                Debug.Log("El GO del mago" + hijo + " no tiene la imagen del arma.");
                IntegrationTest.Fail();
            }

            if (hijo.GetComponent<atribArma>() == null)
            {
                Debug.Log("El GO del mago " + hijo + " no tiene atributo del arma.");
                IntegrationTest.Fail();
            }
        }
    }

    private void testGuerreroArmas(GameObject SA)
    {
        for (int i = 0; i < SA.transform.GetChild(1).transform.childCount; i++)
        {
            GameObject hijo = SA.transform.GetChild(1).transform.GetChild(i).gameObject;

            if (hijo.GetComponent<SpriteRenderer>() == null)
            {
                Debug.Log("El GO del guerrero " + hijo + " no tiene la imagen del arma.");
                IntegrationTest.Fail();
            }

            if (hijo.GetComponent<atribArma>() == null)
            {
                Debug.Log("El GO del guerrero " + hijo + " no tiene atributo del arma.");
                IntegrationTest.Fail();
            }
        }
    }
	
}
