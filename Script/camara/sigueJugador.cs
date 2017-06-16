using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class sigueJugador : MonoBehaviour {

        private Transform objetivo;

        private void Start() {
            GameObject hero = GameObject.Find("Hero");
            if (hero != null)
                objetivo = hero.GetComponent<Transform>();
            else
                objetivo = gameObject.transform;
        }

        void LateUpdate () {
            transform.position = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
	    }
    }
}
