using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testSistemaEnemigos : MonoBehaviour {	

	void Start () {
        GameObject enemigos = GameObject.Find("SistemaEnemigos");

        if (enemigos == null)
        {
            Debug.Log("La Base de datos de enemigo no se cargo.");
            IntegrationTest.Fail();
        }

        correctaCantEnemigos(enemigos);
        estaBabosaRoja(enemigos);
        estaTempestadOscura(enemigos);

        IntegrationTest.Pass();
	}

    private void correctaCantEnemigos(GameObject base_enem)
    {
        int cant = base_enem.transform.childCount;
        if (cant != 3)
        {
            Debug.Log("La cantidad de enemigos no es correcta.");
            Debug.Log("Se esperaba 3 pero se encontraron " + cant);
            IntegrationTest.Fail();
        }
    }

    private void estaBabosaRoja(GameObject base_enem)
    {
        GameObject enemigo = base_enem.transform.GetChild(0).gameObject;

        if (enemigo.name != "babosa_roja" || enemigo.tag != "Enemy" || enemigo.layer != LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Nombre: "  + enemigo.name);
            Debug.Log("Tag: " + enemigo.tag);
            Debug.Log("Layer: " + enemigo.layer + " se esperaba: " + LayerMask.NameToLayer("Enemy"));
            IntegrationTest.Fail();
        }        
    }

    private void estaTempestadOscura(GameObject base_enem)
    {
        GameObject enemigo = base_enem.transform.GetChild(1).gameObject;

        if (enemigo.name != "tempestad_oscura" || enemigo.tag != "Enemy" || enemigo.layer != LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Nombre: " + enemigo.name);
            Debug.Log("Tag: " + enemigo.tag);
            Debug.Log("Layer: " + enemigo.layer + " se esperaba: " + LayerMask.NameToLayer("Enemy"));
            IntegrationTest.Fail();
        }
    }

    private void estaDruidaSalvaje(GameObject base_enem)
    {
        GameObject enemigo = base_enem.transform.GetChild(1).gameObject;

        if (enemigo.name != "druida_salvaje" || enemigo.tag != "Enemy" || enemigo.layer != LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Nombre: " + enemigo.name);
            Debug.Log("Tag: " + enemigo.tag);
            Debug.Log("Layer: " + enemigo.layer + " se esperaba: " + LayerMask.NameToLayer("Enemy"));
            IntegrationTest.Fail();
        }
    }
	
}
