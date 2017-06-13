using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class sigueJugador : MonoBehaviour {

        private Transform hero;

        private void Start() {
            hero = GameObject.Find("Hero").GetComponent<Transform>();
        }

        void LateUpdate () {
            transform.position = new Vector3(hero.position.x, hero.position.y, transform.position.z);
	    }
    }
}
