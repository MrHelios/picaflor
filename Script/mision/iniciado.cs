using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class iniciado : mision
    {

        private GameObject campaña_GO;

        void Start()
        {
            iniciar();
        }

        public void iniciar()
        {
            posicion = 0;
            campaña = 0;

            nombre = "El iniciado";
            info_pre = "Ve al templo del Sol y contempla su belleza.";
            info_post = "Bien hecho hermano. El astro rey iluminara siempre tu alma.";

            agregado = false;
            terminado_no_entregado = false;
            completado = false;

            campaña_GO = GameObject.Find("SistemaMisiones");
        }

        public override void crearEventoMision()
        {
            GameObject eventos = GameObject.Find("eventos_misiones");

            GameObject evento_iniciado = new GameObject("evento_iniciado");
            evento_iniciado.transform.parent = eventos.transform;
            evento_iniciado.transform.position = new Vector2(141,-55);
            evento_iniciado.AddComponent<detectarJugPos>();

            evento_iniciado.GetComponent<detectarJugPos>().nombre_mision = nombre;
            evento_iniciado.GetComponent<detectarJugPos>().heroe = LayerMask.GetMask("Player");
            evento_iniciado.GetComponent<detectarJugPos>().escena = 2;
            evento_iniciado.GetComponent<detectarJugPos>().enabled = false;

            evento_iniciado.AddComponent<iniciado_fin>();
        }

        public override void agregarAlDiario()
        {
            if (!agregado)
            {
                agregar();
                animacionTextoMision("Iniciaste: ");                
            }
        }

        public void agregar()
        {
            GameObject.Find("control/diario").GetComponent<diario>().agregar(this);
            agregado = true;
        }        

        public override bool puedeTerminar()
        {
            if (agregado && terminado_no_entregado && !completado)
            {
                completado = true;                
                return true;
            }
            else
                return false;
        }

    }
}
