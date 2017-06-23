using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class cambiaVelocidadPlayer : habilidadConTiempo {

        protected GameObject hero;
        protected GameObject objetivo;
        protected float velocidad;
        protected float velocidadNueva;    
        protected bool activo;

        void Awake()
        {
            nivel_necesario = 1;

            mana = 0;
            aguante = 5;
        }

        void Start ()
        {
            hero = GameObject.Find("Hero");
            tecla = KeyCode.LeftShift;
            activo = false;    

            cooldown = 2f;
            ultimoUso = Time.time - cooldown;
        }

        public override void efecto()
        {
            objetivo = GameObject.Find("Hero");

            hero.GetComponent<atrib>().perderAguante(aguante);
            velocidad = objetivo.GetComponent<atribPrincipalesPlayer>().getVelocidad();
            velocidadNueva = velocidad * 1.5f;

            duracion = 2f;
            tiempoCorte = Time.time + duracion;
            activo = true;

            objetivo.GetComponent<atribPrincipalesPlayer>().setVelocidad(velocidadNueva);
        }

        public override void corte()
        {
            objetivo.GetComponent<atribPrincipalesPlayer>().setVelocidad(velocidad);
            activo = false;
        }

        void FixedUpdate ()
        {
            if (activo && Time.time >= tiempoCorte)
                corte();
            else if (Time.time >= ultimoUso && !activo && Input.GetKeyDown(tecla) && hero.GetComponent<atrib>().tieneAguante(aguante))
            {            
                efecto();
                efectoCooldown();
            }
	    }

    }
}
