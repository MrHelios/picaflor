using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class conservarGameObject : MonoBehaviour {

        protected static bool creado = false;

        void Awake()
        {
            if (!creado)
            {
                DontDestroyOnLoad(gameObject.transform);
                creado = true;
            }
            else
                Destroy(this.gameObject);
        }

    }
}
