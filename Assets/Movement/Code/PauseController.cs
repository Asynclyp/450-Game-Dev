using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public UnityEvent GamePaused;

    public UnityEvent GameResumed;

    private bool _isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                Time.timeScale = 0;
                pause();
            }
            else
            {
                Time.timeScale = 1;
                resume();
            }
        }
    }

    private void pause()
    {
        GamePaused.Invoke();
    }
    private void resume()
    {
        GameResumed.Invoke();
    }
}


