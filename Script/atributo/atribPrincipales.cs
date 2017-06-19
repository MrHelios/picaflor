using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class atribPrincipales : atrib
    {

        private int exp_muerte;

        private void Start()
        {
            vida = vida_max = 30;
            exp_muerte = 10;
        }

        public void setExpMuerte(int t)
        {
            exp_muerte = t;
        }

        public override void perderVida(float f)
        {
            vida -= f;
            gameObject.transform.GetChild(0).GetComponent<uiEnemyVida>().modificar(vida / vida_max);

            if (GetComponent<detectarJugadorIA>().enabled)
            {
                GetComponent<detectarJugadorIA>().setJugador(GameObject.Find("Hero").gameObject.GetComponent<Collider2D>());
                GetComponent<detectarJugadorIA>().activar();
                GetComponent<detectarJugadorIA>().buscarCompañeros();
            }

            if (vida <= 0)
            {
                GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>().sumarExp(exp_muerte);

                if (gameObject.transform.parent != null && gameObject.transform.parent.gameObject.GetComponent<removerObstaculos>() != null)
                    gameObject.transform.parent.gameObject.GetComponent<removerObstaculos>().unoMenos();

                GetComponent<destruirObjeto>().enabled = true;
                GetComponent<destruirObjeto>().ahora();
            }
        }

        public override void perderMana(float m)
        {
            
        }

        public override void perderAguante(float m)
        {
            
        }

    }
}

