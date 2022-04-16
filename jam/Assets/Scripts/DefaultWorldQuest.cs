using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DefaultWorldQuest : MonoBehaviour
{
    [SerializeField] private string[] sentences;

    public Text QuestText;
    public Text EscapeQuest;


    public GameObject EscapeMenu;
    public GameObject DialogWindow;
    public GameObject AcceptOrDecilineWindow;
    public GameObject QuestHero;
    public GameObject PortalText;

    public Animator Animator;

    public int NumQuest;

    bool CanUseWaterPortal;


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E) & PortalText.activeSelf == true & CanUseWaterPortal == true)
        {
            SceneManager.LoadScene("WaterWorld");
        }
        if(Input.GetKey(KeyCode.Escape))
        {
            EscapeMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (Input.GetKeyDown(KeyCode.F) && DialogWindow.activeSelf == true)
        {
            NumQuest++;
            if (NumQuest == sentences.Length )
            {
                AcceptOrDecilineWindow.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
            }
            if (NumQuest < sentences.Length)
            {
                QuestText.text = sentences[NumQuest];
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "QuestDefault")
        {
            Animator.SetBool("Dialog", true);
            Time.timeScale = 0;
            DialogWindow.SetActive(true);
            QuestText.text = sentences[NumQuest];
        }
        if(other.tag == "Portal1")
        {
            PortalText.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Portal1")
        {
            PortalText.SetActive(false);
        }
    }
    public void AcceptQuest()
    {
        QuestHero.SetActive(false);
        NumQuest = 0;
        DialogWindow.SetActive(false);
        EscapeQuest.text = "Kill Lord of Lava World";
        Animator.SetBool("Dialog", true);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        CanUseWaterPortal = true;
    }
    public void DeclineQuest()
    {
        DialogWindow.SetActive(false);
        NumQuest = 0;
        Time.timeScale = 1;
        Animator.SetBool("Dialog", true);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        EscapeMenu.SetActive(false);
    }
}
