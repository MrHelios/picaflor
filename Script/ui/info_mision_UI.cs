using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{

    public class info_mision_UI : MonoBehaviour
    {
        private string info_agregar;
        private string UBICACION;

        private void Start()
        {
            UBICACION = "Canvas/ui_ventana_diario/texto";
        }

        public void setInfo(string s)
        {
            info_agregar = s;
        }

        public void agregarInfo()
        {
            GameObject texto = GameObject.Find(UBICACION);
            texto.GetComponent<Text>().text = info_agregar;
        }

    }

}
