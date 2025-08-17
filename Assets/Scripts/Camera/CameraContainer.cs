using UnityEngine;

[CreateAssetMenu(fileName = "Camera Container", menuName = "Other/Camera Container", order = 1)]
public class CameraContainer : ScriptableObject
{
    [SerializeField] private CameraObject _cameraObject;

    public CameraObject CameraObject => _cameraObject;
}