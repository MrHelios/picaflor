using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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


        public abstract bool cumpleRequisito();

        public abstract bool puedeTerminar();

        public abstract void agregarAlDiario();

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
