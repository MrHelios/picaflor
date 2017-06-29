using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class limpieza : mision {

        private GameObject campaña_GO;

        void Start()
        {
            iniciar();
        }

        public void iniciar()
        {
            posicion = 0;
            campaña = 0;

            nombre = "Limpieza";
            info_pre = "Al oeste hay una criatura vil. Eliminala!";
            info_post = "Bien hecho hermano. El aire hoy es mas puro.";

            agregado = false;
            terminado_no_entregado = false;
            completado = false;

            campaña_GO = GameObject.Find("SistemaMisiones");
        }

        public override void crearEventoMision()
        {
            GameObject eventos = GameObject.Find("eventos_misiones");

            GameObject enem = Instantiate(GameObject.Find("control/SistemaEnemigos/tempestad_oscura"));
            enem.transform.parent = eventos.transform;
            enem.transform.position = new Vector2(104, -104);

            enem.AddComponent<marca>();
            enem.GetComponent<marca>().escena = 2;
            enem.GetComponent<marca>().nombre_mision = nombre;
            enem.AddComponent<limpieza_fin>();
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
