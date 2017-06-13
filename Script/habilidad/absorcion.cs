using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class absorcion : habilidadConTiempo {

        protected bool activo;
        protected GameObject objetivo;

        void Awake()
        {
            nivel_necesario = 5;
        }

        void Start ()
        {        
            queTecla();
            objetivo = GameObject.Find("Hero");
            activo = false;    

            cooldown = 60f;
            ultimoUso = Time.time - cooldown;
        }

        public override void efecto()
        {        
            activo = true;
            objetivo.AddComponent<escudoDivino>();
            objetivo.GetComponent<escudoDivino>().setUbicacion(this);

            duracion = 10f;
            tiempoCorte = Time.time + duracion;
        }

        public override void corte()
        {        
            Destroy(objetivo.GetComponent<escudoDivino>());
            activo = false;
        }

        void FixedUpdate ()
        {
            if (Time.time >= ultimoUso && !activo && Input.GetKeyDown(tecla))
            {
                Debug.Log("Activado " + Time.time);
                efecto();
                efectoCooldown();
            }
        
	    }
    }
}
