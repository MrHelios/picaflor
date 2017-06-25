using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class diario : MonoBehaviour {

        private Stack<mision> historial;

        void Awake()
        {
            historial = new Stack<mision>();    
        }

        public void agregar(mision m)
        {
            historial.Push(m);
        }

        public bool estaMision(string n)
        {
            Stack<mision> d = new Stack<mision>();
            string[] temp = new string[historial.Count];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = historial.Peek().getNombre();
                d.Push(historial.Pop());
            }

            bool esta = false;
            for (int i = 0; i < temp.Length && !esta; i++)
                esta = temp[i].Equals(n);

            while (d.Count != 0)
                historial.Push(d.Pop());

            return esta;
        }

        public mision getMision(string n)
        {
            int i;
            Stack<mision> d = new Stack<mision>();
            mision[] temp = new mision[historial.Count];

            for (i = 0; i < temp.Length; i++)
            {
                temp[i] = historial.Peek();
                d.Push(historial.Pop());
            }

            bool esta = false;            
            for (i = 0; i < temp.Length && !esta; i++)
                esta = temp[i].Equals(n);

            while (d.Count != 0)
                historial.Push(d.Pop());

            return temp[i-1];
        }

    }
}
