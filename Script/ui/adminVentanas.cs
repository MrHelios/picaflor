using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class adminVentanas : MonoBehaviour {

        public GameObject ventana;
        private bool estado;

        private void Start()
        {
            estado = false;
        }

        public void setVentana(GameObject go)
        {
            ventana = go;
            estado = false;
        }

        public void cambiarEstado()
        {
            Debug.Log("Entra");

            if (estado)
                ventana.SetActive(false);
            else
                ventana.SetActive(true);
            estado = !estado;
        }
    

    }
}
