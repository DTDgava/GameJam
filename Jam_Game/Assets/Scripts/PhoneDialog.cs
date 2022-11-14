using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDialog : MonoBehaviour
{
    public AudioSource Dialog;
    public AudioSource SoundPhone;
    public GameObject Viewpoint;

    public Text TextWrite;

    bool TextPub;
    private void OnMouseOver()
    {
        if(Input.GetKey(KeyCode.E) && Viewpoint.activeSelf == true)
        {
            Dialog.Play();
            SoundPhone.Stop();

            Viewpoint.GetComponent<EvolveGames.Viewpoint>().Close();
            Viewpoint.SetActive(false);    
        }
    }
    private void Update()
    {
        if (Dialog.isPlaying == false && Viewpoint.activeSelf == false && TextPub == false)
        {
            TextWrite.GetComponent<TextWriteQuest>().TextArea.text = "Leave from house";
            TextWrite.GetComponent<TextWriteQuest>().OnAwake();
            TextPub = true;
        }
    }
}
