using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{

    public class armadura_templario_0 : item
    {

        private void Awake()
        {
            iniciar();
        }

        public override void iniciar()
        {
            nombre = "armadura templario 0";
            equipable = true;
            acumulable = false;
            cantidad = 1;
        }

        public override void efecto()
        {
            
        }

    }

}
