using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel : MonoBehaviour
{

    protected GameObject view;

    protected virtual void Awake()
    {
        view = transform.Find("View").gameObject;

        if(view ==null )
        {
            Debug.LogError("Could not find a View for a panel: " + GetType().Name +
                ". Ensure that all viewable parts of the panel are under a View Gameobject");

        }
    }

    //allows us to open and close panels easily
    public virtual void Open()
    {
        view.SetActive(true);
    }

   public virtual void Close()
    {
        view.SetActive(false);
    }



}
