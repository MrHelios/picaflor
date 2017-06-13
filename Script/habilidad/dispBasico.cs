using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class dispBasico : dispJugador {    
	
	    void Start () {
            queTecla();
            setMunicion(gameObject.transform.parent.transform.GetChild(5).transform.GetChild(1));
            setVelocidad(5);
	    }    

        void FixedUpdate() {

            if (Input.GetKeyDown(tecla))
                efecto();

        }

    }
}
