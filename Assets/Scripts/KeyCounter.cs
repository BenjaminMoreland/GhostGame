using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCounter : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().KeyText = keys.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerControl>().keys++;
            Destroy(gameObject);

        }
    }
}