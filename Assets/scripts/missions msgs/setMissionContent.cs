using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class setMissionContent : MonoBehaviour {

    Text title;
    Text content;
    Text completionDate;
    Text completionTime;
    Text complete;
    Text missionRewards;


    void Start()
    {
        title = GameObject.Find("mission title").GetComponent<Text>() ;
        content = GameObject.Find("mission content").GetComponent<Text>();
        completionDate = GameObject.Find("mission comp date").GetComponent<Text>();
        completionTime = GameObject.Find("mission comp time").GetComponent<Text>();
        complete = GameObject.Find("complete").GetComponent<Text>();
        missionRewards = GameObject.Find("mission rewards").GetComponent<Text>();
    }

    public void setcontent(GameObject inMsg)
    {
        missionItemController controller;

        controller = inMsg.GetComponent<missionItemController>();
        title.text = controller.title.text;
        content.text = controller.content;
        completionDate.text = controller.compTime.ToString("yyyy-MM-dd");
        completionTime.text = controller.compTime.ToString("HH:mm:ss");
        complete.text = "complete :";
        missionRewards.text = controller.rewards;
    }
}
