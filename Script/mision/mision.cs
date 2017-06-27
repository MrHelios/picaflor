using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public abstract class mision : MonoBehaviour
    {
        protected int posicion;
        protected int campaña;

        protected string nombre;
        protected string info_pre;
        protected string info_post;

        protected bool agregado;
        protected bool terminado_no_entregado;
        protected bool completado;

        public abstract void crearEventoMision();

        public abstract bool cumpleRequisito();

        public abstract bool puedeTerminar();

        public abstract void agregarAlDiario();

        public void animacionTextoMision(string n)
        {
            GameObject canvas_t = GameObject.Find("CanvasTemporal");
            GameObject text = new GameObject();
            text.transform.parent = canvas_t.transform;
            text.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.8f, 0);

            text.AddComponent<Text>();
            text.GetComponent<Text>().text = n + nombre;
            text.GetComponent<Text>().font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.GetComponent<Text>().fontSize = 30;

            var t = text.transform as RectTransform;
            t.sizeDelta = new Vector2(300, 100);

            text.AddComponent<destruirObjeto>();
        }

        public int getPosicion()
        {
            return posicion;
        }

        public int getCampaña()
        {
            return campaña;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getInfoPre()
        {
            return info_pre;
        }

        public string getInfoPost()
        {
            return info_post;
        }

        public bool estaAgregado()
        {
            return agregado;
        }

        public bool estaTerminada()
        {
            return terminado_no_entregado;
        }

        public void terminasteNoEntregaste()
        {
            animacionTextoMision("Terminado: ");
            terminado_no_entregado = true;
        }

        public bool estaCompletado()
        {
            return completado;
        }

        public void seCompleto()
        {
            completado = true;
        }
    }
}
