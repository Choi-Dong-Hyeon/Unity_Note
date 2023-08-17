using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float _scanRange;
    public LayerMask _targetLayer;
    public RaycastHit2D[] _targets;
    public Transform _nearTarget;

    void FixedUpdate()
    {
        _targets = Physics2D.CircleCastAll(transform.position, _scanRange, Vector2.zero, 0, _targetLayer);
        _nearTarget = GetNearst();
    }

    Transform GetNearst()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in _targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curdif = Vector3.Distance(myPos,targetPos);

            if (curdif < diff)
            {
                diff = curdif;
                result = target.transform;
            }
        }

        return result;
    }

}
