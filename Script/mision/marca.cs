using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class marca : MonoBehaviour
    {
        public string nombre_mision;        
        public int escena;

        public void misionTerminada()
        {
            if (GameObject.Find("control/diario").GetComponent<diario>().estaMision(nombre_mision))
                GameObject.Find("control/diario").GetComponent<diario>().getMision(nombre_mision).terminasteNoEntregaste();
            else
                Debug.Log("No esta la mision en el diario.");
        }        
    }
}
