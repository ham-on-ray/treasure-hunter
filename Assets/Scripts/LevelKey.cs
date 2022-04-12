using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKey : Collectable
{
    private bool _isCollected = false;

    protected override void OnTriggerEnter(Collider other)
    {
        _isCollected = true;
        base.OnTriggerEnter(other);
    }

    public bool IsCollected() => _isCollected;
}
