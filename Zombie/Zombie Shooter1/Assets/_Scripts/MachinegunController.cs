using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinegunController : MonoBehaviour
{
    public void Rotation(float rotation)
    {
        transform.eulerAngles = new Vector3(0, 0, rotation);
    }
}
