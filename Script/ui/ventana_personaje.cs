using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class ventana_personaje : MonoBehaviour
    {
        private string UBICACION;
        private string PANEL;
        private string BOTON_CERRAR;
        private string BOTON_PERSONAJE;

        void Start()
        {
            PANEL = "Canvas/ui_panel_personaje";
            BOTON_CERRAR = "Canvas/ui_panel_personaje";
            BOTON_PERSONAJE = "Canvas/ui_panel_personaje/boton_personaje";
            UBICACION = "Canvas/ui_ventana_personaje";
            activar();
            desactivar();
        }

        public void activar()
        {
            Button b = GetComponent<Button>();
            b.onClick.AddListener(() => enClickActivar());

            GameObject go = GameObject.Find(BOTON_PERSONAJE);
            go.GetComponent<Button>().onClick.AddListener(() => enClickActivar());            
        }

        public void enClickActivar()
        {
            GameObject go = GameObject.Find(UBICACION);
            go.GetComponent<organizar_ventana_pj>().enabled = true;
            enClick("Canvas/ui_ventana_diario", false);
            enClick("Canvas/ui_ventana_inventario", false);
            enClick(UBICACION, true);
            act_des_Panel(true);
        }

        public void desactivar()
        {
            GameObject go = GameObject.Find(BOTON_CERRAR + "/boton_cerrar");
            go.GetComponent<Button>().onClick.AddListener(() => enClickDesactivar());
        }

        public void enClickDesactivar()
        {
            GameObject go = GameObject.Find(UBICACION);
            go.GetComponent<organizar_ventana_pj>().enabled = false;
            enClick("Canvas/ui_ventana_diario", false);
            enClick("Canvas/ui_ventana_inventario", false);
            enClick(UBICACION, false);

            // limpieza
            act_des_Panel(false);        
        }        

        private void act_des_Panel(bool e)
        {
            GameObject go = GameObject.Find(PANEL);
            for (int i = 0; i < go.transform.childCount; i++)
            {
                GameObject hijo = go.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<Image>() != null)
                    hijo.GetComponent<Image>().enabled = e;

                if (hijo.GetComponent<Text>() != null)
                    hijo.GetComponent<Text>().enabled = e;

                if (hijo.GetComponent<Button>() != null)
                    hijo.GetComponent<Button>().enabled = e;                
            }
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
