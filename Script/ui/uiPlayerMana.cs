using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerMana : MonoBehaviour {
        
        private string nombre;
        private float mana_max;

        void Start()
        {            
            nombre = "Canvas/ui_mana";
            mana_max = GameObject.Find(nombre).transform.localScale.x;
        }

        public void modificar(float v)
        {
            GameObject ui_mana = GameObject.Find(nombre).gameObject;

            Vector3 nuevo_mana = new Vector3(v * mana_max, ui_mana.transform.localScale.y, ui_mana.transform.localScale.z);
            ui_mana.transform.localScale = nuevo_mana;
        }
    }
}
