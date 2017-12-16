using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSetting : MonoBehaviour {

    public bool setP1Control;
    public bool setP2Control;
    public bool setMusicSound;
    public bool setRecord;

    public GameObject RabbitP1;
    public GameObject RabbitP2;

    public GameObject Music;
    public GameObject Sound;

    public GameObject StoryUI;





    /*

    public KeyCode downKey_P1;
    public KeyCode leftKey_P1;
    public KeyCode rightKey_P1;
    public KeyCode downKey_P2;
    public KeyCode leftKey_P2;
    public KeyCode rightKey_P2;

    public float musicValue;
    public float soundValue;

    public int stagePass;
    */

    // Use this for initialization
    void Start () {
        if (!PlayerPrefs.HasKey("key_fight_p1"))
            PlayerPrefs.SetInt("key_fight_p1", (int)KeyCode.DownArrow);
        if (!PlayerPrefs.HasKey("key_right_p1"))
            PlayerPrefs.SetInt("key_right_p1", (int)KeyCode.RightArrow);
        if (!PlayerPrefs.HasKey("key_left_p1"))
            PlayerPrefs.SetInt("key_left_p1", (int)KeyCode.LeftArrow);

        if (!PlayerPrefs.HasKey("key_fight_p2"))
            PlayerPrefs.SetInt("key_fight_p2", (int)KeyCode.S);
        if (!PlayerPrefs.HasKey("key_right_p2"))
            PlayerPrefs.SetInt("key_right_p2", (int)KeyCode.D);
        if (!PlayerPrefs.HasKey("key_left_p2"))
            PlayerPrefs.SetInt("key_left_p2", (int)KeyCode.A);


        if (!PlayerPrefs.HasKey("music_value"))
            PlayerPrefs.SetFloat("music_value", 50.0f);
        if (!PlayerPrefs.HasKey("sound_value"))
            PlayerPrefs.SetFloat("sound_value", 50.0f);

        if (!PlayerPrefs.HasKey("record"))
            PlayerPrefs.SetInt("record", 1);


        if (setP1Control)
        {
            RabbitP1.GetComponent<Control>().Key_Fight = (KeyCode)PlayerPrefs.GetInt("key_fight_p1");
            RabbitP1.GetComponent<Control>().Key_Right = (KeyCode)PlayerPrefs.GetInt("key_right_p1");
            RabbitP1.GetComponent<Control>().Key_Left = (KeyCode)PlayerPrefs.GetInt("key_left_p1");
        }

        if (setP2Control)
        {
            RabbitP2.GetComponent<Control>().Key_Fight = (KeyCode)PlayerPrefs.GetInt("key_fight_p2");
            RabbitP2.GetComponent<Control>().Key_Right = (KeyCode)PlayerPrefs.GetInt("key_right_p2");
            RabbitP2.GetComponent<Control>().Key_Left = (KeyCode)PlayerPrefs.GetInt("key_left_p2");
        }

        if (setMusicSound)
        {
            Music.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("music_value");
            Sound.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("sound_value");
        }

        if (setRecord)
        {
            StoryUI.GetComponent<UiInStory>().checkStage(PlayerPrefs.GetInt("record"));
        }

    }

}
