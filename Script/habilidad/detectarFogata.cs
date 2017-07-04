using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class detectarFogata : habilidad
    {
        private string NOMBRE;
        private GameObject vent_santuario;
        private Collider2D hero;

        void Start ()
        {
            NOMBRE = "ui_ventana_santuario";
            tecla = KeyCode.E;
            icono_hab = null;

            vent_santuario = GameObject.Find(NOMBRE);
        }

        public override void efecto()
        {
            atribPrincipalesPlayer h = GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>();
            gamecontrol control = GameObject.Find("control").GetComponent<gamecontrol>();

            control.setNivel(h.queNivel());
            control.setExperiencia(h.getExperiencia());
            control.setPosicion(hero.transform.position);
            control.setFuerza(h.getFuerza());
            control.setFortaleza(h.getFortaleza());
            control.setAgilidad(h.getAgilidad());
            control.setFe(h.getFe());
            control.setInteligencia(h.getInteligencia());
            control.setSuerte(h.getSuerte());
            control.setPuntosNoGastados(h.getPuntosNoGastados());
            control.setEscena(SceneManager.GetActiveScene().buildIndex);

            activar();
        }

        public void activar()
        {
            GetComponent<ventana_santuario>().activar();
        }
	
	    void FixedUpdate ()
        {
            hero = Physics2D.OverlapCircle(gameObject.transform.position, 1f, LayerMask.GetMask("Player"));
            if (Input.GetKeyDown(tecla) && hero != null)
                efecto();
	    }
    }
}
