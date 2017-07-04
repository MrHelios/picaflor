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
            string n;
            n = "Canvas/ui_vida";
            GameObject.Find(n).gameObject.transform.position = new Vector3(40, 53, 0);
            n = "Canvas/ui_mana";
            GameObject.Find(n).gameObject.transform.position = new Vector3(40, 31, 0);
            n = "Canvas/ui_energia";
            GameObject.Find(n).gameObject.transform.position = new Vector3(40, 9, 0);
            n = "Canvas/ui_panel_atajos";
            GameObject.Find(n).gameObject.transform.position = new Vector3(wx * 0.5f, 40, 0);            
        }

    }
}
