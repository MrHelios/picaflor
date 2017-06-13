using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class creaEnemParaTest : MonoBehaviour
    {
	
	    void Awake () {
            crearEnemigos();
	    }

        private void crearEnemigos()
        {
            GameObject dung = GameObject.Find("Dungeon");
            objeto[] datos = { new objeto("babosa_roja", 1),
                               new objeto("tempestad_oscura", 1),
                               new objeto("druida_salvaje", 1),
            };

            datos[0].insertarPos(0, new Vector3(0, 0, 0));
            datos[1].insertarPos(0, new Vector3(5, 0, 0));
            datos[2].insertarPos(0, new Vector3(-5, 0, 0));

            for (int i = 0; i < datos.Length; i++)
            {
                for (int j = 0; j < datos[i].getCant(); j++)
                {
                    GameObject obj = Instantiate(GameObject.Find(datos[i].getNombre()));
                    obj.transform.parent = dung.transform;
                    obj.name = datos[i].getNombre() + "_" + (j + 1);
                    obj.transform.position = datos[i].obtenerPos(j);

                    obj.GetComponent<Collider2D>().enabled = true;
                    obj.GetComponent<atribPrincipales>().enabled = true;
                    obj.GetComponent<detectarJugadorIA>().enabled = true;

                    obj.transform.GetChild(0).gameObject.SetActive(true);
                    obj.transform.GetChild(1).gameObject.SetActive(true);
                }
            }
        }

        protected class objeto
        {

            string nombre;
            int cant;
            Vector3[] posiciones;

            public objeto(string n, int c)
            {
                nombre = n;
                cant = c;
                posiciones = new Vector3[cant];
            }

            public void insertarPos(int i, Vector3 v)
            {
                posiciones[i] = v;
            }

            public Vector3 obtenerPos(int i)
            {
                return posiciones[i];
            }

            public void setNombre(string s)
            {
                nombre = s;
            }

            public string getNombre()
            {
                return nombre;
            }

            public void setCant(int c)
            {
                cant = c;
            }

            public int getCant()
            {
                return cant;
            }
        }

    }
}


