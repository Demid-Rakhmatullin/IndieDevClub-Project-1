using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextModuleGenerator : MonoBehaviour
{
    public string ResourcePrefabName;
    public float XOffset;
    public float ZOffset;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var curentModule = transform.parent;
            var nextModulePos = new Vector3(curentModule.position.x + XOffset, curentModule.position.y, curentModule.position.z + ZOffset);

            GameManager.Instance.CreateModule(ResourcePrefabName, nextModulePos, curentModule.rotation);
        }
    }
}
