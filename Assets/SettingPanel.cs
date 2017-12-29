using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {

    public Text p1_L;
    public Text p1_D;
    public Text p1_R;
    public Text p2_L;
    public Text p2_D;
    public Text p2_R;

    public GameObject scrollM;
    public GameObject scrollS;

    public GameObject PressAnyKey;

    // Use this for initialization
    void Start () {
        p1_L.text = ((KeyCode)PlayerPrefs.GetInt("key_left_p1")).ToString();
        p1_D.text = ((KeyCode)PlayerPrefs.GetInt("key_fight_p1")).ToString();
        p1_R.text = ((KeyCode)PlayerPrefs.GetInt("key_right_p1")).ToString();
        p2_L.text = ((KeyCode)PlayerPrefs.GetInt("key_left_p2")).ToString();
        p2_D.text = ((KeyCode)PlayerPrefs.GetInt("key_fight_p2")).ToString();
        p2_R.text = ((KeyCode)PlayerPrefs.GetInt("key_right_p2")).ToString();
    }
	
	// Update is called once per frame
	void Update () {
        p1_L.text = ((KeyCode)PlayerPrefs.GetInt("key_left_p1")).ToString();
        p1_D.text = ((KeyCode)PlayerPrefs.GetInt("key_fight_p1")).ToString();
        p1_R.text = ((KeyCode)PlayerPrefs.GetInt("key_right_p1")).ToString();
        p2_L.text = ((KeyCode)PlayerPrefs.GetInt("key_left_p2")).ToString();
        p2_D.text = ((KeyCode)PlayerPrefs.GetInt("key_fight_p2")).ToString();
        p2_R.text = ((KeyCode)PlayerPrefs.GetInt("key_right_p2")).ToString();
        scrollM.GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("music_value");
        scrollS.GetComponent<Scrollbar>().value = PlayerPrefs.GetFloat("sound_value");
    }

    public void SetMusic(float v)
    {
        PlayerPrefs.SetFloat("music_value", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }

    public void SetSound(float v)
    {
        PlayerPrefs.SetFloat("sound_value", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }

    public void SetRecord(int v)
    {
        PlayerPrefs.SetInt("record", v);
        Camera.main.GetComponent<TheSetting>().allSetUpdate();
    }

    public void ChangeKeys(string what)
    {
        PressAnyKey.active = true;
        PressAnyKey.GetComponent<changeKey>().changeWhat = what;
    }

}
