using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Transform cam;
    Vector3 target = Vector3.zero;

    void Start()
    {
        cam = Camera.main.transform;
    }
    private void Update()
    {
        transform.LookAt(cam);
        target = transform.localEulerAngles;
        target.x = 0;
        target.z = 0;
        transform.localEulerAngles = target;
    }
}