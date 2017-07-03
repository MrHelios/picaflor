using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_config : MonoBehaviour
    {
        private string UBICACION;
	
	    void Start ()
        {
            UBICACION = "Canvas/ui_ventana_config";
            activar();
            desactivar();
        }

        public void activar()
        {
            Button b = GetComponent<Button>();
            b.onClick.AddListener(() => enClickActivar());
        }

        public void enClickActivar()
        {
            enClick(true);
        }

        public void desactivar()
        {
            Button b = GameObject.Find(UBICACION + "/boton_reanudar").GetComponent<Button>();
            b.onClick.AddListener(() => enClickDesactivar());
        }

        public void enClickDesactivar()
        {
            enClick(false);
        }

        private void enClick(bool e)
        {
            GameObject go = GameObject.Find(UBICACION);
            if (go.GetComponent<Image>() != null)
                go.GetComponent<Image>().enabled = e;

            for (int i = 0; i < go.transform.childCount; i++)
            {
                GameObject hijo = go.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<Image>() != null)
                    hijo.GetComponent<Image>().enabled = e;

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
