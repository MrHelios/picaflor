using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class uiEnemyVida : MonoBehaviour {

        public void modificar(float v) {
            gameObject.transform.localScale = new Vector3(v,1,1);
        }

    }
}
