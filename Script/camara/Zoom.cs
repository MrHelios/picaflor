using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class Zoom : MonoBehaviour {

        private int valor;
	
	    void Start ()
        {
            valor = 7;
            Camera.main.orthographicSize = valor;
	    }        

    }
}
