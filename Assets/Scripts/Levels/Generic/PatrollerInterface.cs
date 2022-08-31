using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PatrollerInterface
{
    public void SelectNewTarget(bool random);

    public void FaceDestination();
}
