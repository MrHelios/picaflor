using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class inventario : MonoBehaviour {

        private int cant;

        void Awake()
        {
            iniciar();
        }

        public void iniciar()
        {
            cant = 0;
        }

        public int cantidad()
        {
            return cant;
        }

        // Agregar Items.
        public void agregar(item i)
        {
            Debug.Log(i);
            if (gameObject.GetComponent(i.GetType()) == null)
            {
                gameObject.AddComponent(i.GetType());
                item it = (item)gameObject.GetComponent(i.GetType());
                it.iniciar();
                it.setCantidad(i.getCantidad());
                cant++;                
            }
            else
            {
                item aux = (item) gameObject.GetComponent(i.GetType());
                aux.cambiarCantidad(i.getCantidad());                
            }
        }        

        public bool estaItem(item i)
        {
            if (gameObject.GetComponent(i.GetType()) == null)
                return false;
            else
                return true;
        }
        

        public item getItem(item i)
        {
            if (gameObject.GetComponent(i.GetType()) != null)
                return (item)gameObject.GetComponent(i.GetType());
            else
                return null;
        }        

    }
}
