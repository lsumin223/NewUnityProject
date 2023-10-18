using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public LayerMask secondTargetLayer;

    public LayerMask thirdTargetLayer;

    public RaycastHit2D[] targets1;
    public RaycastHit2D[] targets2;
    public RaycastHit2D[] targets3;
    public RaycastHit2D[] targets;

    public Transform nearestTarget;

    private void FixedUpdate()
    {
        targets1 = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        targets2 = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, secondTargetLayer);
        targets3 = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, thirdTargetLayer);

        targets = new RaycastHit2D[targets1.Length + targets2.Length + targets3.Length];
        targets1.CopyTo(targets, 0);
        targets2.CopyTo(targets, targets1.Length);
        targets3.CopyTo(targets, targets1.Length + targets2.Length);

        nearestTarget = GetNearest();
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);
        
            if (curDiff < diff)
            {
                diff = curDiff;
                result = target.transform;
            }
        }


        return result;
    }
}
