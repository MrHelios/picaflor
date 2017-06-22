using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class organizar_ventana_pj : MonoBehaviour
    {
        private atribPrincipalesPlayer hero;
        
	    void Start ()
        {
            hero = GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>();            
	    }

        private void organizar()
        {
            // nombre -> 3

            // nivel -> 5
            gameObject.transform.GetChild(5).GetComponent<Text>().text = hero.queNivel() + "";
            // nivel -> 7
            gameObject.transform.GetChild(7).GetComponent<Text>().text = hero.getExperiencia() + " / " + hero.getExperienciaMax();
        }

        void FixedUpdate()
        {
            organizar();
        }

    }
}
