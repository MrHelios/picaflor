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
        private GameObject texto;

        public void armar()
        {
            destruirDiario();
            hero = GameObject.Find("control/diario");

            texto = gameObject.transform.GetChild(0).gameObject;
            texto.GetComponent<Text>().text = "";

            entrada = gameObject.transform.GetChild(1).gameObject;
            entrada.SetActive(false);

            mision[] s = hero.GetComponent<diario>().getHistorial();
            
            for (int i = 0; i < s.Length; i++)
            {
                GameObject e = Instantiate(entrada);
                e.transform.parent = entrada.transform.parent.transform;
                e.transform.position = new Vector2(entrada.transform.position.x, entrada.transform.position.y - i*25);

                e.transform.GetChild(0).gameObject.GetComponent<Text>().text = s[i].getNombre();
                e.AddComponent<Button>();
                e.AddComponent<info_mision_UI>();
                e.GetComponent<info_mision_UI>().setInfo(s[i].getInfoPre());
                e.GetComponent<Button>().onClick.AddListener(() => e.GetComponent<info_mision_UI>().agregarInfo());
                e.SetActive(true);
            }
        }        

        private void destruirDiario()
        {
            GameObject go = GameObject.Find("Canvas/ui_ventana_diario");

            for (int i = 2; i < go.transform.childCount; i++)
            {
                GameObject hijo = go.transform.GetChild(i).gameObject;
                Destroy(hijo);
            }
        }

    }
}
