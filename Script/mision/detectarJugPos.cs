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

            if (col != null && col.GetComponent<diario>().estaMision(nombre_mision))
            {
                col.GetComponent<diario>().getMision(nombre_mision).terminasteNoEntregaste();
                Debug.Log("Terminaste!");
                GetComponent<detectarJugPos>().enabled = false;
            }
		
	    }
    }
}
