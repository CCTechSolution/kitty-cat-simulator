using UnityEngine;

public class CameraRotateAtAttack : MonoBehaviour
{
    [SerializeField] Transform grannyTargetTransform;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float rotationSpeed = 5f;

    private bool canRotate;

    private void Start()
    {
        //EnemyHandler.OnGrannyStartAttack += EnemyHandler_OnGrannyStartAttack;
    }

    private void EnemyHandler_OnGrannyStartAttack()
    {
        RotateCameraTowardsTarget();
    }

    private void RotateCameraTowardsTarget()
    {
        if (grannyTargetTransform == null) return;

        Vector3 direction = grannyTargetTransform.position - cameraTransform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
   
            cameraTransform.rotation = Quaternion.Euler(0, Quaternion.LookRotation(direction).eulerAngles.y, 0);
            canRotate = false; 
        }
    }

}
