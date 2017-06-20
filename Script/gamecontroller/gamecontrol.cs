using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class gamecontrol : MonoBehaviour {

        public static GameObject control;

        public float experiencia;
        public int nivel;
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
            escena = 2;
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
