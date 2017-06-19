using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace test010
{
    public class test : MonoBehaviour {

        private int habilidad;
        private int cant_habilidades;        

        public void setHabilidad(int i)
        {
            habilidad = i;
        }

        public int getHabilidad()
        {
            return habilidad;
        }

        public void listaDeAtajos()
        {
            cant_habilidades = 5;
            GameObject go = gameObject.transform.parent.GetChild(GameObject.Find("panel_libroHabilidades").transform.childCount - 1).gameObject;
            go.SetActive(true);

            bool encontrado = false;
            GameObject clase = null;
            for (int i = 0; i < cant_habilidades && !encontrado; i++)
            {
                clase = GameObject.Find("Mago").transform.GetChild(i).gameObject;
                encontrado = clase.GetComponent<habilidad>().icono_hab == gameObject.GetComponent<Image>().sprite;
                if (encontrado)
                    GameObject.Find("habilidadNueva").gameObject.GetComponent<test>().setHabilidad(i);
            }
        }

        public void cambiarAtajos()
        {
            int i = GameObject.Find("habilidadNueva").GetComponent<test>().getHabilidad();        
            GameObject.Find("habilidadNueva").SetActive(false);

            int j;
            int.TryParse(gameObject.name, out j);        

            habilidad h = GameObject.Find("Hero").transform.GetChild(j).GetComponent<habilidad>();
            Destroy(h);

            habilidad h_nueva = GameObject.Find("Mago").transform.GetChild(i).GetComponent<habilidad>();        
            GameObject.Find("Hero").transform.GetChild(j).gameObject.AddComponent(h_nueva.GetType());        

            GameObject.Find("Hero").GetComponent<sistemaAtajo>().armarLibroAtajos();        
        } 
    
    }
}
