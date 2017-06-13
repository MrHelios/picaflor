using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class detectarJugadorIA : MonoBehaviour {

        private float radio;
        private Collider2D jug;

        void Start () {
            jug = null;
            radio = 5f;
	    }

        public void setJugador(Collider2D j)
        {
            jug = j;
        }

        public void activar()
        {        
            MonoBehaviour[] habilidades = GetComponents<MonoBehaviour>();
            for (int i = 0; i < habilidades.Length; i++)
                habilidades[i].enabled = true;

            GetComponent<seguirObjetivoIA>().establecerObjetivo(jug.gameObject);
            GetComponent<destruirObjeto>().enabled = false;
        }

        public void buscarCompañeros()
        {
            Collider2D[] enemigos = Physics2D.OverlapCircleAll(transform.position, radio, LayerMask.GetMask("Enemy"));

            for (int i = 0; i < enemigos.Length; i++)
            {
                enemigos[i].GetComponent<detectarJugadorIA>().setJugador(jug);
                enemigos[i].GetComponent<detectarJugadorIA>().activar();
                enemigos[i].GetComponent<detectarJugadorIA>().enabled = false;
            }
        }
	
	    void FixedUpdate ()
        {
            jug = Physics2D.OverlapCircle(transform.position, radio, LayerMask.GetMask("Player"));
            if (jug != null)
            {
                activar();
                buscarCompañeros();
            }
	    }
    }
}
