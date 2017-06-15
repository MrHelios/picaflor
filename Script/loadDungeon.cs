using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class loadDungeon : MonoBehaviour {

        public string nombreGO;	    

        public string getNombre()
        {
            return nombreGO;
        }

        protected void load_d()
        {
            GameObject dung = GameObject.Find("Dungeon");
            GameObject load_go = GameObject.Find(nombreGO);

            for (int i = 0; i < load_go.transform.childCount; i++)
            {
                GameObject obj = load_go.transform.GetChild(i).gameObject;
                
                GameObject nuevo = Instantiate(GameObject.Find(obj.name));
                nuevo.transform.parent = dung.transform;
                nuevo.transform.position = obj.transform.position;
                nuevo.transform.rotation = obj.transform.rotation;
                nuevo.transform.localScale = obj.transform.localScale;

                if (nuevo.tag == "Enemy")
                {
                    nuevo.transform.GetChild(0).gameObject.SetActive(true);
                    nuevo.transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (nuevo.tag == "Ground")
                    nuevo.GetComponent<SpriteRenderer>().enabled = true;
                else if (nuevo.tag == "Obstaculo")
                {
                    nuevo.GetComponent<SpriteRenderer>().enabled = true;
                    nuevo.GetComponent<Collider2D>().enabled = true;
                }
            }
        }

        protected void load_script_imagen_h()
        {
            GameObject hero = GameObject.Find("Hero");

            MonoBehaviour[] scripts = hero.GetComponents<MonoBehaviour>();
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].enabled = true;
            }

            hero.GetComponent<Collider2D>().enabled = true;

            for (int i = 0; i < hero.transform.childCount; i++)
            {
                if (hero.transform.GetChild(i).GetComponent<SpriteRenderer>() != null && hero.transform.GetChild(i).name != "sangreHero")
                    hero.transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        protected void load_class()
        {
            string[] datos = { "dispJugador", "rajar" };

            GameObject SC = GameObject.Find("SistemaClases");
            GameObject tu = SC.transform.GetChild(0).gameObject;

            for (int i = 0; i < datos.Length; i++)
            {
                GameObject hab = GameObject.Find(datos[i]);
                GameObject nuevo = Instantiate(hab);

                nuevo.transform.parent = tu.transform;
                nuevo.name = hab.name;
            }
        }
    }
}

