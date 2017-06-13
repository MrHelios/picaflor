using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class dispJugador : habilidad {

        protected Transform municion;
        protected float velocidad;

        void Awake()
        {
            nivel_necesario = 1;
        }

        void Start ()
        {        
            queTecla();
            setVelocidad(15);
            int max = GameObject.Find("Hero").transform.childCount;
            setMunicion(gameObject.transform.parent.transform.GetChild(max - 1).transform.GetChild(0));
    

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
            Vector3 mouse = Input.mousePosition;
            Vector3 direccion = Camera.main.ScreenToWorldPoint(mouse);
            direccion = new Vector2(direccion.x - municion.transform.position.x, direccion.y - municion.transform.position.y);
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

            Transform nuevo = Instantiate(municion);
            nuevo.gameObject.SetActive(true);
            nuevo.position = new Vector2(municion.position.x, municion.position.y);
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
            if (Time.time >= ultimoUso && Input.GetKeyDown(tecla))
            {
                efecto();
                efectoCooldown();
            }
	    }
    }
}
