using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void UpdateData(Vector3 playerPos, Vector3 cameraDirection);
}
