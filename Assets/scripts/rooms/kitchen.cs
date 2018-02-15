using UnityEngine;
using UnityEngine.UI;

using System.Collections;



public class kitchen : MonoBehaviour {
    public Text game_button_text;
    public Text game_name_text;
    public Text game_num_text;

    public Text grain_button_text;
    public Text grain_name_text;
    public Text grain_num_text;

    public Text water_button_text;
    public Text water_name_text;
    public Text water_num_text;

    public Text meat_button_text;
    public Text meat_name_text;
    public Text meat_num_text;
    public Text meat_ingreds_text;

    public Text bread_button_text;
    public Text bread_name_text;
    public Text bread_num_text;
    public Text bread_ingreds_text;

    public Text grog_button_text;
    public Text grog_name_text;
    public Text grog_num_text;
    public Text grog_ingreds_text;

    public Text wood_button_text;
    public Text wood_name_text;
    public Text wood_num_text;

    public Text error_text;

    int gather_duration = 2;

    // Use this for initialization
    void Start () {
        GEM.trigger_EnterArea(new GEA { area_name = "kitchen" });

        game_name_text.text = globaldata.kbrss.game.name;

        grain_name_text.text = globaldata.kbrss.grain.name;

        water_name_text.text = globaldata.kbrss.water.name;

        meat_name_text.text = globaldata.karss.meat.name;
        meat_ingreds_text.text = globaldata.karss.meat.get_ingreds();

        bread_name_text.text = globaldata.karss.bread.name;
        bread_ingreds_text.text = globaldata.karss.bread.get_ingreds();

        grog_name_text.text = globaldata.karss.grog.name;
        grog_ingreds_text.text = globaldata.karss.grog.get_ingreds();

        wood_name_text.text = globaldata.gbrss.wood.name;

        setNums();
    }

    void setNums()
    {
        game_num_text.text = globaldata.kbrss.game.num.ToString();
        grain_num_text.text = globaldata.kbrss.grain.num.ToString();
        water_num_text.text = globaldata.kbrss.water.num.ToString();
        meat_num_text.text = globaldata.karss.meat.num.ToString();
        bread_num_text.text = globaldata.karss.bread.num.ToString();
        grog_num_text.text = globaldata.karss.grog.num.ToString();
        wood_num_text.text = globaldata.gbrss.wood.num.ToString();
    }
    
	public void createRssMission(string type)
    {
        mission tmp;

        error_text.text = "";

        tmp = new mission("gather " + type, "Gathering " + type + " for " + gather_duration + " hours", gameclock.timeofday.AddHours(gather_duration));

        if (type == "game")
        {
            game_button_text.text = game_button_text.text + " *";
            tmp.rewards.add_basic_reward(globaldata.kbrss.game, gather_duration * 100);
        }
        else if (type == "grain")
        {
            grain_button_text.text = grain_button_text.text + " *";
            tmp.rewards.add_basic_reward(globaldata.kbrss.grain, gather_duration * 100);
        }
        else if (type == "water")
        {
            water_button_text.text = water_button_text.text + " *";
            tmp.rewards.add_basic_reward(globaldata.kbrss.water, gather_duration * 100);
        }
        else if (type == "wood")
        {
            wood_button_text.text = wood_button_text.text + " *";
            tmp.rewards.add_basic_reward(globaldata.gbrss.wood, gather_duration * 100);
        }

        globaldata.missions.Add(tmp);
    }

    public void createCookMission(string type)
    {
        mission tmp;
        string missing_ingred;

        error_text.text = "";

        tmp = new mission("prepare " + type, "Preparing " + type + " for " + gather_duration + " hours", gameclock.timeofday.AddHours(gather_duration));

        if (type == "meat")
        {
            tmp.rewards.add_advanced_reward(globaldata.karss.meat, gather_duration * 10);
            missing_ingred = globaldata.karss.meat.subtractIngreds(gather_duration);
            if (missing_ingred != "")
            {
                error_text.text = "not enough " + missing_ingred;
                return;
            }
            meat_button_text.text = meat_button_text.text + " *";
        }
        else if (type == "bread")
        {
            tmp.rewards.add_advanced_reward(globaldata.karss.bread, gather_duration * 10);
            missing_ingred = globaldata.karss.bread.subtractIngreds(gather_duration);
            if (missing_ingred != "")
            {
                error_text.text = "not enough " + missing_ingred;
                return;
            }
            bread_button_text.text = bread_button_text.text + " *";
        }
        else if (type == "grog")
        {
            tmp.rewards.add_advanced_reward(globaldata.karss.grog, gather_duration * 10);
            missing_ingred = globaldata.karss.grog.subtractIngreds(gather_duration);
            if (missing_ingred != "")
            {
                error_text.text = "not enough " + missing_ingred;
                return;
            }
            grog_button_text.text = grog_button_text.text + " *";
        }

        setNums();
        globaldata.missions.Add(tmp);
    }

    // get duration for missions
    public void set_duration_2(bool on)
    {
        if (on)
            gather_duration = 2;
    }
    public void set_duration_4(bool on)
    {
        if (on)
            gather_duration = 4;
    }
    public void set_duration_8(bool on)
    {
        if (on)
            gather_duration = 8;
    }
}
