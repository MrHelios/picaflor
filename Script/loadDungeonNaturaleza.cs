using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class loadDungeonNaturaleza : loadDungeon
    {

        public string nombreGO;

        private void Awake()
        {
            load_d(nombreGO);
        }

        public string getNombre()
        {
            return nombreGO;
        }

    }
}
