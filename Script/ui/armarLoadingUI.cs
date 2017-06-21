using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class armarLoadingUI : armarUI
    {

	    void Start ()
        {
            ventanaActual();
            armarLoading();
	    }

        private void armarLoading()
        {
            transform.GetChild(0).gameObject.transform.position = new Vector3(wx - 100, 50, 0);
        }
	    
    }
}
