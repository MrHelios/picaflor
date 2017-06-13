using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class empujonIA : MonoBehaviour {

        private LayerMask mascara;
        private float radio;
        private Transform objetivo;

        private Collider2D col;
        private bool estado;
        private float tiempo;

	    void Start ()
        {
            objetivo = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject.transform;
            Debug.Log(objetivo);
            radio = 0.1f;
            mascara = LayerMask.GetMask("Player");

            estado = false;
	    }

        void efecto()
        {
            col.gameObject.GetComponent<movJugador>().enabled = false;
            col.gameObject.GetComponent<atribPrincipalesPlayer>().perderVida(10);
            estado = true;
            Vector3 v = new Vector3(transform.localScale.x,0,0);
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(v * -300);

            tiempo = Time.time + 0.5f;
        }

        void cortar()
        {
            col.gameObject.GetComponent<movJugador>().enabled = true;
            estado = false;
        }
	
	    void FixedUpdate ()
        {        
            if (!estado)
            {
                col = Physics2D.OverlapCircle(objetivo.position, radio, mascara);
                if(col != null)
                    efecto();
            }        
            else if (Time.time > tiempo && estado)
                cortar();        
	    }

    }
}
