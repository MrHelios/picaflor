using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class diario : MonoBehaviour
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

        public bool estaMision(string n)
        {
            LinkedListNode<mision> m = historial.First;
            bool esta = m.Value.getNombre() == n;

            while (m.Next != null && !esta)
            {
                m = m.Next;
                esta = m.Value.getNombre() == n;
            }

            return esta;
        }

        public mision getMision(string n)
        {
            LinkedListNode<mision> m = historial.First;
            bool esta = m.Value.getNombre() == n;

            while (m.Next != null && !esta)
            {
                m = m.Next;
                esta = m.Value.getNombre() == n;
            }

            if (esta)
                return m.Value;
            else
                return null;
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

    }
}
