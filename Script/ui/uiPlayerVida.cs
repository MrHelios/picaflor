using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiPlayerVida : MonoBehaviour {

        private GameObject canvas;
        private int hijo_ui;

	    void Start () {
            canvas = GameObject.Find("Canvas").gameObject;
            hijo_ui = 0;
	    }

        public void modificar(float v) {
            canvas.transform.GetChild(hijo_ui).transform.localScale = new Vector3(v, canvas.transform.GetChild(hijo_ui).transform.localScale.y, canvas.transform.GetChild(hijo_ui).transform.localScale.z);
        }

    }
}
