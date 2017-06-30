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
            for(int i=0; i<transform.childCount; i++)
                transform.GetChild(i).gameObject.transform.position = new Vector3(wx - 100, 50, 0);
        }
	    
    }
}
