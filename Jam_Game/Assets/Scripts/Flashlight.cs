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

    EvolveGames.ItemChange ChangeItemScrpt;

    private void Awake()
    {
        ChangeItemScrpt = GetComponent<EvolveGames.ItemChange>();
    }
    private void Update()
    {
        TurnFlashLight();
        BatteryUpdate();
    }


    void BatteryUpdate()
    {
        if (currentValueBattery > 0 && FlashlightObject.activeSelf == true)
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
        else if (currentValueBattery <= 0)
        {
            currentValueBattery = 0;
            OffLight();
        }
    }
    void TurnFlashLight()
    {
        if (FlashlightObject.activeSelf == true && currentValueBattery > 0)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (ghostLight.enabled == true)
                {
                    OnStandartLight();
                }
                else if (standartLight.enabled == true)
                {
                    standartLight.enabled = false;
                    ghostLight.enabled = true;
                    ghostLight.spotAngle = SpotAngleFlashLight;
                }
            }

            else if (Input.GetKeyDown(KeyCode.F) && ChangeItemScrpt.Hided == false)
            {
                if (standartLight.enabled == true | ghostLight.enabled == true)
                {
                    OffLight();
                }
                else if (standartLight.enabled == false | ghostLight.enabled == false)
                {
                    OnStandartLight();
                }
            }
        }
    }
    public void OffLight()
    {
        standartLight.enabled = false;
        ghostLight.enabled = false;
        ghostLight.spotAngle = 1;
    }
    public void OnStandartLight()
    {
        standartLight.enabled = true;
        ghostLight.enabled = false;
        ghostLight.spotAngle = 1;
    }
}
