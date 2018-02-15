using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum req_type { EnterArea };

class req_t
{
    // general mission variables
    public bool complete;
    public req_type type;

    // EnterArea mission
    public string area_name;

    public req_t(req_type t)
    {
        complete = false;
        type = t;
    }
}

public class basic_reward
{
    public basic_resource rss;
    public int num;
}

public class advanced_reward
{
    public advanced_resource rss;
    public int num;
}

public class mission_reward
{
    List<basic_reward> basic_resource_rewards;
    List<advanced_reward> advanced_resource_rewards;

    public mission_reward()
    {
        basic_resource_rewards = new List<basic_reward>();
        advanced_resource_rewards = new List<advanced_reward>();
    }

    public void add_basic_reward(basic_resource reward, int n)
    {
        basic_reward tmp;

        tmp = new basic_reward();
        tmp.rss = reward;
        tmp.num = n;
        basic_resource_rewards.Add(tmp);
    }

    public void add_advanced_reward(advanced_resource reward, int n)
    {
        advanced_reward tmp;

        tmp = new advanced_reward();
        tmp.rss = reward;
        tmp.num = n;
        advanced_resource_rewards.Add(tmp);
    }

    public string get_rewards()
    {
        string tmp = "rewards\n\n";

        foreach (basic_reward b in basic_resource_rewards)
        {
            tmp = tmp + b.rss.name + "\t" + b.num + "\n";
        }

        foreach (advanced_reward a in advanced_resource_rewards)
        {
            tmp = tmp + a.rss.name + "\t" + a.num + "\n";
        }

        return tmp;
    }

    public void give_rewards()
    {
        foreach (basic_reward b in basic_resource_rewards)
        {
            b.rss.num += b.num;
        }

        foreach (advanced_reward a in advanced_resource_rewards)
        {
            a.rss.num += a.num;
        }
    }
}

public class mission {

    public string title, content;
    public System.DateTime compTime;

    public mission_reward rewards;

    // TODO delete reqs
    private List<req_t> reqs;
    private int reqs_needed;        // number of unsatisfied reqs
    
    public mission(string Title, string Content, System.DateTime time)
    {
        title = Title;
        content = Content;
        compTime = time;
        rewards = new mission_reward();

        reqs = new List<req_t>();
        reqs_needed = 0;
    }



    public void GEM_Req_EnterArea(req_type t, string name)
    {
        req_t new_req = new req_t(t);
        
        GEM.event_EnterArea += new GEM.GameEvent(GEM_Evt_EnterArea);
        new_req.area_name = name;
        reqs.Add(new_req);
        reqs_needed++;
    }

    void GEM_Evt_EnterArea(GEA eventArgs)
    {
        Debug.Log("Got Event EnterArea " + eventArgs.area_name);

        foreach (req_t r in reqs)
        {
            if (eventArgs.area_name == r.area_name)
            {
                r.complete = true;
                reqs_needed--;
                if (reqs_needed == 0)
                {
                    mission_complete();
                }
            }
        }
    }

    void mission_complete()
    {
        Debug.Log("MISSION COMPLETE");
    }
}
