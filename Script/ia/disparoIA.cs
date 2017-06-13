using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class disparoIA : MonoBehaviour {

        private Transform municion;
        private float velocidad;
        private float tiempo;

	    void Start ()
        {
            velocidad = 10f;
            municion = gameObject.transform.GetChild(2).gameObject.transform;
            tiempo = Time.time - 1;
	    }

        private Transform objetivo()
        {
            return GameObject.Find("Hero").gameObject.transform;
        }
	
	    void FixedUpdate ()
        {
            if (tiempo < Time.time)
            {
                Vector3 direccion = objetivo().position;
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

                tiempo = Time.time + 1f;
            }

        }

    }
}
