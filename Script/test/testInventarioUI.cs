using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class testInventarioUI : MonoBehaviour
    {

        private GameObject hero;

        void Awake()
        {
            hero = GameObject.Find("Hero");
            hero.AddComponent<inventario>().iniciar();

            GameObject inv = new GameObject("Inventario");
            GameObject mon = new GameObject("moneda");
            mon.transform.parent = inv.transform;
            mon.AddComponent<oro>().iniciar();
        }

        void Start ()
        {
            GameObject enem = new GameObject("enem");
            enem.AddComponent<atribPrincipales>();
            enem.GetComponent<atribPrincipales>().iniciar();
            enem.GetComponent<atribPrincipales>().queDrop(hero);

            GameObject n = new GameObject();
            n.AddComponent<armadura_templario_0>().iniciar();             
            hero.GetComponent<inventario>().agregar(n.GetComponent<item>());

            testCantidad();            
            testVentana();            

            IntegrationTest.Pass();
	    }

        public void testCantidad()
        {
            int hay = hero.GetComponent<inventario>().cantidad();
            int cantidad_esperada = 2;
            if (hay != cantidad_esperada)
            {
                IntegrationTest.Fail();
                Debug.Log("La cantidad de elementos en el inventario no es la que deberia haber.");
            }

            inventario inv = hero.GetComponent<inventario>();            
        }        

        public IEnumerator testVentana()
        {            
            GameObject.Find("Canvas/ui_panel_atajos/boton_inventario").gameObject.GetComponent<Button>().onClick.Invoke();
            GameObject vent = GameObject.Find("Canvas/ui_ventana_inventario");

            inventario inv = hero.GetComponent<inventario>();

            if (!vent.gameObject.activeSelf)
            {
                IntegrationTest.Fail();
                Debug.Log("No esta Activada la ventana");
            }

            if (vent.transform.childCount - 3 != inv.cantidad())
            {
                IntegrationTest.Fail();
                Debug.Log("S esperaba: " + inv.cantidad() + " " + (vent.transform.childCount - 2));
                Debug.Log("La cantidad de elementos en el inventario no es correcto.");
            }
            
            item[] it = hero.GetComponents<item>();

            for (int i = 0; i < inv.cantidad(); i++)
            {
                GameObject nuevo = vent.transform.GetChild(3+i).gameObject;
                if (nuevo.transform.GetChild(0).gameObject.GetComponent<Text>().text != it[i].getCantidad() + "")
                {
                    IntegrationTest.Fail();
                    Debug.Log("El texto no coincide con el inventario");
                }
            }

            Button salir = vent.transform.GetChild(1).GetComponent<Button>();
            salir.onClick.Invoke();
            if (vent.activeSelf)
            {
                IntegrationTest.Fail();
                Debug.Log("La ventana esta abierta incluso despues de cerrarla.");
            }

            yield return new WaitForSeconds(2f);

            if (vent.transform.childCount != 2)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba " + 2 + " -> " + vent.transform.childCount);
            }
        }
	    
    }
}
