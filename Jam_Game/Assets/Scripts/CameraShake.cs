using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Camera mainCamera;
    public float Shake;
    public float Duration;

    private void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "GameController")
        {
            StartCoroutine(CameraShakeCoroutine(Duration));
        }
    }


    private IEnumerator CameraShakeCoroutine(float duration)
    {
        float elapsed = 0.0f;
        float currentMagnitude = 1f;

        while (elapsed < duration)
        {
            float x = (Random.value - Shake) * currentMagnitude;
            float y = (Random.value - Shake) * currentMagnitude;

            mainCamera.transform.localPosition = new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration) * (1 - (elapsed / duration)));

            yield return null;
        }
        mainCamera.transform.localPosition = Vector3.zero;
    }
}
