using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class fogata : MonoBehaviour {

        public Vector3 darPosicion()
        {
            return gameObject.transform.GetChild(0).gameObject.transform.position;
        }

    }
}
