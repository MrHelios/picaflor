using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class creaEnemigos : MonoBehaviour {

        private bool estado;

        private void Start()
        {
            estado = false;
        }

        void FixedUpdate ()
        {
            Collider2D jug = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Player"));
            if (!estado && jug != null)
            {
                estado = true;
                int contar = 0;
                for (int i = 0; i < gameObject.transform.childCount; i++)
                    if (gameObject.transform.GetChild(i).gameObject.GetComponent<futuroEnemigo>() != null)
                    {
                        gameObject.transform.GetChild(i).gameObject.GetComponent<futuroEnemigo>().activar();
                        contar++;
                    }            
                    else if (gameObject.transform.GetChild(i).gameObject.tag == "Door")
                        gameObject.GetComponent<removerObstaculos>().setObstaculo(gameObject.transform.GetChild(i).gameObject);
            


                if (gameObject.GetComponent<removerObstaculos>() != null)
                    gameObject.GetComponent<removerObstaculos>().setCantidadRestantes(contar);
                Destroy(gameObject.GetComponent<creaEnemigos>());
            }
        }
    }
}
