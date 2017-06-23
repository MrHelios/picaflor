using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace test010
{
    public class atribPrincipalesPlayer : atrib {

        private float experiencia;    
        private float exp_proximo_nivel;
        private Vector3 pos_caso_de_muerte;
        public string clase;

        void Awake()
        {
            // Valores por defecto.
            gameObject.transform.position = pos_caso_de_muerte;

            valoresIniciales();
            vida = vida_max = calculoVida();
            mana = mana_max = calculoMana();
            aguante = aguante_max = 30;

            clase = "Mago";
        }

        void Start()
        {
            
        }

        private void valoresIniciales()
        {
            GameObject control = GameObject.Find("control");

            experiencia = control.GetComponent<gamecontrol>().getExperiencia();
            nivel = control.GetComponent<gamecontrol>().getNivel();
            GameObject.Find("Hero").gameObject.transform.position = control.GetComponent<gamecontrol>().getPosicion();

            // ESTO ESTA SUJETO A CAMBIO.
            exp_proximo_nivel = nivel * 10;

            fuerza = control.GetComponent<gamecontrol>().getFuerza();
            fortaleza = control.GetComponent<gamecontrol>().getFortaleza();
            agilidad = control.GetComponent<gamecontrol>().getAgilidad();
            fe = control.GetComponent<gamecontrol>().getFe();
            inteligencia = control.GetComponent<gamecontrol>().getInteligencia();
            suerte = control.GetComponent<gamecontrol>().getSuerte();
            puntos_no_gastados = control.GetComponent<gamecontrol>().getPuntosNoGastados();
        }

        private float calculoVida()
        {
            return fortaleza * 10;
        }

        private float calculoMana()
        {
            return fe * 10;
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

        public float getExperienciaMax()
        {
            return exp_proximo_nivel;
        }
        
        private void nivelNuevo()
        {
            puntos_no_gastados += 3;
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
                gameObject.GetComponent<uiPlayerAguante>().modificar(aguante / aguante_max);
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
