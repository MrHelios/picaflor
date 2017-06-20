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

            arma_actual.GetComponent<SpriteRenderer>().sprite = arma.GetComponent<SpriteRenderer>().sprite;
            arma_actual.GetComponent<atribArma>().setDamage(arma.GetComponent<atribArma>().getDamage());            
        }
    }
}
