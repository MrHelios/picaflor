using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_inv : MonoBehaviour
    {
        private GameObject go;
        private string UBICACION;

        void Start()
        {
            UBICACION = "Canvas/ui_panel_personaje/boton_inventario";
            go = GameObject.Find(UBICACION);
            activar();            
        }

        public void activar()
        {
            GameObject go = GameObject.Find(UBICACION);
            go.GetComponent<Button>().onClick.AddListener(() => activarEnClick());
        }

        public void activarEnClick()
        {
            enClick("Canvas/ui_ventana_personaje", false);
            enClick("Canvas/ui_ventana_diario", false);
            enClick("Canvas/ui_ventana_inventario", true);
            GameObject.Find("Canvas/ui_ventana_inventario").GetComponent<armarInventario>().armarVentana();
        }        

        private void enClick(string u, bool e)
        {
            GameObject go = GameObject.Find(u);
            if (go.GetComponent<Image>() != null)
                go.GetComponent<Image>().enabled = e;

            for (int i = 0; i < go.transform.childCount; i++)
            {
                GameObject hijo = go.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<Image>() != null)
                    hijo.GetComponent<Image>().enabled = e;

                if (hijo.GetComponent<Text>() != null)
                    hijo.GetComponent<Text>().enabled = e;

                if (hijo.GetComponent<Button>() != null)
                    hijo.GetComponent<Button>().enabled = e;

                int cant = hijo.transform.childCount;
                for (int j = 0; j < cant; j++)
                    if (hijo.transform.GetChild(j).GetComponent<Text>() != null)
                        hijo.transform.GetChild(j).GetComponent<Text>().enabled = e;
            }
        }

    }
}
