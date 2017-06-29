using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class detectarFogata : habilidad
    {
        private GameObject vent_santuario;
        private Collider2D fogata;

        void Start ()
        {
            tecla = KeyCode.E;
            icono_hab = null;

            vent_santuario = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
        }

        public override void efecto()
        {
            atribPrincipalesPlayer h = gameObject.GetComponent<atribPrincipalesPlayer>();
            gamecontrol control = GameObject.Find("control").GetComponent<gamecontrol>();

            control.setNivel(h.queNivel());
            control.setExperiencia(h.getExperiencia());
            control.setPosicion(fogata.transform.position);
            control.setFuerza(h.getFuerza());
            control.setFortaleza(h.getFortaleza());
            control.setAgilidad(h.getAgilidad());
            control.setFe(h.getFe());
            control.setInteligencia(h.getInteligencia());
            control.setSuerte(h.getSuerte());
            control.setPuntosNoGastados(h.getPuntosNoGastados());
            control.setEscena(SceneManager.GetActiveScene().buildIndex);
            
            vent_santuario.SetActive(true);
        }	
	
	    void FixedUpdate ()
        {
            fogata = Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("Fogata"));
            if (Input.GetKeyDown(tecla) && fogata != null)
                efecto();
	    }
    }
}
