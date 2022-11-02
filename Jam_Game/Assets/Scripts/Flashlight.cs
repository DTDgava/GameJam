using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject FlashlightObject;

    public Light standartLight;
    public Light ghostLight;

    public float maxValueBattery = 100f;
    public float currentValueBattery = 70f;

    public float SpotAngleFlashLight = 50f;


    public float SpeedBatteryLose;
    public float SpeedBatteryLoseGhost;

    private void Update()
    {
        TurnFlashLight();
        BatteryUpdate();
    }


    void BatteryUpdate()
    {
        if (currentValueBattery > 0)
        {
            if (standartLight.enabled == true)
            {
                currentValueBattery -= Time.deltaTime * SpeedBatteryLose;
            }
            else if (ghostLight.enabled == true)
            {
                currentValueBattery -= Time.deltaTime * SpeedBatteryLoseGhost;
            }
        }
        else if(currentValueBattery <= 0)
        {
            currentValueBattery = 0;
            standartLight.enabled = false;
            ghostLight.enabled = false;
            ghostLight.spotAngle = 1;
        }
    }
    void TurnFlashLight()
    {
        if(FlashlightObject.activeSelf == true && currentValueBattery > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ghostLight.enabled == true)
                {
                    standartLight.enabled = true;
                    ghostLight.enabled = false;
                    ghostLight.spotAngle = 1;
                }
                else if (standartLight.enabled == true)
                {
                    standartLight.enabled = false;
                    ghostLight.enabled = true;
                    ghostLight.spotAngle = SpotAngleFlashLight;
                }
            }

            else if (Input.GetKeyDown(KeyCode.F))
            {
                if (standartLight.enabled == true | ghostLight.enabled == true)
                {
                    standartLight.enabled = false;
                    ghostLight.enabled = false;
                    ghostLight.spotAngle = 1;
                }
                else if(standartLight.enabled == false | ghostLight.enabled == false)
                {
                    standartLight.enabled = true;
                    ghostLight.enabled = false ;
                    ghostLight.spotAngle = 1;
                }
            }
        }
    }
}
