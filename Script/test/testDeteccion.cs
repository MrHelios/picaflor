using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using test010;

public class testDeteccion : MonoBehaviour {

    public LayerMask mascara;
    public int radio;
    private Transform trans;

    public GameObject objetivo;

	void Start () {
        trans = transform;

        objetivo.GetComponent<seguirObjetivoIA>().establecerObjetivo(gameObject);
	}
	
	void FixedUpdate () {

        if (Physics2D.OverlapCircle(trans.position, radio, mascara) != null)
            IntegrationTest.Pass();
		
	}
}
