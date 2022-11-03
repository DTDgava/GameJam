using System.Collections;
using UnityEngine;
using Kino;

public class GlitchSystem : MonoBehaviour
{
    public DigitalGlitch GlitchEffect;
    public DigitalGlitch GlitchJitter;

    public float IntensityGE;
    public float IntensityJT;

    private void Start()
    {
        GlitchJitter.enabled = false;
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "GameController")
        {
            GlitchEffect.enabled = true;
            GlitchJitter.enabled = true;

            Vector3 distanceVector = collider.transform.position - transform.position;

            GlitchEffect.intensity = IntensityGE / distanceVector.magnitude;
            GlitchJitter.intensity = IntensityJT / distanceVector.magnitude;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "GameController")
        {
            GlitchEffect.intensity = 0; 
            GlitchEffect.enabled = false;
            GlitchJitter.enabled = false;
        }
    }
}
