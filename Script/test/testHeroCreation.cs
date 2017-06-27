using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testHeroCreation : MonoBehaviour {

    private GameObject hero;

    void Start() {
        hero = GameObject.Find("Hero");

        /*
        * HABILIDADES PRINCIPALES 
        */
        estaElHeroe(hero);
        tagDelHeroe(hero);
        mascaraDelHeroe(hero);
        tieneRigidBody(hero);
        tieneBoxCollider(hero);
        estaAtrib(hero);
        estaMovJugador(hero);
        estaMiradaJugador(hero);
        estaUIPlayerVida(hero);
        estaSistemaAtajo(hero);
        estaDetectarFogata(hero);
        estaEquiparArma(hero);        
        cantidadDeComponentes(hero);

        /*
        * HIJOS
        */
        cantHijosCorrecta(hero);
        atajosCorrectos(hero);
        comprobarImagenHero(hero);
        comprobarImagenPiernasHero(hero);
        comprobarImagenHeroSombra(hero);
        comprobarImagenHeroSangre(hero);
        comprobarArmaHero(hero);

        IntegrationTest.Pass();
    }

    /*
     * HABILIDADES PRINCIPALES 
     */
    private void estaElHeroe(GameObject hero)
    {
        if (hero == null)
        {
            Debug.Log("El heroe no esta o no esta con el nombre adecuado.");
            IntegrationTest.Fail();
        }
    }

    private void tagDelHeroe(GameObject hero)
    {
        if (hero.tag != "Player")
        {
            Debug.Log("El heroe no esta con el tag adecuado.");
            IntegrationTest.Fail();
        }
    }

    private void mascaraDelHeroe(GameObject hero)
    {
        if (hero.layer != LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Mascara: " + hero.layer);
            IntegrationTest.Fail();
        }
    }

    private void tieneRigidBody(GameObject hero)
    {
        if (hero.GetComponent<Rigidbody2D>() == null)
        {
            Debug.Log("No tiene rigidbody.");
            IntegrationTest.Fail();
        }
    }

    private void tieneBoxCollider(GameObject hero)
    {
        if (hero.GetComponent<BoxCollider2D>() == null)
        {
            Debug.Log("No tiene box collider.");
            IntegrationTest.Fail();
        }
    }
    
    private void estaAtrib(GameObject hero)
    {
        if (hero.GetComponent<atribPrincipalesPlayer>() == null)
        {
            Debug.Log("Falta el script que controla los atributos del heroe.");
            IntegrationTest.Fail();
        }
    }

    private void estaMovJugador(GameObject hero)
    {
        if (hero.GetComponent<movJugador>() == null)
        {
            Debug.Log("La habilidad para mover al personaje no esta implementada.");
            IntegrationTest.Fail();
        }
    }

    private void estaMiradaJugador(GameObject hero)
    {
        if (hero.GetComponent<miradaJugador>() == null)
        {
            Debug.Log("La habilidad para que el personaje siga al cursor no esta implementada.");
            IntegrationTest.Fail();
        }
    }

    private void estaUIPlayerVida(GameObject hero)
    {
        if (hero.GetComponent<uiPlayerVida>() == null)
        {
            Debug.Log("UI para la vida del jugador.");
            IntegrationTest.Fail();
        }
    }

    private void estaUIPlayerMana(GameObject hero)
    {
        if (hero.GetComponent<uiPlayerMana>() == null)
        {
            Debug.Log("UI para el mana del jugador.");
            IntegrationTest.Fail();
        }
    }

    private void estaUIPlayerAguante(GameObject hero)
    {
        if (hero.GetComponent<uiPlayerAguante>() == null)
        {
            Debug.Log("UI para el aguante del jugador.");
            IntegrationTest.Fail();
        }
    }

    private void estaSistemaAtajo(GameObject hero)
    {
        if (hero.GetComponent<sistemaAtajo>() == null)
        {
            Debug.Log("Script para armar los atajos que usara el personaje.");
            IntegrationTest.Fail();
        }
    }

    private void estaDetectarFogata(GameObject hero)
    {
        if (hero.GetComponent<detectarFogata>() == null)
        {
            Debug.Log("La habilidad para que el personaje utilice las fogatas.");
            IntegrationTest.Fail();
        }
    }

    private void estaEquiparArma(GameObject hero)
    {
        if (hero.GetComponent<equiparArma>() == null)
        {
            Debug.Log("La habilidad para equipar el arma.");
            IntegrationTest.Fail();
        }
    }

    private void estaLoadSceneMuerte(GameObject hero)
    {
        if (hero.GetComponent<loadSceneMuerte>() == null)
        {
            Debug.Log("El script necesario para la muerte no esta habilitado.");
            IntegrationTest.Fail();
        }
    }

    private void estaSprint()
    {
        if (hero.GetComponent<cambiaVelocidadPlayer>() == null)
        {
            Debug.Log("La habilidad para cambiar la velocidad player no esta implementada.");
            IntegrationTest.Fail();
        }
    }

    private void cantidadDeComponentes(GameObject hero)
    {
        int cant = hero.GetComponents<MonoBehaviour>().Length;
        int cantidad_comp = 14;
        if (cant != cantidad_comp)
        {
            Debug.Log("La cantidad de components principales es distinta a la requerida.");
            Debug.Log("Requiere: " + cantidad_comp + " y se encontraron: " + cant);
            IntegrationTest.Fail();
        }
    }

    /*
     * HIJOS
     */
    private void cantHijosCorrecta(GameObject hero)
    {
        int cant = 12;
        if (hero.transform.childCount != cant)
        {
            Debug.Log(hero);
            Debug.Log("La cantidad de hijos requerida para Player es incorrecta.");
            Debug.Log("Se esperaba: " + cant + " -> " + hero.transform.childCount);
            IntegrationTest.Fail();
        }
    }

    private void atajosCorrectos(GameObject hero)
    {
        bool correcto = true;
        for (int i = 0; i < 5 && correcto; i++)
        {
            bool hay_script = hero.transform.GetChild(i).GetComponents<MonoBehaviour>().Length == 0;
            bool hay_sprite = hero.transform.GetChild(i).GetComponent<SpriteRenderer>() == null;
            correcto = hay_script && hay_sprite;
        }

        if (!correcto)
        {
            Debug.Log("Los hijos no se comportan de la manera esperada.");
            IntegrationTest.Fail();
        }
    }

    private void comprobarImagenHero(GameObject hero)
    {
        GameObject imagen = hero.transform.GetChild(5).gameObject;
        bool hay_imagen, que_imagen=false;

        hay_imagen = imagen.GetComponent<SpriteRenderer>() != null;
        if(hay_imagen)
            que_imagen = imagen.GetComponent<SpriteRenderer>().sprite.name == "hero00_0";

        if (imagen.GetComponent<SpriteRenderer>().enabled)
        {
            IntegrationTest.Fail();
            Debug.Log(imagen.name);
            Debug.Log("La imagen esta habilitada en la pantalla de carga.");
        }

        if (!hay_imagen || !que_imagen)
        {
            IntegrationTest.Fail();
            Debug.Log("La imagen del heroe no es valida.");
            Debug.Log("Hay Imagen: " + hay_imagen);
            Debug.Log("Que Imagen: " + que_imagen);
        }

        string nombre_capa = "Player";
        if (imagen.GetComponent<SpriteRenderer>().sortingLayerName != nombre_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("La clasificacion de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + nombre_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingLayerName);
        }

        int orden_capa = 2;
        if (imagen.GetComponent<SpriteRenderer>().sortingOrder != orden_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("El orden de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + orden_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingOrder);
        }
    }

    /*
     * Utilizo el mismo logaritmo que para el metodo de comprobar Imagen Hero. 
     */
    private void comprobarImagenPiernasHero(GameObject hero)
    {
        for (int i = 6; i < 8; i++)
        {
            GameObject imagen = hero.transform.GetChild(i).gameObject;
            bool hay_imagen, que_imagen = false;

            hay_imagen = imagen.GetComponent<SpriteRenderer>() != null;
            if (hay_imagen)
                que_imagen = imagen.GetComponent<SpriteRenderer>().sprite.name == "hero00_3";

            if (imagen.GetComponent<SpriteRenderer>().enabled)
            {
                Debug.Log("La imagen esta habilitada en la pantalla de carga.");
                IntegrationTest.Fail();
            }

            if (!hay_imagen || !que_imagen)
            {
                Debug.Log("La imagen del heroe no es valida.");
                Debug.Log("Hay Imagen: " + hay_imagen);
                Debug.Log("Que Imagen: " + que_imagen);
                IntegrationTest.Fail();
            }

            string nombre_capa = "Player";
            if (imagen.GetComponent<SpriteRenderer>().sortingLayerName != nombre_capa)
            {
                IntegrationTest.Fail();
                Debug.Log("La clasificacion de la imagen no es correcta.");
                Debug.Log("Se esperaba: " + nombre_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingLayerName);
            }

            int orden_capa = 1;
            if (imagen.GetComponent<SpriteRenderer>().sortingOrder != orden_capa)
            {
                IntegrationTest.Fail();
                Debug.Log("El orden de la imagen no es correcta.");
                Debug.Log("Se esperaba: " + orden_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingOrder);
            }
        }
    }

    /*
     * Utilizo el mismo logaritmo que para el metodo de comprobar Imagen Hero. 
     */
    private void comprobarImagenHeroSombra(GameObject hero)
    {
        GameObject imagen = hero.transform.GetChild(8).gameObject;
        bool hay_imagen, que_imagen = false;

        hay_imagen = imagen.GetComponent<SpriteRenderer>() != null;
        if (hay_imagen)
            que_imagen = imagen.GetComponent<SpriteRenderer>().sprite.name == "hero00_1";

        if (imagen.GetComponent<SpriteRenderer>().enabled)
        {
            Debug.Log("La imagen esta habilitada en la pantalla de carga.");
            IntegrationTest.Fail();
        }

        if (!hay_imagen || !que_imagen)
        {
            Debug.Log("La imagen del heroe no es valida.");
            Debug.Log("Hay Imagen: " + hay_imagen);
            Debug.Log("Que Imagen: " + que_imagen);
            IntegrationTest.Fail();
        }

        string nombre_capa = "Player";
        if (imagen.GetComponent<SpriteRenderer>().sortingLayerName != nombre_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("La clasificacion de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + nombre_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingLayerName);
        }

        int orden_capa = -1;
        if (imagen.GetComponent<SpriteRenderer>().sortingOrder != orden_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("El orden de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + orden_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingOrder);
        }
    }

    /*
     * Utilizo el mismo logaritmo que para el metodo de comprobar Imagen Hero. 
     */
    private void comprobarImagenHeroSangre(GameObject hero)
    {
        GameObject imagen = hero.transform.GetChild(9).gameObject;
        bool hay_imagen, que_imagen = false;

        hay_imagen = imagen.GetComponent<SpriteRenderer>() != null;
        if (hay_imagen)
            que_imagen = imagen.GetComponent<SpriteRenderer>().sprite.name == "hero00_2";

        if (imagen.GetComponent<SpriteRenderer>().enabled)
        {
            Debug.Log("La imagen esta habilitada en la pantalla de carga.");
            IntegrationTest.Fail();
        }

        if (!hay_imagen || !que_imagen)
        {
            Debug.Log("La imagen del heroe no es valida.");
            Debug.Log("Hay Imagen: " + hay_imagen);
            Debug.Log("Que Imagen: " + que_imagen);
            IntegrationTest.Fail();
        }

        string nombre_capa = "Player";
        if (imagen.GetComponent<SpriteRenderer>().sortingLayerName != nombre_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("La clasificacion de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + nombre_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingLayerName);
        }

        int orden_capa = 0;
        if (imagen.GetComponent<SpriteRenderer>().sortingOrder != orden_capa)
        {
            IntegrationTest.Fail();
            Debug.Log("El orden de la imagen no es correcta.");
            Debug.Log("Se esperaba: " + orden_capa + " -> " + imagen.GetComponent<SpriteRenderer>().sortingOrder);
        }
    }

    private void comprobarArmaImagen(GameObject hero)
    {
        GameObject arma = hero.transform.GetChild(10).gameObject;

        int cant = 2;
        if (arma.transform.childCount != cant)
        {
            IntegrationTest.Fail();
            Debug.Log("La cantidad de objetos no es correcta.");
            Debug.Log("Se espera: " + cant + " -> " + arma.transform.childCount);
        }
        else
        {
            string nombre_0 = "activo";
            string nombre_1 = "envainado";
            if (arma.transform.GetChild(0).gameObject.name != nombre_0 && arma.transform.GetChild(1).gameObject.name != nombre_1)
            {
                IntegrationTest.Fail();
                Debug.Log("los nombres de los objetos no son correctos.");
                Debug.Log("Se espera: " + nombre_0 + " -> " + arma.transform.GetChild(0).gameObject.name);
                Debug.Log("Se espera: " + nombre_1 + " -> " + arma.transform.GetChild(1).gameObject.name);
            }
        }

    }

    private void comprobarArmaHero(GameObject hero)
    {
        GameObject arma = hero.transform.GetChild(11).gameObject;
        bool hay_arma;        

        hay_arma = arma.GetComponent<atribArma>() != null;
        if (!hay_arma)
        {
            Debug.Log("No hay arma.");
            IntegrationTest.Fail();
        }
    }

}
