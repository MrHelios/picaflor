using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_nivel : MonoBehaviour 
    {
        private atrib hero;        

        private void Start()
        {
            hero = GameObject.Find("Hero").GetComponent<atrib>();
        }

        private bool comprobar()
        {
            hero = GameObject.Find("Hero").GetComponent<atrib>();
            if (hero.getPuntosNoGastados() > 0)
                return true;
            else
                return false;
        }

        private void quitarPunto()
        {
            hero.setPuntosNoGastados(hero.getPuntosNoGastados() - 1);
            GameObject.Find("Canvas/ui_ventana_puntos/cantidad").GetComponent<Text>().text = GameObject.Find("Hero").GetComponent<atrib>().getPuntosNoGastados() + "";
        }

        public void incrementarFuerza()
        {
            if (comprobar())
            {
                hero.setFuerza(hero.getFuerza() + 1);
                quitarPunto();                
            }
        }

        public void incrementarFortaleza()
        {
            if (comprobar())
            {            
                hero.setFortaleza(hero.getFortaleza() + 1);
                quitarPunto();                
            }
        }

        public void incrementarAgilidad()
        {
            if (comprobar())
            {            
                hero.setAgilidad(hero.getAgilidad() + 1);
                quitarPunto();                
            }
        }

        public void incrementarFe()
        {
            if (comprobar())
            {
                hero.setFe(hero.getFe() + 1);            
                quitarPunto();                
            }
        }

        public void incrementarInteligencia()
        {
            if (comprobar())
            {
                hero.setInteligencia(hero.getInteligencia() + 1);            
                quitarPunto();                
            }
        }

        public void incrementarSuerte()
        {
            if (comprobar())
            {
                hero.setSuerte(hero.getSuerte() + 1);
                quitarPunto();                
            }
        }

    }
}
