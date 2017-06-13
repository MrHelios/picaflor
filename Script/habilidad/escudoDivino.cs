using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class escudoDivino : MonoBehaviour {

        private absorcion ubicacion;

        public void setUbicacion(absorcion go)
        {
            ubicacion = go;
        }

        public void corte()
        {
            ubicacion.corte();
        }
    }
}
