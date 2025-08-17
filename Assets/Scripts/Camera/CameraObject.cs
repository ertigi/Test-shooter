using Cinemachine;
using UnityEngine;

public class CameraObject : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _freeLookCamera;
    [SerializeField] private Camera _camera;

    public Transform CameraTransform => _camera.transform;

    public void SetTraget(Transform cameraFollowPoint)
    {
        _freeLookCamera.Follow = cameraFollowPoint;
        _freeLookCamera.LookAt = cameraFollowPoint;
    }
}