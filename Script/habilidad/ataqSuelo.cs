using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class ataqSuelo : MonoBehaviour {

        private float radio;
        public LayerMask jugador;
        private Transform piso;

        private float cadencia;
        private float tiempo;

        private float vida;
	
	    void Start () {
            radio = 0.5f;
            piso = gameObject.transform;
            tiempo = Time.time;

            cadencia = 1f;

            vida = 5f;
	    }
	
	    void Update () {

            Collider2D col = Physics2D.OverlapCircle(piso.position, radio, jugador);
            if(tiempo < Time.time && col != null) {
                col.gameObject.GetComponent<atrib>().perderVida(vida);
                tiempo = cadencia + Time.time;
            }
		
	    }
    }
}
