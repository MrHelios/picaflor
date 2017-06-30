using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class armarMenuUI : armarUI
    {
        private static float ALTURA;

	    void Start () {
            ALTURA = 0.25f;
            ventanaActual();
            efectoMenu();
	    }

	    private void efectoMenu () {            
            transform.GetChild(0).gameObject.transform.position = new Vector3(wx * 0.5f, hy * ALTURA + 35, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3(wx * 0.5f, hy * ALTURA, 0);
            transform.GetChild(2).gameObject.transform.position = new Vector3(wx * 0.5f, hy * ALTURA - 35, 0);

            transform.GetChild(3).gameObject.transform.position = new Vector3(100, 15, 0);
        }
    }
}
