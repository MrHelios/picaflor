using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class sistemaAtajo : MonoBehaviour {
        
        void Start()
        {        
            armarLibroAtajos();            
        }
        
        public void armarLibroAtajos()
        {

            for (int i = 0; i < 2; i++)
            {
                // Busca las habilidades de tu heroe..
                GameObject tu = GameObject.Find("SistemaClases").transform.GetChild(0).gameObject;
                // En que atajo estara.
                int pos = i;

                habilidad h = tu.transform.GetChild(i).GetComponent<habilidad>();

                GameObject hero = gameObject;
                GameObject atajo = hero.transform.GetChild(pos).gameObject;
                atajo.AddComponent(h.GetType());
                atajo.GetComponent<habilidad>().queTecla();

                // Agrega icono a la barra de atajos.
                atajo = GameObject.Find("ui_panel_atajos").transform.GetChild(pos).gameObject;
                string[] nombre_hab = h.GetType().ToString().Split('.');
                int max = nombre_hab.Length - 1;
                atajo.GetComponent<Image>().sprite = GameObject.Find(nombre_hab[max]).GetComponent<habilidad>().icono_hab;
            }

        }        

    }
}
