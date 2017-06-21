using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace test010
{
    public class cambiarAtajo : MonoBehaviour {

        private int num_atajo;
	
	    void Start () {
            Button boton = gameObject.GetComponent<Button>();
            boton.onClick.AddListener(() => cambiar());
        }

        private void cambiar()
        {
            // AGREGA HABILIDAD AL HEROE.
            GameObject padre = gameObject.transform.parent.gameObject;
            string nombre = padre.GetComponent<armarLibroUI>().getAtajo().gameObject.name;

            int pos;
            int.TryParse(nombre[nombre.Length - 1] + "", out pos);

            habilidad h = gameObject.GetComponent<habilidad>();
            h.queTecla();

            GameObject hero = GameObject.Find("Hero").gameObject;
            GameObject atajo = hero.transform.GetChild(pos).gameObject;

            habilidad elim_hab = atajo.GetComponent<habilidad>();
            if (elim_hab != null)
                DestroyImmediate(elim_hab); 

            atajo.AddComponent(h.GetType());            

            // AGREGA ICONO AL ATAJO.
            atajo = GameObject.Find("ui_panel_atajos").transform.GetChild(pos).gameObject;
            string[] nombre_hab = h.GetType().ToString().Split('.');
            int max = nombre_hab.Length - 1;
            atajo.GetComponent<Image>().sprite = GameObject.Find(nombre_hab[max]).GetComponent<habilidad>().icono_hab;

            // Cierra la ventana de habilidades mediante el boton cerrar.
            gameObject.transform.parent.GetChild(gameObject.transform.parent.childCount - 1).GetComponent<cerrar_ventana>().cerrar_hab();            
        }
	
    }
}
