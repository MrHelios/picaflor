﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class diario: MonoBehaviour
    {
        
        private LinkedList<mision> historial;

        void Awake()
        {
            iniciar();
        }

        public void iniciar()
        {            
            historial = new LinkedList<mision>();            
        }

        public int cantidad()
        {
            return historial.Count;
        }

        public void agregar(mision m)
        {
            historial.AddFirst(m);
        }

        public bool comparar(string n, string n2)
        {
            bool igual = n.Length == n2.Length;
            for (int i = 0; i < n.Length && igual; i++)
                igual = n[i] == n2[i];
            return igual;
        }

        public bool estaMision(string n)
        {
            if (historial.Count != 0)
            {
                LinkedListNode<mision> m = historial.First;
                bool esta = comparar(m.Value.getNombre(), n);

                while (m.Next != null && !esta)
                {
                    m = m.Next;
                    esta = comparar(m.Value.getNombre(), n);
                }

                return esta;
            }
            return false;
        }

        public mision getMision(string n)
        {
            if (historial.Count != 0)
            {
                LinkedListNode<mision> m = historial.First;
                bool esta = comparar(m.Value.getNombre(), n);

                while (m.Next != null && !esta)
                {
                    m = m.Next;
                    esta = comparar(m.Value.getNombre(), n);                        
                }

                if (esta)
                    return m.Value;
                else
                    return null;
            }
            return null;
        }

        public void setH(LinkedList<mision> h)
        {
            historial = h;
        }

        public LinkedList<mision> getH()
        {
            return historial;
        }

        public mision[] getHistorial()
        {
            mision[] m = new mision[historial.Count];

            LinkedListNode<mision> recorre = historial.First;
            for (int i = 0; i < m.Length; i++)
            {
                m[i] = recorre.Value;
                recorre = recorre.Next;
            }

            return m;
        }

        public void recargarEventos()
        {
            if (historial.Count != 0)
            {
                LinkedListNode<mision> m = historial.First;
                while (m != null)
                {
                    if (!m.Value.completado)
                        m.Value.crearEventoMision();
                    m = m.Next;
                }
            }
        }

    }
}
