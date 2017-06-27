using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

using test010;

public class testInventario
{

    [Test]
    public void test_item_oro()
    {
        GameObject o = new GameObject("oro");
        o.AddComponent<oro>();
        o.GetComponent<oro>().iniciar();

        Assert.AreEqual(0, o.GetComponent<oro>().getCantidad());        
        Assert.AreEqual("oro", o.GetComponent<oro>().getNombre());
        Assert.AreEqual(true, o.GetComponent<oro>().esAcumulable());
        Assert.AreEqual(false, o.GetComponent<oro>().esEquipable());        

        o.GetComponent<oro>().cambiarCantidad(100);

        Assert.AreEqual(100, o.GetComponent<oro>().getCantidad());
    }

    [Test]
    public void test_cant_inventario()
    {
        GameObject inv = new GameObject("inventario");
        inv.AddComponent<inventario>();
        inv.GetComponent<inventario>().iniciar();

        Assert.AreEqual(1, inv.GetComponents<MonoBehaviour>().Length);

        GameObject o = new GameObject("oro");
        o.AddComponent<oro>();
        o.GetComponent<oro>().iniciar();

        GameObject o2 = new GameObject("oro");
        o2.AddComponent<oro>();
        o2.GetComponent<oro>().iniciar();
        o2.GetComponent<oro>().setCantidad(200);

        inv.GetComponent<inventario>().agregar(o.GetComponent<oro>());
        Assert.AreEqual(1, inv.GetComponent<inventario>().cantidad());
        Assert.AreEqual(true, inv.GetComponent<inventario>().estaItem(o.GetComponent<oro>()));

        int cant = o2.GetComponent<oro>().getCantidad();
        inv.GetComponent<inventario>().agregar(o2.GetComponent<oro>()); ;

        Assert.AreEqual(0, o.GetComponent<oro>().getCantidad());
        Assert.AreEqual(200, o2.GetComponent<oro>().getCantidad());
        Assert.AreEqual(200, inv.GetComponent<oro>().getCantidad());
    }

    [Test]
    public void test_agregar_dos_acumulables()
    {
        GameObject inv = new GameObject("inventario");
        inv.AddComponent<inventario>();
        inv.GetComponent<inventario>().iniciar();

        GameObject o = new GameObject("oro");
        o.AddComponent<oro>();
        o.GetComponent<oro>().iniciar();
        inv.GetComponent<inventario>().agregar(o.GetComponent<oro>());

        GameObject o2 = new GameObject("oro");
        o2.AddComponent<oro>();
        o2.GetComponent<oro>().iniciar();
        o2.GetComponent<oro>().setCantidad(200);
        inv.GetComponent<inventario>().agregar(o2.GetComponent<oro>());

        Assert.AreEqual(1, inv.GetComponent<inventario>().cantidad());
        Assert.AreEqual(200, inv.GetComponent<inventario>().getItem(o.GetComponent<oro>()).getCantidad());
    }

    [Test]
    public void test_agregar_variado()
    {
        GameObject inv = new GameObject("inventario");
        inv.AddComponent<inventario>();
        inv.GetComponent<inventario>().iniciar();

        GameObject a = new GameObject("armadura_templario_0");
        a.AddComponent<armadura_templario_0>();
        a.GetComponent<armadura_templario_0>().iniciar();
        inv.GetComponent<inventario>().agregar(a.GetComponent<armadura_templario_0>());

        GameObject o = new GameObject("oro");
        o.AddComponent<oro>();
        o.GetComponent<oro>().iniciar();
        o.GetComponent<oro>().setCantidad(150);
        inv.GetComponent<inventario>().agregar(o.GetComponent<oro>());

        GameObject o2 = new GameObject("oro");
        o2.AddComponent<oro>();
        o2.GetComponent<oro>().iniciar();
        o2.GetComponent<oro>().setCantidad(200);
        inv.GetComponent<inventario>().agregar(o2.GetComponent<oro>());

        Assert.AreEqual(2, inv.GetComponent<inventario>().cantidad());        
    }

    [Test]
    public void test_que_drop()
    {
        GameObject inv = new GameObject("Hero");
        inv.AddComponent<inventario>();
        inv.GetComponent<inventario>().iniciar();

        GameObject i = new GameObject("Inventario");
        GameObject m = new GameObject("moneda");
        m.transform.parent = i.transform;
        m.AddComponent<oro>();
        m.GetComponent<oro>().iniciar();        

        GameObject go = new GameObject("oro");
        go.AddComponent<atribPrincipales>();
        go.GetComponent<atribPrincipales>().iniciar();
        go.GetComponent<atribPrincipales>().queDrop(inv);        

        Assert.AreEqual(1, inv.GetComponent<inventario>().cantidad());
        Assert.AreEqual(9, inv.GetComponent<inventario>().getItem(m.GetComponent<oro>()).getCantidad());

        GameObject go2 = new GameObject("oro");
        go2.AddComponent<atribPrincipales>();
        go2.GetComponent<atribPrincipales>().iniciar();
        go2.GetComponent<atribPrincipales>().queDrop(inv);

        Assert.AreEqual(1, inv.GetComponent<inventario>().cantidad());
        Assert.AreEqual(18, inv.GetComponent<inventario>().getItem(m.GetComponent<oro>()).getCantidad());
    }

}
