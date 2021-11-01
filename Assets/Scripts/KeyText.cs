using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyText : MonoBehaviour
{
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = "Keys:" + score.ToString() + "/5";

    }

    public void IncreaseScore()
    {
        score++;
        GetComponent<TMP_Text>().text = "Keys:" + score.ToString() + "/5";
    }
    
}
