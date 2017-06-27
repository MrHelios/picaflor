using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{

    public class cerrar_ventana : adminVentanas {

        private GameObject go;

        void Start()
        {
            go = gameObject.transform.parent.gameObject;

            if (go.name == "ui_ventana_habilidades")
            {
                cerrar_ventana_hab();
            }
            else if (go.name == "ui_ventana_diario")
            {
                setVentana(go);
                cerrar_ventana_diario();
            }
            else
            {
                setVentana(go);
                cerrar_ventana();
            }
        }

        private void cerrar_ventana_hab()
        {
            Button boton = gameObject.GetComponent<Button>();
            boton.onClick.AddListener(() => cerrar_hab());
        }

        private void cerrar_ventana_diario()
        {
            Button boton = gameObject.GetComponent<Button>();
            boton.onClick.AddListener(() => cerrar_diario());
        }

        private void cerrar_diario()
        {
            for (int i=3; i<go.transform.childCount; i++)
                Destroy(go.transform.GetChild(i).gameObject);

            go.SetActive(false);
        }

        public void cerrar_hab()
        {
            removerHabilidades();
            go.SetActive(false);

            if (GameObject.Find("Hero").transform.GetChild(0).GetComponent<habilidad>() != null)
            {
                habilidad h = GameObject.Find("Hero").transform.GetChild(0).GetComponent<habilidad>();
                h.enabled = true;                
            }
        }

        private void removerHabilidades()
        {
            for (int i = 0; i < 8; i++)
            {
                if (go.transform.GetChild(i).GetComponent<habilidad>() != null)
                    Destroy(go.transform.GetChild(i).GetComponent<habilidad>());
            }
        }

    }

}

