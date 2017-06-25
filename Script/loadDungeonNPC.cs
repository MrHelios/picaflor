using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class loadDungeonNPC : loadDungeon {

        public string npc_GO;

	    void Start () {
            load_npc(npc_GO);
	    }	
	    
    }
}
