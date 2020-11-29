using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirQualityController : MonoBehaviour
{
    [SerializeField] ParticleSystem AirQualityParticle;
    [SerializeField] float MaxEmissions = 91;
    [SerializeField] float particleMaxSize = 100;

    public void ChangeEmissions(float emissions)
    {
        var main = AirQualityParticle.main;
        main.startSize = emissions / MaxEmissions * particleMaxSize;
    }
}
