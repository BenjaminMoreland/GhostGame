using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //static variable can be accessed everywhere and it is a single int
    private static int _score = 0;
    //There can only be one OnScoreChangeEvent
    public static UnityEvent OnScoreChange = new UnityEvent();
    //allows access to the secret score and runs the scorechange event
    public static int Score
    {
        get
        {
            
            return _score;
        }
        set
        {
            _score = value;
            OnScoreChange.Invoke();
        }
    }
    //There can be only one GameManager
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }

    //This happpens before start, so we can only assume this exists.
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}