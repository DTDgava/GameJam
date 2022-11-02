using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightObject;

    public Light standartLight;
    public Light ghostLight;

    public float maxValueBattery = 100f;
    public float currentValueBattery = 70f;

    private void Update()
    {
        TurnFlashLight();
    }

    void TurnFlashLight()
    {
        if(FlashlightObject.activeSelf == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                standartLight.enabled = true;
                ghostLight.enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.F)){
              
                standartLight.enabled = false;
                ghostLight.enabled = true;
            }
        }
    }
}
