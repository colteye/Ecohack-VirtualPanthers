using UnityEngine;
using UnityEngine.UI;

public class ClimateController : MonoBehaviour
{
    [SerializeField] Slider agriculture;
    [SerializeField] Slider transportation;
    [SerializeField] Slider electricity;
    [SerializeField] Slider industry;
    [SerializeField] Slider forestry;

    [SerializeField] float billionsEmissionsAgriculture = 5.1f;
    [SerializeField] float billionsEmissionsTransportation = 6.9f;
    [SerializeField] float billionsEmissionsElectricity = 13.1f;
    [SerializeField] float billionsEmissionsIndustry = 10.3f;
    [SerializeField] float billionsEmissionsForestry = 2.8f;

    [SerializeField] int agricultureThreshold = 4;
    [SerializeField] int transportationThreshold = 5;
    [SerializeField] int electricityThreshold = 10;
    [SerializeField] int industryThreshold = 8;
    [SerializeField] int forestryThreshold = 3;

    [SerializeField] Text EmissionsOutput;

    [SerializeField] AirQualityController airQuality;
    [SerializeField] WaterLevelController waterLevel;

    float maxEmissions = 0;

    int startingPoints = 25;

    float maxSeaLevel = 2.7432f;

    private void Awake()
    {
        maxEmissions = 
            billionsEmissionsAgriculture + 
            billionsEmissionsTransportation + 
            billionsEmissionsElectricity + 
            billionsEmissionsIndustry + 
            billionsEmissionsForestry;
        Debug.Log(maxEmissions);
    }

    float GetEmissions(int threshold, float emissions, float value)
    {
        float emit;
        if (value >= threshold) emit = emissions;
        else emit = (emissions / threshold) * value;

        return emit;
    }

    void CalculateEmissions()
    {
        float agri = GetEmissions(agricultureThreshold, billionsEmissionsAgriculture, agriculture.value);
        float tran = GetEmissions(transportationThreshold, billionsEmissionsTransportation, transportation.value);
        float elec = GetEmissions(electricityThreshold, billionsEmissionsElectricity, electricity.value);
        float indu = GetEmissions(industryThreshold, billionsEmissionsIndustry, industry.value);
        float fore = GetEmissions(forestryThreshold, billionsEmissionsForestry, forestry.value);

        float result = maxEmissions - agri - tran - elec - indu - fore;


        float sea = EmissionsToSeaLevel(result);

        EmissionsOutput.text = string.Format("Current Emissions: {0:0.00} Billions of Metric Tons of CO2.\nSea Level from 2020: {1:0.00} Meters", result, sea);

        airQuality.ChangeEmissions(result);
        // Edited for sake of visualization.
        waterLevel.SetWaterHeight(EmissionsToSeaLevel(result));
    }

    private void Update()
    {
        CalculateEmissions();
    }

    float EmissionsToSeaLevel(float emissions)
    {
        return maxSeaLevel / maxEmissions * emissions;
    }
}
