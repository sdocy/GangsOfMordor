using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class keepA : MonoBehaviour {

    public Text navTitleText;
    public lvlmgr lm;
    Color initialColor;

    void OnMouseEnter()
    {
        MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();
        initialColor = rend.material.color;

        navTitleText.text = "Armory";
        rend.material.color = Color.red;
    }

    void OnMouseExit()
    {
        MeshRenderer rend = gameObject.GetComponent<MeshRenderer>();

        navTitleText.text = "";
        rend.material.color = initialColor;
    }

    void OnMouseDown()
    {
        lm.loadlevel("armory");
    }
}
