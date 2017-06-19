using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerAguante : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;

        private float aguante_max;

        void Start()
        {
            canvas = GameObject.Find("Canvas").gameObject;
            hijo_ui = 2;

            aguante_max = canvas.transform.GetChild(hijo_ui).gameObject.transform.localScale.x;
        }

        public void modificar(float v)
        {
            GameObject ui_aguante = canvas.transform.GetChild(hijo_ui).gameObject;

            Vector3 nueva_vida = new Vector3(v * aguante_max, ui_aguante.transform.localScale.y, ui_aguante.transform.localScale.z);
            ui_aguante.transform.localScale = nueva_vida;
        }
    }
}
