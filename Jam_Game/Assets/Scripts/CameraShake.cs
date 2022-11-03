using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(CameraShakeCoroutine(1f));
    }

    private IEnumerator CameraShakeCoroutine(float duration)
    {
        float elapsed = 0.0f;
        float currentMagnitude = 1f;

        while (elapsed < duration)
        {
            float x = (Random.value - 0.5f) * currentMagnitude;
            float y = (Random.value - 0.5f) * currentMagnitude;

            transform.localPosition = new Vector3(x, 0, 0);

            elapsed += Time.deltaTime;
            currentMagnitude = (1 - (elapsed / duration) * (1 - (elapsed / duration)));

            yield return null;
        }
        transform.localPosition = Vector3.zero;
    }
}
