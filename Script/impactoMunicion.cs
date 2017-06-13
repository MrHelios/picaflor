using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class impactoMunicion : MonoBehaviour {

        private float radio;
        public LayerMask enemigo;
        private Transform municion;
        private float damage;

	    void Start ()
        {
            radio = 0.1f;
            municion = GetComponent<Transform>();
            damage = 0f;
	    }	
	
	    void FixedUpdate ()
        {
            Collider2D col = Physics2D.OverlapCircle(municion.position, radio, enemigo);
            if (col != null) {
                // La municion explota y por lo tanto no sigue en juego.
                GetComponent<destruirObjeto>().setTiempoDeVida(0);
                // Verificamos si el objeto donde impacta es un enemigo.
                if (col.gameObject.GetComponent<atribPrincipales>() != null && col.tag == "Enemy")
                {
                    // Posicion de la arma.
                    int ultimo_hijo = GameObject.Find("Hero").gameObject.transform.childCount;
                    damage = GameObject.Find("Hero").gameObject.transform.GetChild(ultimo_hijo - 1).gameObject.GetComponent<atribArma>().getDamage();
                    if(gameObject.name == "bolahielo" && col.gameObject.GetComponent<congelar>() != null)
                        col.gameObject.GetComponent<atribPrincipales>().perderVida(damage * 2);
                    else
                        col.gameObject.GetComponent<atribPrincipales>().perderVida(damage);
                }
                else if (col.gameObject.GetComponent<atribPrincipalesPlayer>() != null)
                    col.gameObject.GetComponent<atribPrincipalesPlayer>().perderVida(10);

                if (gameObject.name == "congelar")            
                    col.gameObject.AddComponent<congelar>();
            
            }
	    }

    }
}
