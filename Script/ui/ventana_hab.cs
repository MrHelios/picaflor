using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class ventana_hab : adminVentanas {
	    
	    void Start() {
            int pos_vent = 5;
            GameObject go = GameObject.Find("Canvas").transform.GetChild(pos_vent).gameObject;

            setVentana(go);
            abrir_ventana();
	    }	
	    
    }
}

