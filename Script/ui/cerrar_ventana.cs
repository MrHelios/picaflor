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

        private void cerrar_hab()
        {
            removerHabilidades();
            go.SetActive(false);
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

