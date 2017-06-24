using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerExp : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;

        private float exp_max;

        void Start() {
            canvas = GameObject.Find("Canvas").gameObject;
            hijo_ui = 9;

            exp_max = canvas.transform.GetChild(hijo_ui).gameObject.transform.localScale.x;
        }

        public void modificar(float v)
        {
            GameObject ui_exp = canvas.transform.GetChild(hijo_ui).gameObject;

            Vector3 nueva_vida = new Vector3(v * exp_max, ui_exp.transform.localScale.y, ui_exp.transform.localScale.z);
            ui_exp.transform.localScale = nueva_vida;
        }

    }
}
