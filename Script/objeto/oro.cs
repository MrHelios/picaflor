using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class oro : item
    {        

        void Awake()
        {
            iniciar();
        }

        public override void iniciar()
        {
            nombre = "oro";
            equipable = false;
            acumulable = true;
            cantidad = 0;
        }

        public override void efecto()
        {
            
        }       

    }
}
