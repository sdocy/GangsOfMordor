using UnityEngine;
using System.Collections;

public class missioncontroller : MonoBehaviour {

    public GameObject ContentPanel;
    public GameObject msg;

    // Use this for initialization
    void Start () {
        foreach(mission m in globaldata.missions)
        {
            GameObject newMsg = Instantiate(msg) as GameObject;
            missionItemController controller = newMsg.GetComponent<missionItemController>();
            controller.title.text = m.title;
            controller.content = m.content;
            controller.rewards = m.rewards.get_rewards();
            controller.compTime = m.compTime;
            newMsg.transform.SetParent(ContentPanel.transform, false);
            newMsg.transform.localScale = Vector3.one;
        }
	}
	
}
