using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    public event Action SpeedUp = delegate { };
    public event Action Play = delegate { };
    public event Action Pause = delegate { };
    public event Action Build = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onPlayClick()
    {
        Play();
    }

    public void onPauseClick()
    {
        Pause();
    }

    public void onFastClick()
    {
        SpeedUp();
    }
}
