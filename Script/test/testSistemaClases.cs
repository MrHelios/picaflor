using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class testSistemaClases : MonoBehaviour
    {
	
	    void Start ()
        {
            GameObject sistema_clases = GameObject.Find("SistemaClases").gameObject;

            correctaCantClases(sistema_clases);
            estaClaseTu(sistema_clases);
            estaClaseMago(sistema_clases);
            analizarHabilidades(sistema_clases);

            IntegrationTest.Pass();
	    }

        private void correctaCantClases(GameObject sist_clases)
        {
            Vector3 v = new Vector3(0, 0, 0);
            if (sist_clases.transform.position != v)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba: " + sist_clases.transform.position + " -> " + v);
            }

            int cant = sist_clases.transform.childCount;
            if (cant != 2)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba 2 clases y se encontraron " + cant);
            }
        }

        private void analizaClase(GameObject clase, string n, int c)
        {
            string nombre = clase.name;
            string nomb_clase = n;
            if (nombre != nomb_clase)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba nombre " + nomb_clase + " -> " + nombre);
            }

            int cant_hijo = c;
            if (clase.transform.childCount != cant_hijo)
            {
                IntegrationTest.Fail();
                Debug.Log("Se esperaba cantidad " + cant_hijo + " -> " + clase.transform.childCount);
            }
        }
        
        private void estaClaseTu(GameObject sist_clase)
        {
            GameObject clase = sist_clase.transform.GetChild(0).gameObject;
            analizaClase(clase, "Tu", 0);
        }

        private void estaClaseMago(GameObject sist_clases)
        {
            GameObject clase = sist_clases.transform.GetChild(1).gameObject;
            analizaClase(clase, "Mago", 4);
        }

        private void analizarHabilidades(GameObject sist_clase)
        {
            GameObject clase = sist_clase.transform.GetChild(1).gameObject;            

            for (int i = 0; i < clase.transform.childCount; i++)
            {
                GameObject hijo = clase.transform.GetChild(i).gameObject;

                Vector3 v = new Vector3(0, 0, 0);
                if (hijo.transform.position != v)
                {
                    IntegrationTest.Fail();
                    Debug.Log("Se esperaba: " + hijo.transform.position + " -> " + v);
                }

                if (hijo.GetComponent<habilidad>() == null || hijo.GetComponent<habilidad>().enabled)
                {
                    IntegrationTest.Fail();
                    Debug.Log(hijo);
                    Debug.Log("Se esperaba que hubiera una habilidad o ésta está activa.");
                }                
            }
        }

    }
}
