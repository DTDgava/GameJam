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


    private void Start()
    {
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
            yield return new WaitForSeconds(Disable);
            Close();
        }
    }
    void Close()
    {
        this.gameObject.SetActive(false);
    }
}
