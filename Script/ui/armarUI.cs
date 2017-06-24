using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class armarUI : MonoBehaviour {

        protected float wx;
        protected float hy;
	
	    void Start () {
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
            transform.GetChild(0).gameObject.transform.position = new Vector3(40, hy - 50, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3(40, hy - 72, 0);
            transform.GetChild(2).gameObject.transform.position = new Vector3(40, hy - 94, 0);
            transform.GetChild(3).gameObject.transform.position = new Vector3(wx * 0.5f, hy * 0.05f, 0);

            transform.GetChild(8).gameObject.transform.position = new Vector3(wx * 0.25f, hy * 0.5f, 0);
            transform.GetChild(8).transform.GetChild(4).transform.position = new Vector3(wx * 0.5f, 0 + 40, 0);
        }

    }
}
