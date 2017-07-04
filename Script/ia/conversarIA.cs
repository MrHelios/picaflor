using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class conversarIA : MonoBehaviour
    {
        public string saludo;
        public string rumor;

        protected GameObject canvas;        
        protected GameObject ui_conversar;
        protected GameObject hero;

        private static string NOMBRE_UI;

	    void buscar() {
            ui_conversar = GameObject.Find("Canvas/ui_ventana_conversar");
            hero = GameObject.Find("Hero");
	    }

        public void activar()
        {            
            buscar();

            for (int i = 0; i < ui_conversar.transform.childCount; i++)
            {
                GameObject hijo = ui_conversar.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<Image>() != null)
                    hijo.GetComponent<Image>().enabled = true;

                if (hijo.GetComponent<Text>() != null)
                    hijo.GetComponent<Text>().enabled = true;

                if (hijo.GetComponent<Button>() != null)
                    hijo.GetComponent<Button>().enabled = true;

                for (int j = 0; j < hijo.transform.childCount; j++)
                {
                    if (hijo.transform.GetChild(j).GetComponent<Text>() != null)
                        hijo.transform.GetChild(j).GetComponent<Text>().enabled = true;
                }

            }
            
            hero.GetComponent<movJugador>().enabled = false;
            hero.transform.GetChild(0).gameObject.SetActive(false);

            armarDialogo();            
        }

        private void armarDialogo()
        {
            Button boton_rumor = GameObject.Find("Canvas/ui_ventana_conversar/boton_rumor").gameObject.GetComponent<Button>();
            boton_rumor.onClick.AddListener(() => armarRumor());

            Button boton_salir = GameObject.Find("Canvas/ui_ventana_conversar/boton_salir").gameObject.GetComponent<Button>();
            boton_salir.onClick.AddListener(() => desactivar());

            mision m = gameObject.GetComponent<mision>();
            if (m != null && m.cumpleRequisito())
            {
                ui_conversar.transform.GetChild(5).gameObject.SetActive(true);
                Button boton_mision = ui_conversar.transform.GetChild(5).gameObject.GetComponent<Button>();
                boton_mision.transform.GetChild(0).gameObject.GetComponent<Text>().text = m.getNombre();
                boton_mision.onClick.AddListener(() => armarMision(m));
            }
            else
                ui_conversar.transform.GetChild(5).gameObject.SetActive(false);

            armarSaludo();
        }

        private void armarSaludo()
        {
            Text texto = ui_conversar.transform.GetChild(4).gameObject.GetComponent<Text>();
            texto.text = saludo;
        }

        private void armarRumor()
        {
            Text texto = ui_conversar.transform.GetChild(4).gameObject.GetComponent<Text>();
            texto.text = rumor;
        }

        private void armarMision(mision q)
        {            
            Text texto = ui_conversar.transform.GetChild(4).gameObject.GetComponent<Text>();

            if (!q.estaAgregado())
            {
                texto.text = q.getInfoPre();
                q.agregarAlDiario();
                q.crearEventoMision();
            }
            else if (q.estaTerminada())
            {
                texto.text = q.getInfoPost();
                q.seCompleto();
            }
            else
            {
                texto.text = "";
            }
        }

        public void desactivar()
        {
            bool estado = false;

            for (int i = 0; i < ui_conversar.transform.childCount; i++)
            {
                GameObject hijo = ui_conversar.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<Image>() != null)
                    hijo.GetComponent<Image>().enabled = estado;

                if (hijo.GetComponent<Text>() != null)
                    hijo.GetComponent<Text>().enabled = estado;

                if (hijo.GetComponent<Button>() != null)
                    hijo.GetComponent<Button>().enabled = estado;

                for (int j = 0; j < hijo.transform.childCount; j++)
                {
                    if (hijo.transform.GetChild(j).GetComponent<Text>() != null)
                        hijo.transform.GetChild(j).GetComponent<Text>().enabled = estado;
                }

            }

            hero.GetComponent<movJugador>().enabled = !estado;
            hero.transform.GetChild(0).gameObject.SetActive(!estado);

            GameObject.Find("Canvas/ui_ventana_conversar/boton_rumor").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("Canvas/ui_ventana_conversar/boton_salir").GetComponent<Button>().onClick.RemoveAllListeners();
            GameObject.Find("Canvas/ui_ventana_conversar/boton_mision").GetComponent<Button>().onClick.RemoveAllListeners();
        }

    }
}
