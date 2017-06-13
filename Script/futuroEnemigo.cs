using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class futuroEnemigo : MonoBehaviour {

        public string enemigo;
        private Transform posicion;

        void Start () {
            posicion = gameObject.transform;
	    }

        public Transform getPosicion()
        {
            return posicion;
        }

        public string getEnemigo()
        {
            return enemigo;
        }
    
        public void activar()
        {
            GameObject go = Instantiate(GameObject.Find(enemigo));
            go.transform.position = posicion.position;
            go.transform.parent = gameObject.transform.parent;

            go.GetComponent<Collider2D>().enabled = true;        
            go.GetComponent<atribPrincipales>().enabled = true;
            go.GetComponent<detectarJugadorIA>().enabled = true;
            go.transform.GetChild(0).gameObject.SetActive(true);        
            go.transform.GetChild(1).gameObject.SetActive(true);
        }
	
    }
}
