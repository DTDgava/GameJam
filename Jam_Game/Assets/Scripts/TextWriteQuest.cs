using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextWriteQuest : MonoBehaviour
{
    public Text TextArea;

    private string text;

    [SerializeField] private float Speed;
    [SerializeField] private float Disable;


    private void Start()
    {
        TextArea = GetComponent<Text>();
        OnAwake();
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

    public void OnAwake()
    {
        text = TextArea.text;
        TextArea.text = null;
        StartCoroutine(TextAnimation());
    }
    void Close()
    {
        TextArea.text = null;
    }
}
