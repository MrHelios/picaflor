using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testCreacionEnemigos : MonoBehaviour {

	
	void Start () {

        GameObject dung = GameObject.Find("Dungeon");

        if (dung == null)
        {
            IntegrationTest.Fail();
            Debug.Log("El GO Dungeon no existe en la escena.");
        }
        else
        {
            estaBabosaRoja();
            estaTempestadOscura();
            estaDruidaSalvaje();
        }
	}

    private void estaEnem(string n)
    {
        GameObject enem = GameObject.Find(n);

        string nombre = enem.name;
        if (nombre != n)
        {
            IntegrationTest.Fail();
            Debug.Log("El nombre del enemigo es erroneo.");
            Debug.Log(enem + " -> " + nombre);
        }

        if (!enem.GetComponent<Collider2D>().enabled || !enem.GetComponent<atribPrincipales>().enabled || !enem.GetComponent<detectarJugadorIA>().enabled)
        {
            IntegrationTest.Fail();
            Debug.Log("El enemigo " + enem + " no tiene el collider2d o atribPrincipal o detectar activado.");
        }

        bool ui = enem.transform.GetChild(0).gameObject.activeSelf;
        bool imagen = enem.transform.GetChild(1).gameObject.activeSelf;
        if (!ui || !imagen)
        {
            IntegrationTest.Fail();
            Debug.Log("El ui de la vida o la imagen no esta activo en " + enem);
        }
    }

    private void estaBabosaRoja()
    {
        estaEnem("babosa_roja_1");
    }

    private void estaTempestadOscura()
    {
        estaEnem("tempestad_oscura_1");
    }

    private void estaDruidaSalvaje()
    {
        estaEnem("druida_salvaje_1");
    }
	
}
