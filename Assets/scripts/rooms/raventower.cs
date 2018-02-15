using UnityEngine;
using System.Collections;

public class raventower : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "raventower" });
	}
	
}
