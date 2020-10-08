using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject Box_Prefab;

    public void SpawnBox()
    {
        GameObject Box_obj = Instantiate(Box_Prefab);

        Vector3 temp = transform.position;
        temp.z = 0f;
        Box_obj.transform.position = temp;

    }
}
