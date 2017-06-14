using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class saveDungeon : MonoBehaviour {

        public string nombreGO;

        void Awake()
        {
            save();            
        }

        public string getNombre()
        {
            return nombreGO;
        }

        private void save()
        {
            GameObject dung = GameObject.Find("Dungeon");            

            if (dung != null && dung.transform.childCount != 0)
            {
                GameObject backup = new GameObject(nombreGO);

                for (int i = 0; i < dung.transform.childCount; i++)
                {
                    GameObject hijo = dung.transform.GetChild(i).gameObject;

                    GameObject obj = new GameObject("backup_" + i);
                    obj.transform.parent = backup.transform;
                    obj.transform.position = hijo.transform.position;
                    obj.transform.rotation = hijo.transform.rotation;
                    obj.transform.localScale = hijo.transform.localScale;

                    string[] palabra = acortarPalabra(hijo.name, ' ');
                    obj.name = palabra[0];
                }
            }
        }

        private string[] acortarPalabra(string palabra, char c)
        {
            return palabra.Split(c);
        }

    }

}
