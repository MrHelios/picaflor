using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class miradaJugador : MonoBehaviour {

        private Vector3 mouse;
        private Vector3 direccion;
        private string facing;

        void Start () {
            mouse = Input.mousePosition;
            direccion = Camera.main.ScreenToWorldPoint(mouse);
            facing = "izquierda";
        }

        public string getFacing()
        {
            return facing;
        }
	
	    void FixedUpdate ()
        {
            mouse = Input.mousePosition;
            direccion = Camera.main.ScreenToWorldPoint(mouse);        

            if (direccion.x < gameObject.transform.position.x) {
                gameObject.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));
                facing = "izquierda";
            }
            else if (direccion.x > gameObject.transform.position.x) {
                gameObject.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 1, 0));
                facing = "derecha";
            }
	    }
    }
}
