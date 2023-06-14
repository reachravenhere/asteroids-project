using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PanelManager : MonoBehaviour
{

    public List<BasePanel> panels = new List<BasePanel>();

    public static PanelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        panels = GetComponentsInChildren<BasePanel>().ToList();
    }

    public static T OpenPanel<T>() where T : BasePanel
    {
        for (int i = 0; i < instance.panels.Count; i++)
        {
            if (instance.panels[i] is T)
            {
                instance.panels[i].Open();
                return instance.panels[i] as T;
            }
        }

        Debug.LogError("Could not find a panel of type: " + typeof(T).ToString());
        return null;
    }
    
}
