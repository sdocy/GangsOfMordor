using UnityEngine;
using System.Collections;

public class barracks : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "barracks" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
