using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testInicioUI : MonoBehaviour {
	
	void Start () {
        estaCanvas();
        cantidadCorrectaElementos();
        estaUIVida();
        estaUIExp();
        estaSimboloClase();
        estaPanelLibroHabilidades();
        estaPanelHabilidades();

        IntegrationTest.Pass();
	}

    private void estaCanvas()
    {
        if (GameObject.Find("Canvas") == null)
        {
            Debug.Log("No esta Canvas.");
            IntegrationTest.Fail();
        }

        if (GameObject.Find("EventSystem") == null)
        {
            Debug.Log("No esta EventSystem.");
            IntegrationTest.Fail();
        }
    }

    private void cantidadCorrectaElementos()
    {
        GameObject canvas = GameObject.Find("Canvas");
        int cant = canvas.transform.childCount;
        if (cant != 5)
        {
            Debug.Log("La cantidad de elementos no es la esperada.");
            IntegrationTest.Fail();
        }
    }

    private void estaUIVida()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(0).gameObject;

        bool activo = ui.activeSelf;
        string nombre = ui.name;

        if (!activo || ui.name != "ui_vida")
        {
            Debug.Log("Activo: " + activo);
            Debug.Log("Nombre: " + nombre);
            IntegrationTest.Fail();
        }
    }

    private void estaUIExp()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(1).gameObject;

        bool activo = ui.activeSelf;
        string nombre = ui.name;

        if (!activo || ui.name != "ui_exp")
        {
            Debug.Log("Activo: " + activo);
            Debug.Log("Nombre: " + nombre);
            IntegrationTest.Fail();
        }
    }

    private void estaSimboloClase()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(2).gameObject;

        bool activo = ui.activeSelf;
        string nombre = ui.name;

        if (!activo || ui.name != "ui_simbolo_clase")
        {
            Debug.Log("Activo: " + activo);
            Debug.Log("Nombre: " + nombre);
            IntegrationTest.Fail();
        }
    }

    private void estaPanelHabilidades()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(3).gameObject;

        bool activo = ui.activeSelf;
        string nombre = ui.name;

        if (!activo || ui.name != "ui_panel_habilidades")
        {
            Debug.Log("Activo: " + activo);
            Debug.Log("Nombre: " + nombre);
            IntegrationTest.Fail();
        }
    }

    private void estaPanelLibroHabilidades()
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(4).gameObject;

        bool activo = ui.activeSelf;
        string nombre = ui.name;

        if (activo || ui.name != "ui_libro_habilidades")
        {
            Debug.Log("Activo: " + activo);
            Debug.Log("Nombre: " + nombre);
            IntegrationTest.Fail();
        }
    }
	
}
