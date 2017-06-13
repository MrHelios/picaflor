using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class heroCreation : MonoBehaviour {

    void Awake()
    {            
        GameObject hero = Instantiate(GameObject.Find("HeroeParaClonar"));
        componentesPrincipales(hero);
    }

    private void componentesPrincipales(GameObject hero)
    {
        hero.name = "Hero";
        hero.tag = "Player";
        hero.layer = LayerMask.NameToLayer("Player");

        hero.GetComponent<atribPrincipalesPlayer>().enabled = false;
        hero.GetComponent<movJugador>().enabled = false;
        hero.GetComponent<miradaJugador>().enabled = false;        
        hero.GetComponent<uiPlayerVida>().enabled = false;        
        hero.GetComponent<sistemaAtajo>().enabled = false;        
        hero.GetComponent<detectarFogata>().enabled = false;        
        hero.GetComponent<equiparArma>().enabled = false;
    }

}
