using UnityEngine;

public class WeaponMountPoint : MonoBehaviour
{
    public Transform Mount => transform;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.05f);
    }
#endif
}