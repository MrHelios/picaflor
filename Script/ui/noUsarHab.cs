using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace test010
{
    public class noUsarHab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Entra");

            GameObject hab = GameObject.Find("Hero").transform.GetChild(0).gameObject;
            if(hab.GetComponent<habilidad>() != null)
                hab.GetComponent<habilidad>().enabled = false;
        }        
        
        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Sale");

            GameObject hab = GameObject.Find("Hero").transform.GetChild(0).gameObject;
            if (hab.GetComponent<habilidad>() != null)
                hab.GetComponent<habilidad>().enabled = true;
        }

    }
}
