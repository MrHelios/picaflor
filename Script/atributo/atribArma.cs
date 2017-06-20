using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class atribArma : MonoBehaviour {

        public int damage;
	
	    void Start () {
            damage = 10;
	    }

        public void setDamage(int d)
        {
            damage = d;
        }

        public int getDamage()
        {
            return damage;
        }
	
    }
}
