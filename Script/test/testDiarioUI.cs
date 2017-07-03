using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testDiarioUI : MonoBehaviour
{    

    void Start()
    {
        GameObject m = new GameObject("dummy");
        m.AddComponent<iniciado>();
        m.GetComponent<iniciado>().agregar();

        GameObject m2 = new GameObject("dummy2");
        m2.AddComponent<limpieza>();
        m2.GetComponent<limpieza>().agregar();
	}
	
}
