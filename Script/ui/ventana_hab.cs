using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_hab : adminVentanas {

        private GameObject go;
	    
	    void Start() {
            int pos_vent = 5;
            go = GameObject.Find("Canvas").transform.GetChild(pos_vent).gameObject;
            
            abrir_ventana_hab();            
	    }

        protected void abrir_ventana_hab()
        {
            Button boton = gameObject.GetComponent<Button>();

            boton.onClick.AddListener(() => abrir_hab());            
        }

        public void abrir_hab()
        {            
            go.SetActive(true);
            go.GetComponent<armarLibroUI>().setAtajo(gameObject);
            go.GetComponent<armarLibroUI>().armarLibro();
        }

    }
}

