using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class SetTrackingType : MonoBehaviour
{
    private Transform m_CameraRig;
    private Transform m_CentreEyeAnchor;
    //public OVRCameraRig m_OVRCameraRig;

    void Start()
    {
        //m_CentreEyeAnchor = m_OVRCameraRig.centerEyeAnchor;
        //m_CameraRig = m_OVRCameraRig.transform;
    }

    private void ResetVRPosition(Transform teleportPoint) //Do the same as OVRManager.display.RecenterPose() but works in Virtual Desktop and EyeLevelTracking
    {

        float currentRotY = m_CentreEyeAnchor.eulerAngles.y;
        float targetYRotation = 0.0f;
        float difference = targetYRotation - currentRotY;
        m_CameraRig.Rotate(0, difference, 0);

        Vector3 newPos = new Vector3(teleportPoint.position.x - m_CentreEyeAnchor.position.x, 0, teleportPoint.position.z - m_CentreEyeAnchor.position.z);
        m_CameraRig.transform.position += newPos;

    }
}