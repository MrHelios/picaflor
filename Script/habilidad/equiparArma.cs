using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class equiparArma : MonoBehaviour {

        private string nombre_baston, nombre_hacha;
        private GameObject arma_imagen;
        private GameObject arma_actual;

	    void Start () {
            nombre_baston = "baston02";
            nombre_hacha = "hacha01";
            arma_imagen = gameObject.transform.GetChild(gameObject.transform.childCount - 2).gameObject;
            arma_actual = gameObject.transform.GetChild(gameObject.transform.childCount - 1).gameObject;

            equipar();
	    }

        public void setArma(string s)
        {
            nombre_baston = s;
        }

        public void equipar()
        {
            GameObject arma = GameObject.Find(nombre_baston).gameObject;
            
            arma_actual.GetComponent<atribArma>().setDamage(arma.GetComponent<atribArma>().getDamage());
            establecer_arma_imagen();
        }

        private void establecer_arma_imagen()
        {
            GameObject arma_b = GameObject.Find(nombre_baston).gameObject;
            GameObject arma_h = GameObject.Find(nombre_hacha).gameObject;

            // baston
            arma_imagen.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = arma_b.gameObject.GetComponent<SpriteRenderer>().sprite;
            // espada
            arma_imagen.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = arma_h.gameObject.GetComponent<SpriteRenderer>().sprite;

            // envainada
            arma_imagen.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = arma_h.gameObject.GetComponent<SpriteRenderer>().sprite;
        }

    }
}
