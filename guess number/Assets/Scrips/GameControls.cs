using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour
{
    [SerializeField]
    private InputField input;
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    private Text text;

    private int num;
    private int count= 1;
    

    private void Awake()
    {
        //input = GameObject.Find("InputField").GetComponent<InputField>();
        
        num = Random.Range(0, 100);
        btn.SetActive(true);
    }
    public void getInput(string guess)
    {
        guessnum(int.Parse(guess));
        Debug.Log("enter: " + guess);
        input.text = "";
        count++;
    }

    //so sanh
    public void guessnum(int guess)
    {
        if(num == guess)
        {
            text.text ="you win, the number is: " + num + " after " + count + " tried, again?";
            btn.SetActive(true);
        } else if(num < guess)
        {
            text.text = "no, is smoler";
        }else if(num > guess)
        {
            text.text = "no, is bigger";
        }
    }
    public void playagin()
    {
        num = Random.Range(0, 100);
        text.text = "Guess from 0 to 100";
        count = 1;
        btn.SetActive(false);
    }
}
