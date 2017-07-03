using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class armarInventario : MonoBehaviour
    {
        private string UBICACION;

        private void Start()
        {
            UBICACION = "Canvas/ui_ventana_inventario";
        }

        public void armarVentana()
        {
            destruirInventario();

            GameObject vent = GameObject.Find(UBICACION);
            GameObject hero = GameObject.Find("control/HeroInventario");            

            GameObject boton = vent.transform.GetChild(0).gameObject;
            boton.SetActive(false);
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
        }

        private void destruirInventario()
        {
            GameObject go = GameObject.Find("Canvas/ui_ventana_inventario");

            for (int i = 1; i < go.transform.childCount; i++)
            {
                GameObject hijo = go.transform.GetChild(i).gameObject;
                DestroyImmediate(hijo);
            }
        }

    }
}
