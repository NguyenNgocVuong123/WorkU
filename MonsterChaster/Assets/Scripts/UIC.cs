using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIC : MonoBehaviour
{
    public void restart()
    {
        //lấy scene hiện tại để load lại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void home()
    {
        SceneManager.LoadScene("MainM");
    }
}
