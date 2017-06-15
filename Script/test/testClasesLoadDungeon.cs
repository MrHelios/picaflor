using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class testClasesLoadDungeon : MonoBehaviour
    {
	
	    void Start ()
        {
            comprobarHabilidades();
            IntegrationTest.Pass();
	    }

        private void comprobarHabilidades()
        {
            GameObject clase = GameObject.Find("SistemaClases");
            if (clase == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe la base de datos del sistema clase.");
            }

            GameObject tu = clase.transform.GetChild(0).gameObject;
            int cant_hijos = 2;
            if (tu.transform.childCount != cant_hijos)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba: " + cant_hijos + " -> " + tu.transform.childCount);
            }
            else
            {
                string[] datos = { "dispJugador", "rajar" };

                for (int i = 0; i < cant_hijos; i++)
                    if (tu.transform.GetChild(i).name != datos[i])
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + tu.transform.GetChild(i).name + " -> " + datos[i]);
                    }
            }
        }
    }

}
