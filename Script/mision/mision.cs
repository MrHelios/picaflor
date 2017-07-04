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
        public bool completado;

        public abstract void crearEventoMision();        

        public abstract bool puedeTerminar();

        public abstract void agregarAlDiario();

        public bool cumpleRequisito()
        {
            if (posicion == 0 && !GameObject.Find("control/diario").GetComponent<diario>().estaMision(nombre))
                return true;
            else
            {
                Debug.Log(GameObject.Find("control/diario").GetComponent<diario>().getMision(nombre).completado);
                if (posicion == 0 &&
                    GameObject.Find("control/diario").GetComponent<diario>().estaMision(nombre) &&
                    !GameObject.Find("control/diario").GetComponent<diario>().getMision(nombre).completado)
                    return true;
            }
            return false;
        }

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

        public void seTermino()
        {
            terminado_no_entregado = true;
        }

        public void terminasteNoEntregaste()
        {
            animacionTextoMision("Terminado: ");
            seTermino();
        }

        public bool estaCompletado()
        {
            mision m = GameObject.Find("control/diario").GetComponent<diario>().getMision(nombre);
            if (m == null)
                return false;
            else
                return m.completado;
        }

        public void seCompleto()
        {
            completado = true;
        }
    }
}
