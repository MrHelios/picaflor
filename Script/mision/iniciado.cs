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

        public override void agregarAlDiario()
        {
            if (!agregado)
            {
                GameObject.Find("Hero").GetComponent<diario>().agregar(this);
                agregado = true;
            }
        }

        public override bool cumpleRequisito()
        {
            if (posicion == 0)
                return true;
            else
            {
                mision mision_ant = campaña_GO.transform.GetChild(campaña).transform.GetChild(posicion - 1).gameObject.GetComponent<mision>();
                if (mision_ant.estaCompletado())
                    return true;
                else
                    return false;
            }
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
