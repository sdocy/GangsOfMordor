using UnityEngine;
using System.Collections;

public static class GEM {

    public delegate void GameEvent(GEA eventArgs);
    public static event GameEvent event_EnterArea;

    public static void trigger_EnterArea(GEA eventArgs = null)
    {
        if (event_EnterArea != null)
            event_EnterArea(eventArgs);
    }
    
}
