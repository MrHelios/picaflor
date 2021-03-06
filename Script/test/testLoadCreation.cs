﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class testLoadCreation : MonoBehaviour {
	
	    void Start () {
            testLoadDungeon();
            IntegrationTest.Pass();
	    }

        private void testLoadDungeon()
        {
            GameObject dC = GameObject.Find("dungeonConf");
            if (dC == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe dungeonConf");
            }

            GameObject dung = GameObject.Find("Dungeon");
            if (dung == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe Dungeon");
            }

            
            GameObject load = GameObject.Find(dC.GetComponent<loadDungeonNaturaleza>().getNombre());
            if (load == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe load");
            }

            GameObject inv = GameObject.Find("control/Inventario/moneda");
            if (inv == null)
            {
                IntegrationTest.Fail();
                Debug.Log("No existe el inventario moneda.");
            }            

            if (load.transform.childCount == dung.transform.childCount)
            {
                for (int i = 0; i < dung.transform.childCount; i++)
                {
                    GameObject hijo_dung = dung.transform.GetChild(i).gameObject;
                    GameObject hijo_backup = load.transform.GetChild(i).gameObject;                    

                    if (hijo_backup.name.Contains(hijo_dung.name))
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + hijo_dung.name + " -> " + hijo_backup.name);
                        Debug.Log("El nombre no es el mismo.");
                    }

                    if (hijo_backup.transform.position != hijo_dung.transform.position)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + hijo_dung.transform.position + " -> " + hijo_backup.transform.position);
                        Debug.Log("La posicion no es correcta.");
                    }

                    if (hijo_backup.transform.rotation != hijo_dung.transform.rotation)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + hijo_dung.transform.rotation + " -> " + hijo_backup.transform.rotation);
                        Debug.Log("La rotation no es correcta.");
                    }

                    if (hijo_backup.transform.localScale != hijo_dung.transform.localScale)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Se esperaba: " + hijo_dung.transform.localScale + " -> " + hijo_backup.transform.localScale);
                        Debug.Log("La localScale no es correcta.");
                    }

                    if (hijo_dung.tag != "Enemy" && !hijo_dung.GetComponent<SpriteRenderer>().enabled)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("No es enemigo");
                        Debug.Log(hijo_dung + " la imagen no esta activa.");
                    }
                    else if (hijo_dung.tag == "Enemy" && !hijo_dung.transform.GetChild(0).gameObject.activeSelf && !hijo_dung.transform.GetChild(1).gameObject.activeSelf)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("Es enemigo");
                        Debug.Log(hijo_dung + " la imagen no esta activa.");
                    }

                    if (hijo_dung.tag == "Obstaculo" && !hijo_dung.GetComponent<Collider2D>().enabled)
                    {
                        IntegrationTest.Fail();
                        Debug.Log("El objeto de tag Obstaculo el Collider2D esta desactivado.");
                        Debug.Log(hijo_dung);
                    }
                }
            }
            else
            {
                IntegrationTest.Fail();
                Debug.Log("load: " + load.transform.childCount);
                Debug.Log("dung: " + dung.transform.childCount);
                Debug.Log("No tiene la misma cantidad de hijos.");
            }
        }	
    }
}

