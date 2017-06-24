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

	    void Awake () {
            canvas = GameObject.Find("Canvas");
            ui_conversar = canvas.transform.GetChild(8).gameObject;
	    }

        public void activar()
        {
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

        public void desactivar()
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject hijo = canvas.transform.GetChild(i).gameObject;
                hijo.SetActive(true);
            }
            ui_conversar.SetActive(false);
        }

    }
}
