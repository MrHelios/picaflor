using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class seguirObjetivoIA : MonoBehaviour {

        private GameObject obj;
        private Vector3 prioridad;

        private float velocidad;
        private float escala;

        private float distanciaMantener;

        void Awake()
        {
            setDistanciaMantener();
            obj = null;
            prioridad = Vector3.zero;
        }

        void setDistanciaMantener()
        {
            if (gameObject.name.Contains("babosa_roja"))
                distanciaMantener = 0f;
            else if (gameObject.name.Contains("tempestad_oscura01"))
                distanciaMantener = 3f;
            else if (gameObject.name.Contains("druida_salvaje01"))
                distanciaMantener = 5f;
            else
                distanciaMantener = 0f;
        }

        void Start()
        {
            GetComponent<atrib>().setVelocidad(3.5f);
            escala = 1;
        }

        public void establecerObjetivo(GameObject go)
        {
            obj = go;
        }

        public void establecerPrioridad(Vector3 v)
        {
            prioridad = v;
        }

        private void efecto(Vector3 direccion)
        {
            velocidad = GetComponent<atrib>().getVelocidad();

            if (direccion.x < 0)
                gameObject.transform.localScale = new Vector3(escala, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            else if (direccion.x > 0)
                gameObject.transform.localScale = new Vector3(-escala, gameObject.transform.localScale.y, gameObject.transform.localScale.z);

            float magnitud = Mathf.Sqrt(direccion.x * direccion.x + direccion.y * direccion.y);
            if (magnitud != 0)
                GetComponent<Rigidbody2D>().velocity = new Vector2(direccion.x / magnitud * velocidad, direccion.y / magnitud * velocidad);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(direccion.x, direccion.y);
        }

        private float distanciaEntrePuntos()
        {
            float x = (obj.transform.position.x - transform.position.x) * (obj.transform.position.x - transform.position.x);
            float y = (obj.transform.position.y - transform.position.y) * (obj.transform.position.y - transform.position.y);
            return Mathf.Sqrt(x+y);
        }
	
	    void FixedUpdate () {

            if (prioridad != Vector3.zero)
            {
                Vector3 direccion = new Vector2(prioridad.x - transform.position.x, prioridad.y - transform.position.y);
                efecto(direccion);
            }
            else if (obj != null && distanciaEntrePuntos() > distanciaMantener)
            {
                Vector3 direccion = new Vector2(obj.transform.position.x - transform.position.x,  obj.transform.position.y - transform.position.y);
                efecto(direccion);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        
	    }
    }
}
