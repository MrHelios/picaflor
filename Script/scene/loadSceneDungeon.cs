using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class loadSceneDungeon : MonoBehaviour {    

        private void Awake()
        {
            armarHero();
            armarDungeon();
        }

        private void armarHero()
        {
            GameObject hero = GameObject.Find("Hero");

            hero.gameObject.GetComponent<Collider2D>().enabled = true;
            hero.gameObject.GetComponent<atribPrincipalesPlayer>().ubicarHeroe();
            hero.gameObject.GetComponent<atribPrincipalesPlayer>().reestablecerMaxVida();

            DestroyImmediate(hero.GetComponent<conservarHero>());

            MonoBehaviour[] comp = hero.gameObject.GetComponents<MonoBehaviour>();
            for (int i = 0; i < comp.Length; i++)
                comp[i].enabled = true;
            
            for (int i = 0; i < hero.transform.childCount; i++)
            {
                GameObject hijo = hero.transform.GetChild(i).gameObject;
                if (hijo.GetComponent<SpriteRenderer>() != null)
                {
                    hijo.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
            //GameObject.Find("Hero").gameObject.GetComponent<reinicioNivelPlayer>().cosasNecesarioReiniciar();
        }

        private void armarDungeon()
        {
            GameObject dung = GameObject.Find("Dungeon");
            objeto[] datos = { new objeto("cesped_oscuro_fondo", 1),
                               new objeto("arbol_sin_hojas", 2),
                               new objeto("arbol_copa", 1)
            };

            datos[0].insertarPos(0, new Vector3(0, 0, 0));
            datos[1].insertarPos(0, new Vector3(3.94f, 1.82f, 0));
            datos[1].insertarPos(1, new Vector3(1.97f, -3.94f, 0));
            datos[2].insertarPos(0, new Vector3(-4.22f, -4.06f, 0));

            for (int i = 0; i < datos.Length; i++)
            {
                for (int j = 0; j < datos[i].getCant(); j++)
                {
                    GameObject obj = Instantiate(GameObject.Find(datos[i].getNombre()));
                    obj.transform.parent = dung.transform;
                    obj.name = datos[i].getNombre() + "_" + (j+1);
                    obj.transform.position = datos[i].obtenerPos(j);

                    obj.GetComponent<SpriteRenderer>().enabled = true;
                }
            }
        }

        protected class objeto {

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
