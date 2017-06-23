using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class testInicioSistemaArmas : MonoBehaviour {

        private GameObject sistema_arma;
	
	    void Start ()
        {
            sistema_arma = GameObject.Find("SistemaArmas");

            testCantidadClases(sistema_arma);
            testTu();
            testTodasArmas();

            IntegrationTest.Pass();
        }

        private void testCantidadClases(GameObject SA)
        {
            int cant = 2;
            if (SA.transform.childCount != cant)
            {
                Debug.Log(SA);
                Debug.Log("La cantidad de obejtos no es correcto.");
                Debug.Log("Se esperaba: "  + cant + " -> " + SA.transform.childCount);
                IntegrationTest.Fail();
            }
        }

        private void testTu()
        {
            GameObject tu = sistema_arma.transform.GetChild(0).gameObject;
            if (tu.name != "tusArmas")
            {
                Debug.Log(tu);
                Debug.Log("No estan las armas del jugador.");
                IntegrationTest.Fail();
            }

            int cant = 0;
            if (tu.transform.childCount != cant)
            {
                Debug.Log(tu);
                Debug.Log("La cantidad de obejtos no es correcto.");
                Debug.Log("Se esperaba: " + cant + " -> " + tu.transform.childCount);
                IntegrationTest.Fail();
            }            
        }

        private void testTodasArmas()
        {
            GameObject armas = sistema_arma.transform.GetChild(1).gameObject;
            if (armas.name != "todasLasArmas")
            {
                Debug.Log(armas);
                Debug.Log("No estan todas las armas del juego.");
                IntegrationTest.Fail();
            }

            int cant = 3;
            if (armas.transform.childCount != cant)
            {
                Debug.Log(cant);
                Debug.Log("La cantidad de obejtos no es correcto.");
                Debug.Log("Se esperaba: " + cant + " -> " + armas.transform.childCount);
                IntegrationTest.Fail();
            }
        }
        
    }
}

