using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class enraizar : habilidadConTiempo {

        private float vel_vieja;
        private float vel_nueva;
        private float tiempo;

	    void Start () {
            vel_nueva = 0f;
            tiempo = 2f;
            efecto();
	    }

        public override void corte()
        {
            gameObject.GetComponent<atrib>().setVelocidad(vel_vieja);
            Destroy(GetComponent<enraizar>());
        }

        public override void efecto()
        {
            duracion = tiempo;
            tiempoCorte = Time.time + duracion;
        
            vel_vieja = gameObject.GetComponent<atrib>().getVelocidad();
            gameObject.GetComponent<atrib>().setVelocidad(vel_nueva);
        }

        void FixedUpdate()
        {
            if (Time.time > tiempoCorte)
                corte();
        }

    }
}
