using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class esquivarObstaculosIA : MonoBehaviour {

        public LayerMask mascara;
        private Transform posicion_y, posicion_x, posicion_x2, posicion_y2, posicion_n_y, posicion_n_y2;
        private float radio;

        private bool activo;
        private float tiempo;

        private void Start()
        {
            radio = 0.3f;
            
            posicion_n_y2 = gameObject.transform.GetChild(gameObject.transform.childCount - 6);
            posicion_n_y = gameObject.transform.GetChild(gameObject.transform.childCount - 5);

            posicion_y2 = gameObject.transform.GetChild(gameObject.transform.childCount - 4);
            posicion_y = gameObject.transform.GetChild(gameObject.transform.childCount - 1);

            posicion_x2 = gameObject.transform.GetChild(gameObject.transform.childCount - 3);
            posicion_x = gameObject.transform.GetChild(gameObject.transform.childCount - 2);            

            activo = false;
            tiempo = Time.time;
        }

        private void ordenarPrioridadenY(Collider2D col)
        {
            GameObject hero = GameObject.Find("Hero");

            if (col.gameObject.transform.position.y >= hero.gameObject.transform.position.y)
            {
                gameObject.GetComponent<seguirObjetivoIA>().establecerPrioridad(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1, 1));
            }
            else if (col.gameObject.transform.position.y < hero.gameObject.transform.position.y)
            {
                gameObject.GetComponent<seguirObjetivoIA>().establecerPrioridad(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1, 1));
            }
        }

        private void ordenarPrioridadenX(Collider2D col)
        {
            GameObject hero = GameObject.Find("Hero");

            if (col.gameObject.transform.position.x >= hero.gameObject.transform.position.x)
            {
                gameObject.GetComponent<seguirObjetivoIA>().establecerPrioridad(new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, 1));
            }
            else if (col.gameObject.transform.position.x < hero.gameObject.transform.position.x)
            {
                gameObject.GetComponent<seguirObjetivoIA>().establecerPrioridad(new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, 1));
            }
        }

        void FixedUpdate()
        {
            Collider2D col = Physics2D.OverlapArea(posicion_y.position, posicion_y2.position, mascara);
            Collider2D colx = Physics2D.OverlapArea(posicion_x.position, posicion_x2.position, mascara);
            Collider2D coly = Physics2D.OverlapArea(posicion_n_y.position, posicion_n_y2.position, mascara);

            if (col != null)
            {
                Debug.Log("activado 1");
                activo = true;
                tiempo = Time.time;

                ordenarPrioridadenY(col);
            }
            else if (colx != null)
            {
                Debug.Log("activado 2");
                activo = true;
                tiempo = Time.time;

                ordenarPrioridadenX(colx);
            }
            else if (coly != null)
            {
                Debug.Log("activado 3");
                activo = true;
                tiempo = Time.time;

                ordenarPrioridadenX(coly);
            }
            else if (activo && Time.time > tiempo + 0.2f)
            {
                Debug.Log("activado 4");
                activo = false;
                gameObject.GetComponent<seguirObjetivoIA>().establecerPrioridad(Vector3.zero);
            }
        
        }


    }
}
