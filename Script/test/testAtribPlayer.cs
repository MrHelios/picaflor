using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testAtribPlayer : MonoBehaviour {

    private float tiempo;
    private GameObject hero;
	
	void Start () {

        tiempo = Time.time;

        hero = new GameObject("newatrib");
        hero.AddComponent<atribPrincipalesPlayer>();

        if (GameObject.Find("newatrib") == null)
        {
            Debug.Log("No se creo el gameobject");
            IntegrationTest.Fail();
        }

        if (!hero.GetComponent<atribPrincipalesPlayer>().isActiveAndEnabled)
        {
            Debug.Log("La componente no esta activa.");
            IntegrationTest.Fail();
        }

        comprobar();        
	}

    private void comprobarClase(atribPrincipalesPlayer hero_atrib)
    {
        string[] clases = { "Mago", "Guerrero" };
        bool esta = false;
        for (int i = 0; i < clases.Length && !esta; i++)
            esta = clases[i] == hero_atrib.getClase();

        if (!esta)
        {
            Debug.Log("La clase elegida no se encuentra en la base de datos: " + hero_atrib.getClase());
            IntegrationTest.Fail();
        }
    }

    private void comprobar()
    {
        atribPrincipalesPlayer hero_atrib = hero.GetComponent<atribPrincipalesPlayer>();

        comprobarClase(hero_atrib);

        if (hero_atrib.getVida() == 30 && hero_atrib.getExperiencia() == 0 && hero_atrib.queNivel() == 1)
            IntegrationTest.Pass();
        else
        {
            Debug.Log(hero_atrib.getVida());
            Debug.Log(hero_atrib.getExperiencia());
            Debug.Log(hero_atrib.queNivel());
            IntegrationTest.Fail();
        }
    }    

}
