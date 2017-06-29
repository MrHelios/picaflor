using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class detectarJugPos : MonoBehaviour {

        public string nombre_mision;
        public LayerMask heroe;
        public int escena;

        private float radio;

	    void Start () {
            radio = 2f;
	    }	
	
	    void FixedUpdate () {

            Collider2D col = Physics2D.OverlapCircle(transform.position, radio, heroe);

            if (col != null &&
                GameObject.Find("control/diario").GetComponent<diario>().estaMision(nombre_mision))
            {
                GameObject.Find("control/diario").GetComponent<diario>().getMision(nombre_mision).terminasteNoEntregaste();
                GetComponent<detectarJugPos>().enabled = false;
            }
		
	    }
    }
}
