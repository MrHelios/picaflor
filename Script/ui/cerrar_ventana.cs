using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class cerrar_ventana : adminVentanas {

        void Start()
        {
            GameObject go = gameObject.transform.parent.gameObject;

            setVentana(go);
            cerrar_ventana();
        }

    }

}

