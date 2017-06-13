using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class destruirObjeto : MonoBehaviour {

        private float tiempo_vida;
        private float expira;

	    void Start () {
            // Valor por default.
            tiempo_vida = 2;
            expira = Time.time + tiempo_vida;
	    }

        public void setTiempoDeVida(float t) {
            tiempo_vida = t;
            expira = Time.time + tiempo_vida;
        }

        public void ahora() {
            Destroy(gameObject);
            Destroy(this);
        }
	
	    void Update () {

            if (expira < Time.time)
                ahora();        

	    }
    }
}
