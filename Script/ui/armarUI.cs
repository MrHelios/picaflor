using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class armarUI : MonoBehaviour
    {
        protected float wx;
        protected float hy;
	
	    void Start ()
        {
            ventanaActual();            
            inGame();        
        }

        protected void ventanaActual()
        {
            hy = Screen.height;
            wx = Screen.width;
        }        

        private void inGame()
        {
            transform.GetChild(0).gameObject.transform.position = new Vector3(40, 53, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3(40, 31, 0);
            transform.GetChild(2).gameObject.transform.position = new Vector3(40, 9, 0);

            transform.GetChild(9).gameObject.transform.position = new Vector3(wx * 0.5f - 190, hy * 0.05f + 20, 0);
            transform.GetChild(3).gameObject.transform.position = new Vector3(wx * 0.5f, 40, 0);

            transform.GetChild(8).gameObject.transform.position = new Vector3(wx * 0.25f, hy * 0.5f, 0);
            transform.GetChild(8).transform.GetChild(4).transform.position = new Vector3(wx * 0.5f, 0 + 40, 0);
        }

    }
}
