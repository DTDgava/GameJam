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


    private void Start()
    {
        AudioKeyBoard = GetComponent<AudioSource>();
        CloseTextAnim = GetComponent<Animation>();
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
            TextArea.transform.position = new Vector3(960,YPos,0);
            YPos += Time.deltaTime * 5;
        }
        if (TextArea.text == text)
        {
            AudioKeyBoard.Stop();
            yield return new WaitForSeconds(Disable);
            Close();
        }
    }
    void Close()
    {
        CloseTextAnim.Play();
    }
    private void Update()
    {
    }
}
