using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class detectarFogata : habilidad {

        private Collider2D fogata;

        void Start () {
            tecla = KeyCode.E;
            icono_hab = null;
	    }

        public override void efecto()
        {
            atribPrincipalesPlayer h = gameObject.GetComponent<atribPrincipalesPlayer>();
            gamecontrol control = GameObject.Find("control").GetComponent<gamecontrol>();

            control.setNivel(h.queNivel());
            control.setExperiencia(h.getExperiencia());
            control.setPosicion(fogata.transform.position);

            Debug.Log("La informacion se guardo con exito!");
        }	
	
	    void FixedUpdate () {

            fogata = Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("Fogata"));
            if (Input.GetKeyDown(tecla) && fogata != null)
                efecto();

	    }
    }
}
