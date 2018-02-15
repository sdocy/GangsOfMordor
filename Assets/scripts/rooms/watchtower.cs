using UnityEngine;
using System.Collections;

public class watchtower : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "watchtower" });
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
