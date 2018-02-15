using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class initialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        mission tmp;

        print("Initializing....");

        // command table missions
        globaldata.missions = new List<mission>();
        tmp = new mission("my mission", "This is my mission.  There are many like it, but this one is mine.\n\n" +
            "The command table is where you view, accept and track missions.  ", gameclock.timeofday);
        tmp.GEM_Req_EnterArea(req_type.EnterArea, "raventower");
        globaldata.missions.Add(tmp);
        
        // raven messages
        globaldata.msgs = new List<messages>()
        {

        };

        // resources
        globaldata.kbrss = new kitchen_basic_resources();
        globaldata.karss = new kitchen_adv_resources();
        globaldata.gbrss = new general_basic_resources();

        SceneManager.LoadScene("keep");
    }

}
