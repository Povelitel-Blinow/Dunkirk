using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewPoint : MonoBehaviour
{
    [SerializeField] private IdentificationMarks _idMark;

    public Transform Target { get; private set; }

    public IdentificationMarks IdMark => _idMark;

    public void SpotTarget(Transform target)
    {
        if(Target == null)
            Target = target;
    }

    public void UnspotTarget()
    {
        Target = null;
    }
}

public enum IdentificationMarks
{
    None,
    English,
    German
}