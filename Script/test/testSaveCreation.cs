using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class testSaveCreation : MonoBehaviour {        
	
	    void Start () {
            testSaveDungeon();
            IntegrationTest.Pass();
	    }

        private void testSaveDungeon()
        {
            GameObject dung = GameObject.Find("Dungeon");
            GameObject config = GameObject.Find("dungeonConf");

            GameObject BACKUP = GameObject.Find(config.GetComponent<saveDungeon>().getNombre());

            if (dung == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe el GO Dungeon.");
            }

            if (BACKUP == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe el BackUp.");
            }

            if (dung.transform.childCount == BACKUP.transform.childCount)
            {                

                for (int i = 0; i < dung.transform.childCount; i++)
                {
                    GameObject hijo_dung = dung.transform.GetChild(i).gameObject;
                    GameObject hijo_backup = BACKUP.transform.GetChild(i).gameObject;                    

                    if (hijo_backup.name.Contains(" "))
                    {
                        IntegrationTest.Fail();
                        Debug.Log(hijo_backup.name + " el nombre del go no esta pulido.");
                    }

                    if (hijo_backup.name.Contains("("))
                    {
                        IntegrationTest.Fail();
                        Debug.Log(hijo_backup.name + " el nombre del go no esta pulido.");
                    }

                    if (hijo_backup.name.Contains(")"))
                    {
                        IntegrationTest.Fail();
                        Debug.Log(hijo_backup.name + " el nombre del go no esta pulido.");
                    }

                    if (hijo_backup.transform.position != hijo_dung.transform.position)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + hijo_dung.transform.position + " -> " + hijo_backup.transform.position);
                        Debug.Log("La posicion no es correcta.");
                    }                    
                }
            }
            else
            {
                IntegrationTest.Fail();
                Debug.Log("El GO Dungeon no tiene ningun hijo.");
            }
        }        

    }
}

