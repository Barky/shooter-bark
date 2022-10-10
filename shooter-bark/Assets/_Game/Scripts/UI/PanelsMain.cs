using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PanelStatus
{
    Unknown,
    Opened,
    Closed
}
public abstract class PanelsMain : MonoBehaviour
{
    private PanelStatus currentstatus = PanelStatus.Unknown;

    private void Awake()
    {
        gameObject.SetActive(false);
        currentstatus = PanelStatus.Closed;
        onAwake();
    }


    public virtual void onAwake()
    {
        
    }

    public void Open()
    {
        if (currentstatus == PanelStatus.Opened) return;
        
        gameObject.SetActive(true);

        currentstatus = PanelStatus.Opened;
        
        onOpened();


    }

    public void Close()
    {
        if (currentstatus == PanelStatus.Closed) return;
        
        else if (currentstatus == PanelStatus.Unknown)
        {
            gameObject.SetActive(false);
            
        }

        else
        {
            // if opened
            gameObject.SetActive(false);
        }

        currentstatus = PanelStatus.Closed;
    }

    protected virtual void onOpened()
    {
        
    }

    public virtual void onClosed()
    {
        
    }

    
}
