using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMC : MonoBehaviour
{
    
    public void Playgame()
    {
        //lưu giá trị đã chọn
        int selectedCharacter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        //gắn giá trị vào biến
        GameMn.instance.charIndex = selectedCharacter;
        //chạy màn mình gameplay
        SceneManager.LoadScene("GamePlay");
    }

}
