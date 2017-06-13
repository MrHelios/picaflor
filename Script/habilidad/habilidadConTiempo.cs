using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public abstract class habilidadConTiempo : habilidad {

        protected float tiempoCorte;
        protected float duracion;

        public abstract void corte();

    }
}
