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
            // experiencia -> 7
            gameObject.transform.GetChild(7).GetComponent<Text>().text = hero.getExperiencia() + " / " + hero.getExperienciaMax();
            // fuerza -> 12
            gameObject.transform.GetChild(12).GetComponent<Text>().text = hero.getFuerza() + "";
            // fortaleza -> 14
            gameObject.transform.GetChild(14).GetComponent<Text>().text = hero.getFortaleza() + "";
            // agilidad -> 16
            gameObject.transform.GetChild(16).GetComponent<Text>().text = hero.getAgilidad() + "";
            // suerte -> 18
            gameObject.transform.GetChild(18).GetComponent<Text>().text = hero.getSuerte() + "";
            // inteligencia -> 20
            gameObject.transform.GetChild(20).GetComponent<Text>().text = hero.getInteligencia() + "";
            // fe -> 22
            gameObject.transform.GetChild(22).GetComponent<Text>().text = hero.getFe() + "";

        }

        void FixedUpdate()
        {
            organizar();
        }

    }
}
