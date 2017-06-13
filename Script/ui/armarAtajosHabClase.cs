using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class armarAtajosHabClase : MonoBehaviour {

	    void Start () {

            GameObject hero = GameObject.Find("hero");
            string clase = hero.GetComponent<atribPrincipalesPlayer>().getClase();

            if (clase == "Mago")
            {
                habilidad h = GameObject.Find("Mago").gameObject.transform.GetChild(0).GetComponent<habilidad>();
                hero.transform.GetChild(0).gameObject.AddComponent(h.GetType());
                
            }
            else if (clase == "Guerrero")
            {
                habilidad h = GameObject.Find("Guerrero").gameObject.transform.GetChild(0).GetComponent<habilidad>();
                hero.transform.GetChild(0).gameObject.AddComponent(h.GetType());                
            }
            hero.GetComponent<sistemaAtajo>().armarLibroAtajos();

        }
	
    }
}


