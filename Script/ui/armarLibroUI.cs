using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class armarLibroUI : MonoBehaviour {    

        public void armar()
        {
            string clase = GameObject.Find("Hero").gameObject.GetComponent<atribPrincipalesPlayer>().clase;
            GameObject heroe = GameObject.Find(clase);

            for (int i = 0; i < heroe.transform.childCount; i++)
            {
                if (heroe.transform.GetChild(i).GetComponent<habilidad>() != null)
                {
                    gameObject.transform.GetChild(i).GetComponent<Image>().sprite = heroe.transform.GetChild(i).GetComponent<habilidad>().icono_hab;
                    if (heroe.transform.GetChild(i).GetComponent<habilidad>().getNivelNecesario() > GameObject.Find("Hero").gameObject.GetComponent<atribPrincipalesPlayer>().queNivel())
                    {                    
                        gameObject.transform.GetChild(i).GetComponent<Button>().interactable = false;
                    }
                    else
                    {                    
                        gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;
                    }
                }
            }
        }

        private void armarLibro()
        {
            GameObject tu = GameObject.Find("SistemaClases").transform.GetChild(0).gameObject;

            for (int i = 0; i < tu.transform.childCount; i++)
            {
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = tu.transform.GetChild(i).GetComponent<habilidad>().icono_hab;
                gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;                
            }
        }

        void Start()
        {
            armarLibro();
        }

    }
}
