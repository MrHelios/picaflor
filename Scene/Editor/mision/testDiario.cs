using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

using test010;

public class testDiario
{

    [Test]
    public void test_diario_aceptar_completar_terminar()
    {
        GameObject c = new GameObject("control");
        GameObject d = new GameObject("diario");
        d.transform.parent = c.transform;
        d.AddComponent<diario>().iniciar();

        Assert.AreNotEqual(null, GameObject.Find("control/diario"));

        GameObject m_i = new GameObject("iniciado");
        m_i.AddComponent<iniciado>().iniciar();
        m_i.GetComponent<iniciado>().agregar();        

        Assert.AreEqual(1, d.GetComponent<diario>().cantidad());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaAgregado());
        Assert.AreEqual(false, m_i.GetComponent<iniciado>().estaTerminada());
        Assert.AreEqual(false, m_i.GetComponent<iniciado>().estaCompletado());

        string n = m_i.GetComponent<iniciado>().getNombre();
        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaAgregado());
        Assert.AreEqual(false, d.GetComponent<diario>().getMision(n).estaTerminada());
        Assert.AreEqual(false, d.GetComponent<diario>().getMision(n).estaCompletado());

        m_i.GetComponent<iniciado>().seTermino();

        Assert.AreEqual(1, d.GetComponent<diario>().cantidad());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaAgregado());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaTerminada());
        Assert.AreEqual(false, m_i.GetComponent<iniciado>().estaCompletado());

        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaAgregado());
        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaTerminada());
        Assert.AreEqual(false, d.GetComponent<diario>().getMision(n).estaCompletado());

        m_i.GetComponent<iniciado>().seCompleto();

        Assert.AreEqual(1, d.GetComponent<diario>().cantidad());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaAgregado());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaTerminada());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaCompletado());

        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaAgregado());
        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaTerminada());
        Assert.AreEqual(true, d.GetComponent<diario>().getMision(n).estaCompletado());

        DestroyObject.DestroyImmediate(c);
    }

    [Test]
    public void test_diario_varias_misiones()
    {
        GameObject c = new GameObject("control");
        GameObject d = new GameObject("diario");
        d.transform.parent = c.transform;
        d.AddComponent<diario>().iniciar();

        GameObject m_i = new GameObject("iniciado");
        m_i.AddComponent<iniciado>();
        m_i.GetComponent<iniciado>().iniciar();
        if(m_i.GetComponent<iniciado>().cumpleRequisito())
            m_i.GetComponent<iniciado>().agregar();

        GameObject m_l = new GameObject("limpieza");
        m_l.AddComponent<limpieza>();
        m_l.GetComponent<limpieza>().iniciar();
        if(m_l.GetComponent<limpieza>().cumpleRequisito())
            m_l.GetComponent<limpieza>().agregar();

        Assert.AreEqual(2, d.GetComponent<diario>().cantidad());

        string n = m_l.GetComponent<limpieza>().getNombre();
        Assert.AreEqual(true, d.GetComponent<diario>().estaMision(n));
        Assert.AreEqual(m_l.GetComponent<mision>(), d.GetComponent<diario>().getMision(n));

        // TERMINO m_i
        n = m_i.GetComponent<iniciado>().getNombre();
        d.GetComponent<diario>().getMision(n).seTermino();

        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaAgregado());
        Assert.AreEqual(true, m_i.GetComponent<iniciado>().estaTerminada());
        Assert.AreEqual(false, m_i.GetComponent<iniciado>().estaCompletado());

        Assert.AreEqual(true, m_l.GetComponent<limpieza>().estaAgregado());
        Assert.AreEqual(false, m_l.GetComponent<limpieza>().estaTerminada());
        Assert.AreEqual(false, m_l.GetComponent<limpieza>().estaCompletado());

        DestroyObject.DestroyImmediate(c);
    }

    [Test]
    public void test_misma_mision_dist_referencia()
    {
        GameObject c = new GameObject("control");
        GameObject d = new GameObject("diario");
        d.transform.parent = c.transform;
        d.AddComponent<diario>().iniciar();

        Assert.AreEqual(true, d.GetComponent<diario>().comparar("perro", "perro"));
        Assert.AreEqual(false, d.GetComponent<diario>().comparar("perro", "gato"));
        Assert.AreNotEqual(null, GameObject.Find("control/diario"));

        GameObject m_i = new GameObject("iniciado");
        m_i.AddComponent<iniciado>().iniciar();
        if(m_i.GetComponent<iniciado>().cumpleRequisito())
            m_i.GetComponent<iniciado>().agregar();

        GameObject m_ii = new GameObject("iniciado");
        m_ii.AddComponent<iniciado>().iniciar();
        /*
        if(m_ii.GetComponent<iniciado>().cumpleRequisito())
            m_ii.GetComponent<iniciado>().agregar();
        */

        Assert.AreEqual(true, GameObject.Find("control/diario").GetComponent<diario>().estaMision(m_ii.GetComponent<mision>().getNombre()));
        Assert.AreEqual(1, d.GetComponent<diario>().cantidad());
    }

}
