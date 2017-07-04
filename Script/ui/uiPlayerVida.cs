using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerVida : MonoBehaviour
    {
        private string nombre;
        private float vida_max;

	    void Start ()
        {
            nombre = "Canvas/ui_vida";
            vida_max = GameObject.Find(nombre).transform.localScale.x;
        }

        public void modificar(float v) {

            if (v < 0)
                v = 0;

            GameObject ui_vida = GameObject.Find(nombre);
            Vector3 nueva_vida = new Vector3(v * vida_max, ui_vida.transform.localScale.y, ui_vida.transform.localScale.z);
            ui_vida.transform.localScale = nueva_vida;
        }

    }
}
