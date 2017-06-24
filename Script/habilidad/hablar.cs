using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class hablar : habilidad {
        
        private Collider2D npc_amistoso;

        void Start()
        {
            tecla = KeyCode.E;
            icono_hab = null;            
        }

        public override void efecto()
        {
            npc_amistoso.GetComponent<conversarIA>().activar();            
        }

        void FixedUpdate()
        {
            npc_amistoso = Physics2D.OverlapCircle(gameObject.transform.position, 3f, LayerMask.GetMask("Friendly"));
            if (Input.GetKeyDown(tecla) && npc_amistoso != null)
                efecto();
        }

    }
}
