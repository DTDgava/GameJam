using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    public GameObject CameraImage;
    public GameObject CameraObject;

    float second;
    float minute;
    float hour;

    public Text TimeText;

    private Flashlight flashLight;

    private void Awake()
    {
        flashLight = GetComponent<Flashlight>();
    }
    void OnCamera()
    {
        CameraImage.SetActive(true);
    }
    public void OffCamera()
    {
        CameraImage.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (CameraObject.activeSelf == true)
        {
            if (CameraImage.activeSelf == true)
            {
                second += Time.deltaTime / 2.3f;
                if (second >= 60)
                {
                    minute += 1;
                    second = 0;
                }
                if (minute >= 60)
                {
                    hour += 1;
                    minute = 0;
                }
            }
            if (other.tag == "CanRecord")
            {
                TimeText.text = hour + ":" + minute + ":" + Mathf.Round(second);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (CameraImage.activeSelf == true)
                    {
                        OffCamera();
                    }
                    else if (CameraImage.activeSelf == false)
                    {
                        OnCamera();
                    }
                }
            }
            if(CameraImage.activeSelf == true && Input.GetMouseButton(1))
            {
                flashLight.ghostLight.enabled = true;
                flashLight.ghostLight.spotAngle = flashLight.SpotAngleGhostLight;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CanRecord")
        {
            OffCamera();
        }
    }
}
