using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirQualityController : MonoBehaviour
{
    [SerializeField] ParticleSystem AirQualityParticle;
    [SerializeField] float MaxEmissions = 91;
    [SerializeField] float particleMaxSize = 100;

    [SerializeField] Text EmissionsText;

    // Assume level goes from 0 to 1.
    public void ChangeEmissions(float level)
    {
        float currentEmissions = level * MaxEmissions;
        EmissionsText.text = string.Format("Current Emissions: {0} Billion Metric Tons of CO2", currentEmissions);

        var main = AirQualityParticle.main;
        main.startSize = level * particleMaxSize;
    }
}
