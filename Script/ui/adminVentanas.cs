using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class adminVentanas : MonoBehaviour {

        public GameObject ventana;        

        public void setVentana(GameObject go)
        {
            ventana = go;            
        }        

        protected void abrir_ventana()
        {
            Button boton = gameObject.GetComponent<Button>();

            boton.onClick.AddListener(() => abrir());
        }

        public void cerrar_ventana()
        {
            Button boton = gameObject.GetComponent<Button>();

            boton.onClick.AddListener(() => cerrar());
        }

        public void abrir()
        {            
            ventana.SetActive(true);            
        }

        protected void cerrar()
        {
            ventana.SetActive(false);

            if (GameObject.Find("Hero").transform.GetChild(0).GetComponent<habilidad>() != null)
            {
                habilidad h = GameObject.Find("Hero").transform.GetChild(0).GetComponent<habilidad>();
                h.enabled = true;
            }
        }

        public void cerrar_ventana_i()
        {
            Button boton = gameObject.GetComponent<Button>();

            boton.onClick.AddListener(() => cerrar_vent_int());
        }

        public void cerrar_vent_int()
        {
            ventana.SetActive(false);
            for (int i = 3; i < ventana.transform.childCount; i++)
            {
                DestroyImmediate(ventana.transform.GetChild(i).gameObject);
            }
        }

    }
}
