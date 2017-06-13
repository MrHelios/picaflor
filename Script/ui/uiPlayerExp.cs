using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerExp : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;    

        void Start() {        
            canvas = GameObject.Find("Canvas").gameObject;        
            hijo_ui = 1;
        }

        public void modificar(float v) {        
            canvas.transform.GetChild(hijo_ui).transform.localScale = new Vector3(v, canvas.transform.GetChild(hijo_ui).transform.localScale.y, canvas.transform.GetChild(hijo_ui).transform.localScale.z);
        }

    }
}
