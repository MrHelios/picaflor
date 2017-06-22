using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class gamecontrol : MonoBehaviour {

        public static GameObject control;

        protected int fuerza;
        protected int fortaleza;
        protected int agilidad;
        protected int fe;
        protected int inteligencia;
        protected int suerte;

        protected int puntos_no_gastados;

        protected float experiencia;
        protected int nivel;

        private Vector3 posicion;

        private int escena;
	
	    void Awake () {            

            if (control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = gameObject;
                iniciarValores();                
            }            
            else if(control != gameObject)
            {                
                Destroy(gameObject);
            }
            
        }

        private void iniciarValores()
        {
            experiencia = 0;
            nivel = 1;
            posicion = new Vector3(0, 0, 0);

            fuerza = 3;
            fortaleza = 3;
            agilidad = 3;
            fe = 3;
            inteligencia = 3;
            suerte = 3;

            escena = 2;
        }

        public void setFuerza(int f)
        {
            fuerza = f;
        }

        public int getFuerza()
        {
            return fuerza;
        }

        public void setFortaleza(int f)
        {
            fortaleza = f;
        }

        public int getFortaleza()
        {
            return fortaleza;
        }

        public void setAgilidad(int a)
        {
            agilidad = a;
        }

        public int getAgilidad()
        {
            return agilidad;
        }

        public void setFe(int f)
        {
            fe = f;
        }

        public int getFe()
        {
            return fe;
        }

        public void setInteligencia(int i)
        {
            inteligencia = i;
        }

        public int getInteligencia()
        {
            return inteligencia;
        }

        public void setSuerte(int s)
        {
            suerte = s;
        }

        public int getSuerte()
        {
            return suerte;
        }

        public void setPuntosNoGastados(int p)
        {
            puntos_no_gastados = p;
        }

        public int getPuntosNoGastados()
        {
            return puntos_no_gastados;
        }

        public void setExperiencia(float e)
        {
            experiencia = e;
        }

        public float getExperiencia()
        {
            return experiencia;
        }

        public void setNivel(int n)
        {
            nivel = n;
        }

        public int getNivel()
        {
            return nivel;
        }

        public void setPosicion(Vector3 v)
        {
            posicion = v;
        }

        public Vector3 getPosicion()
        {
            return posicion;
        }

        public void setEscena(int e)
        {
            escena = e;
        }

        public int getEscena()
        {
            return escena;
        }

    }
}
