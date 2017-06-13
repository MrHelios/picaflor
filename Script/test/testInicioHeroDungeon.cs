using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testInicioHeroDungeon : MonoBehaviour {
	
	void Start () {
        GameObject hero = GameObject.Find("Hero");
        estaTodoActivado(hero);
        NOestaConservarHero(hero);
        todasImagenesHabilitadas(hero);

        IntegrationTest.Pass();
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

    private void NOestaConservarHero(GameObject hero)
    {
        if (hero.GetComponent<conservarHero>() != null)
        {
            Debug.Log("El script de conservar Hero esta activo!");
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
                if (!hijo.GetComponent<SpriteRenderer>().enabled)
                {
                    Debug.Log("La imagen del GO " + hijo + " no esta habilitada.");
                    IntegrationTest.Fail();
                }
            }
        }
    }

}
