﻿using UnityEngine;
using System.Collections;

public class mines : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "mines" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
