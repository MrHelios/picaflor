using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class conservarHero : conservarGameObject {

        void Awake()
        {
            if (!creado)
            {            
                DontDestroyOnLoad(gameObject.transform);
                creado = true;
            }
                    
        }    

    }
}
