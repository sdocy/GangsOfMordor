using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setMsgContent : MonoBehaviour {

    Text title;
    Text content;

    void Start()
    {
        title = GameObject.Find("raven message title").GetComponent<Text>() ;
        content = GameObject.Find("raven message content").GetComponent<Text>();
    }

    public void setcontent(GameObject inMsg)
    {
        msgItemController controller;

        controller = inMsg.GetComponent<msgItemController>();
        title.text = controller.title.text;
        content.text = controller.content;
    }
}
