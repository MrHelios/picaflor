using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace test010
{
    public class armarUI : MonoBehaviour {

        protected float wx;
        protected float hy;
	
	    void Start () {
            ventanaActual();            
            inGame();
            armarInventario();
        }

        protected void ventanaActual()
        {
            hy = Screen.height;
            wx = Screen.width;
        }        

        private void inGame()
        {
            //22
            transform.GetChild(0).gameObject.transform.position = new Vector3(40, 53, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3(40, 31, 0);
            transform.GetChild(2).gameObject.transform.position = new Vector3(40, 9, 0);

            transform.GetChild(9).gameObject.transform.position = new Vector3(wx * 0.5f - 190, hy * 0.05f + 20, 0);
            transform.GetChild(3).gameObject.transform.position = new Vector3(wx * 0.5f, 40, 0);

            transform.GetChild(8).gameObject.transform.position = new Vector3(wx * 0.25f, hy * 0.5f, 0);
            transform.GetChild(8).transform.GetChild(4).transform.position = new Vector3(wx * 0.5f, 0 + 40, 0);
        }

        private void armarInventario()
        {
            GameObject vent = GameObject.Find("Canvas/ui_ventana_inventario");
            Button boton = GameObject.Find("Canvas/ui_panel_personaje/boton_inventario").gameObject.GetComponent<Button>();            

            boton.onClick.AddListener(() => armarVentana(vent));
        }

        public void armarVentana(GameObject vent)
        {
            vent.SetActive(true);

            GameObject hero = GameObject.Find("control/HeroInventario");

            GameObject boton = vent.transform.GetChild(2).gameObject;
            inventario inv = hero.GetComponent<inventario>();
            item[] it = hero.GetComponents<item>();

            for (int i = 0; i < inv.cantidad(); i++)
            {
                GameObject nuevo = Instantiate(boton);
                nuevo.transform.parent = vent.transform;
                nuevo.transform.position = new Vector2(boton.transform.position.x + i * 51, boton.transform.position.y);
                nuevo.SetActive(true);
                nuevo.transform.GetChild(0).gameObject.GetComponent<Text>().text = it[i].getCantidad() + "";
            }
            
            GameObject b = GameObject.Find("Canvas").transform.GetChild(11).gameObject.transform.GetChild(1).gameObject;            
            b.SetActive(true);
            if (b.GetComponent<adminVentanas>() == null)
            {                
                b.AddComponent<adminVentanas>();
                b.GetComponent<adminVentanas>().setVentana(b.transform.parent.gameObject);
                b.GetComponent<adminVentanas>().cerrar_ventana_i();
            }
        }

    }
}
