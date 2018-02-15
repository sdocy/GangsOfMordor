using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameclock : MonoBehaviour
{

    int gameYear = 2022;
    int gameMonth = 9;
    int gameDay = 1;
    int gameHour = 11;

    public Text date;
    public Text time;
    public static System.DateTime timeofday;
    public int fastforward = 1;

    float default_clock_tick = 5.0f;

    void checkMissions()
    {
        mission rm = null;

        // cannot remove list item while iterating through the list
        // so we will just stick to resolving only one per tick
        foreach (mission m in globaldata.missions)
        {
            if (m.compTime <= timeofday)
            {
                rm = m;
                break;
            }
        }

        if (rm != null)
        {
            rm.rewards.give_rewards();

            globaldata.missions.Remove(rm);
        }
    }

    void updateClock()
    {
        if (fastforward == 0)
            return;

        timeofday = timeofday.AddMinutes(fastforward * 30);

        date.text = timeofday.ToString("yyyy-MM-dd");
        time.text = timeofday.ToString("HH:mm:ss");

        checkMissions();
    }

    public void updateFF(int ff)
    {
        fastforward = ff;
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        timeofday = new System.DateTime(gameYear, gameMonth, gameDay, gameHour, 0, 0);

        InvokeRepeating("updateClock", 2.0f, default_clock_tick);
    }
}

