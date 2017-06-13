using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInicioDungeon : MonoBehaviour {

	
	void Start () {
        if (GameObject.Find("Dungeon") != null)
        {
            GameObject dungeon = GameObject.Find("Dungeon");
            estaCampoVerde();
            estaArbolSinHoja();
            estaArbolCopa();
        }
        else
        {
            IntegrationTest.Fail();
            Debug.Log("No se encuentra el GO Dungeon.");
        }
	}

    private void estaCampoVerde()
    {
        string nombre = "cesped_oscuro_fondo_";
        int cant = 1;
        Vector3[] v = { new Vector3(0, 0, 0) };
        for (int i = 0; i < cant; i++)
        {

            GameObject campo = GameObject.Find(nombre + (i+1));
            if (campo == null)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + nombre + i+1 + " es Null");
            }

            if (!campo.GetComponent<SpriteRenderer>().enabled)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + campo + " no esta visible.");
            }

            if (campo.transform.position.x != v[i].x || campo.transform.position.y != v[i].y || campo.transform.position.z != v[i].z)
            {
                IntegrationTest.Fail();
                Debug.Log("La posicion del " + campo + " no es correcta.");
            }
        }
    }

    private void estaArbolSinHoja()
    {
        string nombre = "arbol_sin_hojas_";
        int cant = 2;
        Vector3[] v = { new Vector3(3.94f, 1.82f, 0), new Vector3(1.97f, -3.94f, 0) };
        for (int i = 0; i < cant; i++)
        {
            GameObject campo = GameObject.Find(nombre + (i+1));
            if (campo == null)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + nombre + i + 1 + " es Null");
            }

            if (!campo.GetComponent<SpriteRenderer>().enabled)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + campo + " no esta visible.");
            }

            if (campo.transform.position.x != v[i].x || campo.transform.position.y != v[i].y || campo.transform.position.z != v[i].z)
            {
                IntegrationTest.Fail();
                Debug.Log("La posicion del " + campo + " no es correcta.");
            }
        }
    }

    private void estaArbolCopa()
    {
        string nombre = "arbol_copa_";
        int cant = 1;
        Vector3[] v = { new Vector3(-4.22f, -4.06f, 0)};
        for (int i = 0; i < cant; i++)
        {
            GameObject campo = GameObject.Find(nombre + (i+1));
            if (campo == null)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + nombre + i + 1 + " es Null");
            }

            if (!campo.GetComponent<SpriteRenderer>().enabled)
            {
                IntegrationTest.Fail();
                Debug.Log("El objeto " + campo + " no esta visible.");
            }

            if (campo.transform.position.x != v[i].x || campo.transform.position.y != v[i].y || campo.transform.position.z != v[i].z)
            {
                IntegrationTest.Fail();
                Debug.Log("La posicion del " + campo + " no es correcta.");
            }
        }
    }

}
