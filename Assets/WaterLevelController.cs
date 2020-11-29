using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterLevelController : MonoBehaviour
{
    [SerializeField] Transform water;

    // Input water height in meters from current (2020) levels.
    public void SetWaterHeight(float waterHeight)
    {
        water.position = new Vector3(water.position.x, waterHeight / 100, water.position.z);
    }
}
