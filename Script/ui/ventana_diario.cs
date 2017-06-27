using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_diario : adminVentanas {

        private GameObject go;

        void Start()
        {
            int pos_vent = 10;
            go = GameObject.Find("Canvas").transform.GetChild(pos_vent).gameObject;

            setVentana(go);
            abrir_ventana_diario();
        }        

        protected void abrir_ventana_diario()
        {
            Button boton = gameObject.GetComponent<Button>();

            boton.onClick.AddListener(() => abrir_d());
        }        

        public void abrir_d()
        {
            go.GetComponent<armarDiario>().armar();
            ventana.SetActive(true);
        }

    }
}
