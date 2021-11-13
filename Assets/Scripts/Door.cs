using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerControl PC = collision.gameObject.GetComponent<PlayerControl>();
        if (PC != null)
        {
            if (PC.keys == 5)
            {
                Destroy(gameObject, 1.5f);
            }
        }

    }
}
