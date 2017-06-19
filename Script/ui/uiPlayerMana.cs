using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerMana : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;

        private float mana_max;

        void Start()
        {
            canvas = GameObject.Find("Canvas").gameObject;
            hijo_ui = 1;

            mana_max = canvas.transform.GetChild(hijo_ui).gameObject.transform.localScale.x;
        }

        public void modificar(float v)
        {
            GameObject ui_mana = canvas.transform.GetChild(hijo_ui).gameObject;

            Vector3 nuevo_mana = new Vector3(v * mana_max, ui_mana.transform.localScale.y, ui_mana.transform.localScale.z);
            ui_mana.transform.localScale = nuevo_mana;
        }
    }
}
