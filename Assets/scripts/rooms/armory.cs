﻿using UnityEngine;
using System.Collections;

public class armory : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "armory" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}