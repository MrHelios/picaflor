using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_personaje : MonoBehaviour
    {
        private string UBICACION;

        void Start()
        {
            UBICACION = "Canvas/ui_ventana_personaje";
            activar();
            desactivar();
        }

        public void activar()
        {
            Button b = GetComponent<Button>();
            b.onClick.AddListener(() => enClickActivar());
            GameObject go = GameObject.Find(UBICACION);
        }

        public void enClickActivar()
        {
            GameObject go = GameObject.Find(UBICACION);
            go.GetComponent<organizar_ventana_pj>().enabled = true;
            enClick(true);

            //GameObject.Find(UBICACION + "/boton_cerrar").gameObject.transform.position = new Vector3(Screen.width * 0.9f, Screen.width * 0.5f, 0);
        }

        public void desactivar()
        {
            GameObject go = GameObject.Find(UBICACION + "/boton_cerrar");
            go.GetComponent<Button>().onClick.AddListener(() => enClickDesactivar());
        }

        public void enClickDesactivar()
        {
            GameObject go = GameObject.Find(UBICACION);
            go.GetComponent<organizar_ventana_pj>().enabled = false;
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
