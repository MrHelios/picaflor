using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class atribPrincipales : atrib
    {

        protected int exp_muerte;
        protected item drop;

        private void Start()
        {
            iniciar();
        }

        public void iniciar()
        {
            vida = vida_max = 30;
            exp_muerte = 10;
            drop = GameObject.Find("Inventario/moneda").GetComponent<item>();
            drop.setCantidad(9);
        }

        public void setDrop()
        {
            drop = GameObject.Find("Inventario/moneda").GetComponent<item>();
            drop.setCantidad(9);
        }

        public void setExpMuerte(int t)
        {
            exp_muerte = t;
        }

        public void sumarExp(GameObject go)
        {
            go.GetComponent<atribPrincipalesPlayer>().sumarExp(exp_muerte);
        }

        public void queDrop(GameObject go)
        {
            go.GetComponent<inventario>().agregar(drop);
        }

        public void muerte()
        {
            sumarExp(GameObject.Find("Hero"));
            queDrop(GameObject.Find("control/HeroInventario"));

            if (GetComponent<marca>() != null)
                GetComponent<marca>().misionTerminada();

            GetComponent<destruirObjeto>().enabled = true;
            GetComponent<destruirObjeto>().ahora();
        }

        public override void perderVida(float f)
        {
            vida -= f;
            gameObject.transform.GetChild(0).GetComponent<uiEnemyVida>().modificar(vida / vida_max);

            if (GetComponent<detectarJugadorIA>() != null && GetComponent<detectarJugadorIA>().enabled)
            {
                GetComponent<detectarJugadorIA>().setJugador(GameObject.Find("Hero").gameObject.GetComponent<Collider2D>());
                GetComponent<detectarJugadorIA>().activar();
                GetComponent<detectarJugadorIA>().buscarCompañeros();
            }

            if (vida <= 0)
                muerte();
        }        

        public override void perderMana(float m)
        {
            
        }

        public override void perderAguante(float m)
        {
            
        }

    }
}

