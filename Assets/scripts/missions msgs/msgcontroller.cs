using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class msgcontroller : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject msg;
    Text content;

    // Use this for initialization
    void Start () {
        if(globaldata.msgs.Count == 0)
        {
            content = GameObject.Find("raven message content").GetComponent<Text>();
            content.text = "No Messages";
        }

        foreach(messages m in globaldata.msgs)
        {
            GameObject newMsg = Instantiate(msg) as GameObject;
            msgItemController controller = newMsg.GetComponent<msgItemController>();
            controller.title.text = m.title;
            controller.content = m.content;
            newMsg.transform.SetParent(ContentPanel.transform, false);
            newMsg.transform.localScale = Vector3.one;
        }
	}
	
}
