using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextWrite : MonoBehaviour
{
    private Text TextArea;

    private string text;

    [SerializeField] private float Speed;
    [SerializeField] private float Disable;


    private Animation CloseTextAnim;

    private AudioSource AudioKeyBoard;

    public float YPos = 540;

    public bool Anim;
    public bool Audio;


    public TextWrite TextStart;

    private void Start()
    {
        if (Audio == true)
        {
            AudioKeyBoard = GetComponent<AudioSource>();
        }
        if (Anim == true)
        {
            CloseTextAnim = GetComponent<Animation>();
        }
        TextArea = GetComponent<Text>();
        text = TextArea.text;
        TextArea.text = null;
        StartCoroutine(TextAnimation());

    }
    private IEnumerator TextAnimation()
    {
        foreach (char abc in text)
        {
            TextArea.text += abc;
            yield return new WaitForSeconds(Speed);
      
        }
        if (TextArea.text == text)
        {
            if (Audio == true)
            {
                AudioKeyBoard.Stop();
            }
            yield return new WaitForSeconds(Disable);
            Close();
            yield return new WaitForSeconds(2);
            if (TextStart != null)
            {
                TextStart.gameObject.SetActive(true);
                TextStart.enabled = true;
            }

        }
    }
    void Close()
    {
        if (Anim == true)
        {
            CloseTextAnim.Play();
        }
    }
    private void Move()
    {
        TextArea.transform.position = new Vector3(960, YPos, 0);
        YPos += Time.deltaTime * 5;
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("bebra");
        }
    }

}
