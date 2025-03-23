using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public void OnPause() 
    {
        Time.timeScale = 0;
    }

    public void TakeOffPause() 
    {
        Time.timeScale = 1;
    }
}
