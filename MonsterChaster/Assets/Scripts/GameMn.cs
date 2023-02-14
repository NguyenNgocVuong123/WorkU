using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMn : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] charSelect;
    //truyen du lieu tu scence nay sang scn khac
    public static GameMn instance;
    private int _charIndex;
    public int charIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        //xoa nhan vat cu neu da co nhan vat cu va tao lai nhan vat de dam bao chi co duy nhat 1 nhan vat khi choi
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //đăng kí vào hàm sự kiện
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    //và khởi tạo nhân vật đã chọn dựa vào giá trị biến đã chọn ở scene trước 0-steve 1-nugge ngay khi scene GamepPlay được tạo
    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) { //hàm sự kiện
        if (scene.name == "GamePlay")
        {
            Instantiate(charSelect[charIndex]);
        }

    }
    //hủy đăng kí để tránh tràn bộ nhớ
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
}
