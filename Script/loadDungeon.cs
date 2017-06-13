using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class loadDungeon : MonoBehaviour {

        public string nombreGO;
	
	    void Awake () {
            load();
	    }

        public string getNombre()
        {
            return nombreGO;
        }

        private void load()
        {
            GameObject dung = GameObject.Find("Dungeon");
            GameObject load_go = GameObject.Find(nombreGO);

            for (int i = 0; i < load_go.transform.childCount; i++)
            {
                GameObject obj = load_go.transform.GetChild(i).gameObject;
                
                GameObject nuevo = Instantiate(GameObject.Find(obj.name));
                nuevo.transform.parent = dung.transform;
                nuevo.transform.position = obj.transform.position;

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

    }
}

