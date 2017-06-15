using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testInicioHeroDungeon : MonoBehaviour {

    private bool activo;
	
	void Start () {
        activo = false;        
	}

    private void estaTodoActivado(GameObject hero)
    {
        MonoBehaviour[] script = hero.GetComponents<MonoBehaviour>();
        for (int i = 0; i < script.Length; i++)
        {
            if (!script[i].enabled)
            {
                Debug.Log("El script no esta activado: " + script[i]);
                IntegrationTest.Fail();
            }
        }
    }

    private void estaColliderHabilitado(GameObject hero)
    {
        if (!hero.GetComponent<Collider2D>().enabled)
        {
            Debug.Log("El collider2D del Hero no esta activado.");
            IntegrationTest.Fail();
        }
    }

    private void todasImagenesHabilitadas(GameObject hero)
    {
        for (int i = 0; i < hero.transform.childCount; i++)
        {
            GameObject hijo = hero.transform.GetChild(i).gameObject;
            if (hijo.GetComponent<SpriteRenderer>() != null)
            {
                if (!hijo.GetComponent<SpriteRenderer>().enabled && hijo.name != "sangreHero")
                {
                    Debug.Log("La imagen del GO " + hijo + " no esta habilitada.");
                    IntegrationTest.Fail();
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!activo)
        {
            activo = true;
            GameObject hero = GameObject.Find("Hero");
            estaTodoActivado(hero);
            estaColliderHabilitado(hero);
            todasImagenesHabilitadas(hero);

            IntegrationTest.Pass();
        }
    }

}
