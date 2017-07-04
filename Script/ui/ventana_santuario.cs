using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_santuario : MonoBehaviour
    {
        private string NOMBRE;
        private string VOLVER;
        private string PUNTOS;
        private string VENT_PUNTOS;

        private void Start()
        {
            NOMBRE = "Canvas/ui_ventana_santuario";
            VOLVER = NOMBRE + "/boton_volver";
            PUNTOS  = NOMBRE + "/boton_puntos";
            VENT_PUNTOS = "Canvas/ui_ventana_puntos";
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

        public void activar()
        {
            enClick(NOMBRE, true);
            GameObject.Find(VOLVER).GetComponent<Button>().onClick.AddListener(() => enClick(NOMBRE, false));
            GameObject.Find(PUNTOS).GetComponent<Button>().onClick.AddListener(() => activarPuntos());
        }

        public void activarPuntos()
        {
            enClick(NOMBRE, false);
            enClick(VENT_PUNTOS, true);
            GameObject.Find(VENT_PUNTOS + "/cantidad").GetComponent<Text>().text = GameObject.Find("Hero").GetComponent<atrib>().getPuntosNoGastados() + "";
            GameObject.Find(VENT_PUNTOS + "/boton_cerrar").GetComponent<Button>().onClick.AddListener(() => desactivarPuntos());
        }

        public void desactivarPuntos()
        {
            enClick(NOMBRE, true);
            enClick(VENT_PUNTOS, false);
        }

    }
}
