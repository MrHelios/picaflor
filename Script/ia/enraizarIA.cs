using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class enraizarIA : MonoBehaviour {

        private GameObject heroe;
        private float cooldown;
        private float ult_usado;

	    void Start () {
            heroe = GameObject.Find("Hero").gameObject;
            cooldown = 10f;
            ult_usado = Time.time + cooldown * 0.5f;

        }

        private Transform objeticoPosicion()
        {
            return heroe.gameObject.transform;
        }

        private void aplicarCooldown()
        {
            ult_usado = Time.time + cooldown;
        }

        private void efecto()
        {
            heroe.AddComponent<enraizar>();
            aplicarCooldown();
        }
	
	    void FixedUpdate () {

            if (Time.time > ult_usado)
                efecto();

	    }
    }
}
