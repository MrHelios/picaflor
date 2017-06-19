using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace test010
{
    public class atribPrincipalesPlayer : atrib {

        private float experiencia;    
        private int exp_proximo_nivel;
        private Vector3 pos_caso_de_muerte;
        public string clase;

        void Awake()
        {
            // Valores por defecto.
            gameObject.transform.position = pos_caso_de_muerte;

            vida = vida_max = 30;
            mana = mana_max = 30;
            aguante = aguante_max = 30;

            experiencia = 0;
            nivel = 1;
            exp_proximo_nivel = nivel * 10;

            clase = "Mago";
        }

        void Start()
        {            
            GameObject.Find("Hero").gameObject.transform.position = new Vector3(0, 0, 0);            
        }

        public void setClase(string c)
        {
            clase = c;
        }

        public string getClase()
        {
            return clase;
        }

         // EXPERIENCIA

        public void sumarExp(float f)
        {
            experiencia += f;

            if (experiencia >= exp_proximo_nivel)
                nivelNuevo();
        }

        public float getExperiencia()
        {
            return experiencia;
        }
        
        private void nivelNuevo()
        {
            experiencia = experiencia - exp_proximo_nivel;            
            nivel++;
            
            // ESTA ES LA FUNCION PARA SUBIR DE NIVEL.
            exp_proximo_nivel = nivel * 10;
        }

        // VIDA

        public void reestablecerMaxVida()
        {
            vida = vida_max;
        }        

        public override void perderVida(float f)
        {
            if (gameObject.GetComponent<escudoDivino>() != null)
                gameObject.GetComponent<escudoDivino>().corte();
            else
            {
                vida -= f;
                gameObject.GetComponent<uiPlayerVida>().modificar(vida / vida_max);
                GetComponent<Animator>().SetTrigger("sangre");
            }

            if (vida <= 0) {
                gameObject.GetComponent<loadSceneMuerte>().muerte();
            }        
        }

        // MANA

        public void reestablecerMaxMana()
        {
            mana = mana_max;
        }

        public override void perderMana(float m)
        {
            if (mana >= m)
            {
                mana -= m;
                gameObject.GetComponent<uiPlayerMana>().modificar(mana / mana_max);
            }
        }

        // AGUANTE

        public void reestablecerMaxAguante()
        {
            aguante = aguante_max;
        }

        public override void perderAguante(float a)
        {
            if (aguante >= a)
            {
                aguante -= a;
                gameObject.GetComponent<uiPlayerMana>().modificar(aguante / aguante_max);
            }
        }

        public void setPosicionMuerte(Vector3 v)
        {
            pos_caso_de_muerte = v;
        }

        public void ubicarHeroe()
        {
            gameObject.transform.position = pos_caso_de_muerte;
        }

    }
}
