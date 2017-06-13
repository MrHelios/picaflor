using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class testInicioSistemaNaturaleza : MonoBehaviour {    

	    void Start () {
            estaSistemaNaturaleza();
            correctaCantObjetos();
            estaCespedOscuro();
            estaCespedClaro();
            estaBaldosasAguaverdes();
            estaBaldosasGris();
            estaBaldosasVerdes();
            estaColumnas();
            estaFlores();
            estaMonticulos();
            estaRocas();
            estaArboles();

            IntegrationTest.Pass();
        }

        protected void estaSistemaNaturaleza()
        {
            if (GameObject.Find("SistemaNaturaleza") == null)
            {
                Debug.Log("El GameObject de Sistema Naturaleza no esta.");
                IntegrationTest.Fail();
            }
        }


        protected void correctaCantObjetos()
        {
            GameObject sist = GameObject.Find("SistemaNaturaleza");
            int cant = sist.transform.childCount;
            if (cant != 10)
            {
                Debug.Log("La cantidad de objetos es diferente al esperado que era 10: " + cant);
                IntegrationTest.Fail();
            }
        }

        protected void test_nombre_tag_layer(int hijo, string n)
        {
            GameObject sist = GameObject.Find("SistemaNaturaleza");
            GameObject objeto = sist.transform.GetChild(hijo).gameObject;

            string nombre = objeto.name;
            string tag = objeto.tag;
            LayerMask mascara = objeto.layer;

            if (nombre != n || tag != "Untagged" || mascara != LayerMask.NameToLayer("Default"))
            {
                IntegrationTest.Fail();
                Debug.Log(objeto);
                Debug.Log("Nombre: " + nombre);
                Debug.Log("Tag: " + tag);
                Debug.Log("Mascara: " + mascara);                
            }
        }

        protected void estaCespedOscuro()
        {
            test_nombre_tag_layer(0, "cesped_oscuro");            
        }

        protected void estaCespedClaro()
        {
            test_nombre_tag_layer(1, "cesped_claro");            
        }

        protected void estaFlores()
        {
            test_nombre_tag_layer(2, "flores");            
        }

        protected void estaMonticulos()
        {
            test_nombre_tag_layer(3, "monticulos");            
        }

        protected void estaBaldosasGris()
        {
            test_nombre_tag_layer(4, "baldosas_gris");            
        }

        protected void estaBaldosasVerdes()
        {
            test_nombre_tag_layer(5, "baldosas_verde");
        }

        protected void estaBaldosasAguaverdes()
        {
            test_nombre_tag_layer(6, "baldosas_aguaverde");
        }

        protected void estaColumnas()
        {
            test_nombre_tag_layer(7, "columnas");            
        }

        protected void estaRocas()
        {
            test_nombre_tag_layer(8, "rocas");            
        }

        protected void estaArboles()
        {
            test_nombre_tag_layer(9, "arboles");            
        }
	
    }
}
