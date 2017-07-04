using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class recargarEventos : MonoBehaviour
    {

	    void Start ()
        {
            GameObject.Find("control/diario").GetComponent<diario>().recargarEventos();
	    }
        
    }
}
