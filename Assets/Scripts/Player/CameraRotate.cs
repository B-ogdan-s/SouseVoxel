using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _cameraRotateY;
    [SerializeField] private float _cameraRotateYSpeed;

    public Transform CameraTransformY => _cameraRotateY;

    public void Rotate(Vector2 delta)
    {
        _cameraRotateY.localEulerAngles += new Vector3(0, delta.x, 0) * Time.deltaTime * _cameraRotateYSpeed;
    }


}
