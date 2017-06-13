using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class congelar : habilidadConTiempo {

        private float vel_vieja;
        private float vel_nueva;

        void Start () {
            efecto();
	    }

        public override void corte()
        {
            gameObject.GetComponent<atrib>().setVelocidad(vel_vieja);
            Destroy(GetComponent<congelar>());
        }

        public override void efecto()
        {
            duracion = 10f;
            tiempoCorte = Time.time + duracion;

            vel_nueva = 1f;
            vel_vieja = gameObject.GetComponent<atrib>().getVelocidad();
            gameObject.GetComponent<atrib>().setVelocidad(vel_nueva);
        }

        void FixedUpdate () {

            if (Time.time > tiempoCorte)
                corte();

	    }
    }
}
