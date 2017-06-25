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

	    void buscar() {
            canvas = GameObject.Find("Canvas");
            ui_conversar = canvas.transform.GetChild(8).gameObject;
            hero = GameObject.Find("Hero");
	    }

        public void activar()
        {
            buscar();

            hero.GetComponent<movJugador>().enabled = false;
            hero.transform.GetChild(0).gameObject.SetActive(false);

            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                GameObject hijo = canvas.transform.GetChild(i).gameObject;
                if (hijo.activeSelf)
                    hijo.SetActive(false);                
            }
            ui_conversar.SetActive(true);

            armarDialogo();
        }

        private void armarDialogo()
        {
            Button boton_rumor = ui_conversar.transform.GetChild(2).gameObject.GetComponent<Button>();
            boton_rumor.onClick.AddListener(() => armarRumor());

            Button boton_salir = ui_conversar.transform.GetChild(3).gameObject.GetComponent<Button>();
            boton_salir.onClick.AddListener(() => desactivar());

            mision m = gameObject.GetComponent<mision>();
            if (m != null && m.cumpleRequisito() && !m.estaCompletado())
            {
                ui_conversar.transform.GetChild(5).gameObject.SetActive(true);
                Button boton_mision = ui_conversar.transform.GetChild(5).gameObject.GetComponent<Button>();
                boton_mision.transform.GetChild(0).gameObject.GetComponent<Text>().text = m.getNombre();
                boton_mision.onClick.AddListener(() => armarMision(m));
            }

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
            }
            else if (q.estaTerminada())
            {
                texto.text = q.getInfoPost();
                q.seCompleto();
            }
        }

        public void desactivar()
        {
            hero.GetComponent<movJugador>().enabled = true;
            hero.transform.GetChild(0).gameObject.SetActive(true);

            for (int i = 0; i < 4; i++)
            {
                GameObject hijo = canvas.transform.GetChild(i).gameObject;
                hijo.SetActive(true);
            }
            ui_conversar.SetActive(false);
            ui_conversar.transform.GetChild(5).gameObject.SetActive(false);
        }

    }
}
