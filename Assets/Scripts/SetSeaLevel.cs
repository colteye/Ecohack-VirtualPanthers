using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSeaLevel : MonoBehaviour
{
    public bool shouldWaterHeightChange = false;
    public float waterHeight;

    public Transform water_Transform;

    private void Update()
    {
        if (shouldWaterHeightChange)
        {
            ChangeWaterHeight();
        }
    }


    private void ChangeWaterHeight()
    {
        water_Transform.position = Vector3.Lerp(water_Transform.position,
                                                new Vector3(water_Transform.position.x, waterHeight, water_Transform.position.z),
                                                Time.deltaTime);
        //set bool back after change
        shouldWaterHeightChange = false;
    }

    public void SetWaterHeightValue(float numToSetWaterHeight)
    {
        waterHeight = numToSetWaterHeight;
        shouldWaterHeightChange = true;
    }
      



}
