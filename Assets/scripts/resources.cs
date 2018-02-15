using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class basic_resource
{
    public string name;
    public int num;

    public basic_resource(string type, int n)
    {
        name = type;
        num = n;
    }
}

public class ingredient
{
    public basic_resource rss;
    public int num;
}

public class advanced_resource
{
    public string name;
    public int num;
    List<ingredient> ingreds;

    public advanced_resource(string type, int n)
    {
        name = type;
        num = n;
        ingreds = new List<ingredient>();
    }

    public void add_ingred(basic_resource ingred, int n)
    {
        ingredient tmp;

        tmp = new ingredient();
        tmp.rss = ingred;
        tmp.num = n;
        ingreds.Add(tmp);
    }

    public string get_ingreds()
    {
        string tmp = "";

        foreach (ingredient i in ingreds)
        {
            tmp += i.rss.name;
            if (i.num > 1)
                tmp += " (" + i.num + ")   ";
            else
                tmp += "   ";
        }

        return tmp;
    }

    public string subtractIngreds(int n)
    {
        foreach (ingredient i in ingreds)
        {
            if (i.rss.num < (i.num * n))
                return i.rss.name;
        }

        foreach (ingredient i in ingreds)
        {
            i.rss.num -= (i.num * n);
        }

        return "";
    }
}

public class kitchen_basic_resources
{
    public basic_resource game;
    public basic_resource grain;
    public basic_resource water;

    public kitchen_basic_resources()
    {
        game = new basic_resource("game", 100);
        grain = new basic_resource("grain", 100);
        water = new basic_resource("water", 100);
    }
}

public class kitchen_adv_resources
{
    public advanced_resource meat;
    public advanced_resource bread;
    public advanced_resource grog;

    public kitchen_adv_resources()
    {
        meat = new advanced_resource("meat", 150);
        meat.add_ingred(globaldata.kbrss.game, 20);
    
        bread = new advanced_resource("bread", 250);
        bread.add_ingred(globaldata.kbrss.grain, 20);
        bread.add_ingred(globaldata.kbrss.water, 10);

        grog = new advanced_resource("grog", 350);
        grog.add_ingred(globaldata.kbrss.grain, 10);
        grog.add_ingred(globaldata.kbrss.water, 20);
    }
}

public class general_basic_resources
{
    public basic_resource wood;

    public general_basic_resources()
    {
        wood = new basic_resource("wood", 500);
    }
}



