using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerAguante : MonoBehaviour
    {
        private string nombre;
        private float aguante_max;

        void Start()
        {
            nombre = "Canvas/ui_energia";
            aguante_max = GameObject.Find(nombre).transform.localScale.x;
        }

        public void modificar(float v)
        {
            GameObject ui_aguante = GameObject.Find(nombre);

            Vector3 nueva_vida = new Vector3(v * aguante_max, ui_aguante.transform.localScale.y, ui_aguante.transform.localScale.z);
            ui_aguante.transform.localScale = nueva_vida;
        }
    }
}
