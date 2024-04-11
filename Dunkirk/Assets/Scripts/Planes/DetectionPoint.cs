using UnityEngine;

public class DetectionPoint : MonoBehaviour
{
    [SerializeField] private IdentificationMarks _idMark;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.TryGetComponent(out ViewPoint viewPoint);

        if (viewPoint == null) return;

        if (viewPoint.IdMark == _idMark) return;

        viewPoint.SpotTarget(transform);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.TryGetComponent(out ViewPoint viewPoint);

        if (viewPoint == null) return;

        if (viewPoint.IdMark == _idMark) return;

        viewPoint.UnspotTarget();
    }
}
