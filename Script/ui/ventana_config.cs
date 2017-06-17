using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class ventana_config : adminVentanas {
	
	    void Start () {
            int pos_vent = 6;
            GameObject go = GameObject.Find("Canvas").transform.GetChild(pos_vent).gameObject;

            setVentana(go);
            abrir_ventana();
        }	
	
    }

}
