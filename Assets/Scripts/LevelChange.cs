using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    public string NextLevel = "Caden Scene";

   public void ChangeLevel()
    {
        SceneManager.LoadScene(NextLevel);
    }
}
