using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerVida : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;

        private float vida_max;

	    void Start () {
            canvas = GameObject.Find("Canvas").gameObject;
            hijo_ui = 0;

            vida_max = canvas.transform.GetChild(hijo_ui).gameObject.transform.localScale.x;
        }

        public void modificar(float v) {

            if (v < 0)
                v = 0;

            GameObject ui_vida = canvas.transform.GetChild(hijo_ui).gameObject;

            Vector3 nueva_vida = new Vector3(v * vida_max, ui_vida.transform.localScale.y, ui_vida.transform.localScale.z);
            ui_vida.transform.localScale = nueva_vida;
        }

    }
}
