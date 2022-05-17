using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForSkinsShop : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] float _RotateSkinHolder = 0.5f;
    private void Update()
    {
        transform.Rotate(0,_RotateSkinHolder,0, Space.World);   
    }
}
