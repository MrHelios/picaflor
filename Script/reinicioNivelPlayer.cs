using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class reinicioNivelPlayer : MonoBehaviour {

        public void cosasNecesarioReiniciar()
        {
            Destroy(gameObject.GetComponent<uiPlayerVida>());
            Destroy(gameObject.GetComponent<uiPlayerExp>());
            Destroy(gameObject.GetComponent<sistemaAtajo>());

            gameObject.AddComponent<uiPlayerVida>();
            gameObject.AddComponent<uiPlayerExp>();
            gameObject.AddComponent<sistemaAtajo>();
        }

    }
}
