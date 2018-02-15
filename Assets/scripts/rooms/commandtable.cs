using UnityEngine;
using System.Collections;

public class commandtable : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "commandtable" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
