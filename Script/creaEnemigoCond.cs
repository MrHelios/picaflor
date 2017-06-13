using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class creaEnemigoCond : MonoBehaviour {

        private bool estado;
        private int hijos;

	    void Start ()
        {
            estado = false;
            hijos = gameObject.transform.childCount;
        }

        private void activar()
        {
            for (int i = 0; i < hijos; i++)
                if (gameObject.transform.GetChild(i).gameObject.GetComponent<futuroEnemigo>() != null)
                    gameObject.transform.GetChild(i).gameObject.GetComponent<futuroEnemigo>().activar();
                else if (gameObject.transform.GetChild(i).gameObject.tag == "Door")
                    gameObject.GetComponent<removerObstaculos>().setObstaculo(gameObject.transform.GetChild(i).gameObject);

            estado = true;
        }

        void FixedUpdate()
        {
            if (!estado)
                activar();
            else
                Destroy(gameObject.GetComponent<creaEnemigoCond>());
        }

    }
}
