using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class rajar : habilidad {

        private float damage;

        void Awake()
        {
            nivel_necesario = 1;        
        }

        void Start()
        {
            damage = 20;
            queTecla();

            cooldown = 0.5f;
            ultimoUso = Time.time - cooldown;
        }

        public override void efecto()
        {
            GameObject.Find("Hero").gameObject.GetComponent<Animator>().SetTrigger("atajo");

            Transform arma = gameObject.transform.parent.gameObject.transform.GetChild(gameObject.transform.parent.gameObject.transform.childCount - 1);
            Transform arma_punto_1 = arma.GetChild(0).transform;
            Transform arma_punto_2 = arma.GetChild(1).transform;

            Collider2D col = Physics2D.OverlapArea(arma_punto_1.position, arma_punto_2.position, LayerMask.GetMask("Enemy"));
            if(col != null)
                if (col.gameObject.GetComponent<atribPrincipales>() != null)
                    col.gameObject.GetComponent<atribPrincipales>().perderVida(damage);
        }

        void FixedUpdate()
        {
            if (Time.time >= ultimoUso && Input.GetKeyDown(tecla))
            {                
                efecto();
                efectoCooldown();
            }
        }

    }
}
