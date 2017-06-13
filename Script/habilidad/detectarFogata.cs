using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class detectarFogata : habilidad {

        private Collider2D fogata;

        void Start () {
            tecla = KeyCode.E;
            icono_hab = null;
	    }

        public override void efecto()
        {
            Debug.Log("Se guardo la nueva posicion.");
            Vector3 v = fogata.gameObject.GetComponent<fogata>().darPosicion();
            gameObject.GetComponent<atribPrincipalesPlayer>().setPosicionMuerte(v);
        }	
	
	    void FixedUpdate () {

            fogata = Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("Fogata"));
            if (Input.GetKeyDown(tecla) && fogata != null)
                efecto();

	    }
    }
}
