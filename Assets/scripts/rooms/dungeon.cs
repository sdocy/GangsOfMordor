using UnityEngine;
using System.Collections;

public class dungeon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "dungeon" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
