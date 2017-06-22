using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class ventana_nivel : MonoBehaviour {

        private atrib hero;        

        private void Start()
        {
            hero = GameObject.Find("Hero").GetComponent<atrib>();
        }

        private bool comprobar()
        {
            if (hero.getPuntosNoGastados() > 0)
                return true;
            else
                return false;
        }

        private void quitarPunto()
        {
            hero.setPuntosNoGastados(hero.getPuntosNoGastados() - 1);
        }

        public void incrementarFuerza()
        {
            if (comprobar())
            {
                hero.setFuerza(hero.getFuerza() + 1);
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void incrementarFortaleza()
        {
            if (comprobar())
            {            
                hero.setFortaleza(hero.getFortaleza() + 1);
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void incrementarAgilidad()
        {
            if (comprobar())
            {            
                hero.setAgilidad(hero.getAgilidad() + 1);
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void incrementarFe()
        {
            if (comprobar())
            {
                hero.setFe(hero.getFe() + 1);            
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void incrementarInteligencia()
        {
            if (comprobar())
            {
                hero.setInteligencia(hero.getInteligencia() + 1);            
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

        public void incrementarSuerte()
        {
            if (comprobar())
            {
                hero.setSuerte(hero.getSuerte() + 1);
                quitarPunto();
                gameObject.transform.parent.gameObject.SetActive(false);
            }
        }

    }
}
