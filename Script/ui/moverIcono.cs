using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class moverIcono : MonoBehaviour {

        /*

        private bool activado;

        private void Start()
        {
            activado = false;
        }

        public void activar() {
            activado = true;
        }

        public void mover()
        {
            if(!activado)
            {
                bool encontrado = false;
                GameObject clase = null;
                for (int i = 0; i < 3 && !encontrado; i++)
                {
                    clase = GameObject.Find("Mago").transform.GetChild(i).gameObject;                
                    encontrado = clase.GetComponent<habilidad>().icono_hab == gameObject.GetComponent<Image>().sprite;
                }            

                GameObject go = GameObject.Find("habilidadNueva");
                go.GetComponent<moverIcono>().enabled = true;
                go.GetComponent<moverIcono>().activar();        
                go.GetComponent<Image>().sprite = clase.GetComponent<habilidad>().icono_hab;
                go.GetComponent<Image>().enabled = true;
        
                go.SetActive(true);
            }
            activado = true;
        }

        public void dejarMovimiento()
        {
            activado = false;
            GameObject go = GameObject.Find("habilidadNueva");
            go.GetComponent<moverIcono>().enabled = false;
            go.GetComponent<Image>().enabled = false;        
        }

        void FixedUpdate()
        {
            if (activado && Input.GetKeyDown(KeyCode.Escape))
                dejarMovimiento();
            else if (activado)
            {
                GameObject go = GameObject.Find("habilidadNueva");
                go.GetComponent<RectTransform>().position = Input.mousePosition;
            }        
        }

        */

    }
}
