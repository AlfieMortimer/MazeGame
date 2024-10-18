using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadscene : MonoBehaviour
{
    public int scene;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void loadgame()
    {
        SceneManager.LoadScene(scene);
    }
}
