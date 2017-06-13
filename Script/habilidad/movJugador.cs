using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class movJugador : MonoBehaviour {

        private float velX;
        private float velY;
        private float vel;

	    void Start ()
        {
            velX = 0;
            velY = 0;
            vel = 4;
            GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>().setVelocidad(vel);
        }

        private bool retrocede(float v)
        {
            string mirada = GetComponent<miradaJugador>().getFacing();
            if ((v >= 0 && mirada == "derecha") || (v <= 0 && mirada == "izquierda"))
                return false;
            else
                return true;
        }

	    void FixedUpdate ()
        {
            velX = Input.GetAxis("Horizontal");
            velY = Input.GetAxis("Vertical");
            vel = GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>().getVelocidad();

            if(!retrocede(velX))
                GetComponent<Rigidbody2D>().velocity = new Vector2(vel * velX, vel * velY);        
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(vel * 0.75f * velX, vel * 0.75f * velY);
        

            // Esto es usado para la animacion de movimiento.
            Vector2 v = GetComponent<Rigidbody2D>().velocity;
            GetComponent<Animator>().SetFloat("velocidad", Mathf.Sqrt(v.x * v.x + v.y * v.y));        
        }

    }
}
