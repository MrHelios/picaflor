using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class sistemaAtajo : MonoBehaviour {

        void Start()
        {        
            armarLibroAtajos();
        }

        public void armarLibroAtajos()
        {
            for (int i = 0; i < 5; i++)
                if (gameObject.transform.GetChild(i).GetComponent<habilidad>() != null)
                {
                    habilidad h = gameObject.transform.GetChild(i).GetComponents<habilidad>()[gameObject.transform.GetChild(i).GetComponents<habilidad>().Length - 1];                
                    GameObject.Find("panel_habilidades").gameObject.transform.GetChild(i).GetComponent<Image>().sprite = GameObject.Find(h.GetType().ToString()).GetComponent<SpriteRenderer>().sprite;                
                }
        }

    }
}
