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
            Transform t = gameObject.transform.parent.gameObject.transform.GetChild(gameObject.transform.parent.gameObject.transform.childCount - 1);
            Collider2D col = Physics2D.OverlapArea(t.position, t.GetChild(0).gameObject.transform.position, LayerMask.GetMask("Enemy"));        
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
