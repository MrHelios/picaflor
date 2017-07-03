using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace test010
{
    public class armarDiario : MonoBehaviour
    {

        private GameObject hero;
        private GameObject entrada;	    

        public void armar()
        {
            hero = GameObject.Find("control/diario");
            entrada = gameObject.transform.GetChild(2).gameObject;

            mision[] s = hero.GetComponent<diario>().getHistorial();

            for (int i = 0; i < s.Length; i++)
            {
                GameObject e = Instantiate(entrada);
                e.transform.parent = entrada.transform.parent.transform;
                e.transform.position = new Vector2(entrada.transform.position.x, entrada.transform.position.y - i*90);

                e.transform.GetChild(0).gameObject.GetComponent<Text>().text = s[i].getNombre();
                e.transform.GetChild(1).gameObject.GetComponent<Text>().text = s[i].getInfoPre();
                e.SetActive(true);
            }
        }
    }
}
