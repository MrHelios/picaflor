using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class testObjetosSN : testInicioSistemaNaturaleza {
	    
	    void Start () {
            estaSistemaNaturaleza();
            correctaCantObjetos();            

            testCespedOscuroFondo();
            testCespedClaro();
            testBaldosasAguaverde();
            testBaldosasGris();
            testBaldosasVerde();
            testColumnas();
            testFlores();
            testMonticulos();

            testArboles();

            IntegrationTest.Pass();
	    }

        private void error_cantidad_objetos(GameObject objeto)
        {
            IntegrationTest.Fail();
            Debug.Log(objeto + " la cantidad de hijos que tiene es incorrecta.");
        }

        private void test_Nombres_Componentes(GameObject padre, string[] d)
        {
            string[] datos = d;
            int j;

            for (int i = 0; i < padre.transform.childCount; i++)
            {
                j = i * 5;
                GameObject objeto = padre.transform.GetChild(i).gameObject;
                string nombre = objeto.name;
                string tag = objeto.tag;
                LayerMask mascara = objeto.layer;

                if (nombre != datos[j] || tag != datos[j + 1] || mascara != LayerMask.NameToLayer(datos[j + 2]))
                {
                    IntegrationTest.Fail();
                    Debug.Log("El nombre, el tag o el layer es incorrecto.");
                    Debug.Log(objeto);
                    Debug.Log("Nombre: " + nombre);
                    Debug.Log("Tag: " + tag);
                    Debug.Log("Layer: " + mascara);
                }

                if (objeto.GetComponent<SpriteRenderer>() == null || objeto.GetComponent<SpriteRenderer>().sprite.name != datos[j + 3] || objeto.GetComponent<SpriteRenderer>().enabled)
                {
                    Debug.Log("El " + objeto + " no tiene la componente SpriteRenderer, el nombre de la imagen es incorrecta o su imagen esta activa.");
                    IntegrationTest.Fail();
                }

                string sort_layer = objeto.GetComponent<SpriteRenderer>().sortingLayerName;
                if (sort_layer != datos[j + 2])
                {
                    IntegrationTest.Fail();
                    Debug.Log(objeto);
                    Debug.Log("Se esperaba " + datos[j + 2] + " -> " + sort_layer);
                }

                int num_sort_layer = objeto.GetComponent<SpriteRenderer>().sortingOrder;
                int x;
                int.TryParse(datos[j + 4], out x);
                if (num_sort_layer != x)
                {
                    IntegrationTest.Fail();
                    Debug.Log(objeto);
                    Debug.Log("El orden de las capas.");
                    Debug.Log("Se esperaba " + x + " -> " + num_sort_layer);
                }
            }
        }

        public void testCespedOscuroFondo()
        {
            int hijo = 0;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "cesped_oscuro_fondo", "Ground", "Ground", "suelo02", "0" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testCespedClaro()
        {
            int hijo = 1;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "cesped_claro_00", "Ground", "Ground", "suelo03", "1" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testBaldosasAguaverde()
        {
            int hijo = 2;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "baldosa_aguaverde", "Ground", "Ground", "baldosas_000_0", "2" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testBaldosasGris()
        {
            int hijo = 3;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "baldosa_gris", "Ground", "Ground", "baldosas_000_2", "2" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testBaldosasVerde()
        {
            int hijo = 4;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "baldosa_verde", "Ground", "Ground", "baldosas_000_1", "2" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testColumnas()
        {
            int hijo = 5;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 1;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "columna00", "Obstaculo", "Obstaculo", "columna00", "0" };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testFlores()
        {
            int hijo = 6;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 3;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "flores_001", "Ground", "Ground", "flores_suelo_001", "2",
                                   "flor_002", "Ground", "Ground","flores_suelo_002_1", "2",
                                   "flor_003", "Ground", "Ground","flores_suelo_002_3", "2",
                };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testMonticulos()
        {
            int hijo = 7;
            GameObject cesped = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 2;
            if (cesped.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(cesped);
            else
            {
                string[] datos = { "monticulo_chico", "Obstaculo", "Obstaculo", "monticulo_000", "0",
                                   "monticulo_mediano", "Obstaculo", "Obstaculo","monticulo_001", "0"
                };
                test_Nombres_Componentes(cesped, datos);
            }
        }

        public void testArboles()
        {
            int hijo = 9;
            GameObject arboles = GameObject.Find("SistemaNaturaleza").transform.GetChild(hijo).gameObject;

            int cant_de_tipos = 2;
            if (arboles.transform.childCount != cant_de_tipos)
                error_cantidad_objetos(arboles);
            else
            {
                string[] datos = { "arbol_sin_hojas","Obstaculo","Obstaculo", "arbol00", "0",
                                   "arbol_copa", "Obstaculo", "Obstaculo", "arbol01", "0" };
                test_Nombres_Componentes(arboles, datos);
            }
        }
	    
    }
}
