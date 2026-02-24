using UnityEngine;
using Cinemachine;

public class AdaptiveCameraSize : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private float targetAspect = 16f / 9f;
    [SerializeField] private float baseOrthographicSize = 10f;

    void Start()
    {
        AdjustCameraSize();
    }

    void Update()
    {
        AdjustCameraSize();
    }

    void AdjustCameraSize()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float aspectRatio = currentAspect / targetAspect;

        if (aspectRatio < 1f)
        {
            virtualCamera.m_Lens.OrthographicSize = baseOrthographicSize / aspectRatio;
        }
        else
        {
            virtualCamera.m_Lens.OrthographicSize = baseOrthographicSize;
        }
    }
}
