using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class armarLibroUI : MonoBehaviour {

        private GameObject queAtajo;

        public void armarLibro()
        {
            GameObject tu = GameObject.Find("SistemaClases").transform.GetChild(0).gameObject;

            for (int i = 0; i < tu.transform.childCount; i++)
            {
                GameObject tu_hab = tu.transform.GetChild(i).gameObject;
                GameObject boton_hab = gameObject.transform.GetChild(i).gameObject;

                boton_hab.GetComponent<Image>().sprite = tu_hab.GetComponent<habilidad>().icono_hab;
                boton_hab.GetComponent<Button>().interactable = true;

                habilidad h_nueva = tu_hab.GetComponent<habilidad>();
                boton_hab.AddComponent(h_nueva.GetType());
                boton_hab.GetComponent<habilidad>().enabled = false;
            }
        }        

        public void setAtajo(GameObject a)
        {
            queAtajo = a;            
        }

        public GameObject getAtajo()
        {
            return queAtajo;
        }

    }
}
