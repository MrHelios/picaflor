using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class equiparArma : MonoBehaviour {

        private string nombre;
        private GameObject arma_actual;

	    void Start () {
            nombre = "baston01";
            arma_actual = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;

            equipar();
	    }

        public void setArma(string s)
        {
            nombre = s;
        }

        public void equipar()
        {
            GameObject arma = GameObject.Find(nombre).gameObject;
            arma_actual.transform.rotation = arma.transform.rotation;
            arma_actual.transform.localScale = arma.transform.localScale;
            arma_actual.GetComponent<SpriteRenderer>().sprite = arma.GetComponent<SpriteRenderer>().sprite;
            arma_actual.GetComponent<atribArma>().setDamage(arma.GetComponent<atribArma>().getDamage());

            for (int i = 0; i < arma_actual.transform.childCount; i++)
                Destroy(arma_actual.transform.GetChild(i).gameObject);

            for (int i = 0; i < arma.transform.childCount; i++)
            {
                GameObject municion = Instantiate(arma.transform.GetChild(i).gameObject);

                municion.transform.parent = arma_actual.transform;
                municion.transform.position = arma.transform.GetChild(i).transform.position;
                municion.transform.rotation = arma.transform.GetChild(i).transform.rotation;
                municion.transform.localScale = arma.transform.GetChild(i).transform.localScale;
            }
        }
    }
}
