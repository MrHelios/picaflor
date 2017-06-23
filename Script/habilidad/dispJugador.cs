using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class dispJugador : habilidad {

        protected Transform municion;
        protected float velocidad;
        protected Transform hero;

        void Awake()
        {
            nivel_necesario = 1;
            mana = 5;
            aguante = 0;            
        }

        void Start ()
        {
            hero = GameObject.Find("Hero").transform;
            queTecla();
            setVelocidad(15);

            GameObject mun = GameObject.Find("SistemaMunicion");
            int pos = 0;
            setMunicion(mun.transform.GetChild(pos));    

            cooldown = 0.5f;
            ultimoUso = Time.time - cooldown;
	    }

        public void setMunicion(Transform m)
        {
            municion = m;
        }

        public void setVelocidad(float v)
        {
            velocidad = v;
        }   

        public override void efecto()
        {
            hero.GetComponent<atrib>().perderMana(mana);

            Vector3 mouse = Input.mousePosition;
            Vector3 direccion = Camera.main.ScreenToWorldPoint(mouse);
            direccion = new Vector2(direccion.x - hero.position.x, direccion.y - hero.position.y);
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            Transform nuevo = Instantiate(municion);
            nuevo.gameObject.SetActive(true);
            nuevo.position = new Vector2(hero.position.x, hero.position.y);
            nuevo.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
            nuevo.gameObject.GetComponent<SpriteRenderer>().enabled = true;
            nuevo.gameObject.GetComponent<destruirObjeto>().enabled = true;
            nuevo.gameObject.GetComponent<impactoMunicion>().enabled = true;

            float magnitud = Mathf.Sqrt(direccion.x * direccion.x + direccion.y * direccion.y);
            if (magnitud != 0)
                nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(direccion.x / magnitud * velocidad, direccion.y / magnitud * velocidad);
            else
                nuevo.GetComponent<Rigidbody2D>().velocity = new Vector2(direccion.x, direccion.y);
        }

        void FixedUpdate ()
        {
            if (Time.time >= ultimoUso && Input.GetKeyDown(tecla) && hero.GetComponent<atrib>().tieneMana(mana))
            {
                efecto();
                efectoCooldown();
            }
	    }
    }
}