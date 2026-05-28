using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARVideoManager : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public VideoManager videoManager;
    public UIManager uiManager;

    private void OnEnable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.AddListener(OnTrackedImagesChanged);
    }

    private void OnDisable()
    {
        if (trackedImageManager != null)
            trackedImageManager.trackablesChanged.RemoveListener(OnTrackedImagesChanged);
    }

    private void OnTrackedImagesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            Debug.Log("[AR] 이미지 최초 감지: " + trackedImage.referenceImage.name);
            HandleImage(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                HandleImage(trackedImage);
            }
            else
            {
                if (videoManager != null) videoManager.StopVideo(trackedImage);
            }
        }
    }

    private void HandleImage(ARTrackedImage img)
    {
        if (uiManager != null) uiManager.ForceHideScanText();
        if (videoManager != null) videoManager.PlayVideoAtImage(img);
    }

    public void OnClickAddImage(Texture2D texture)
    {
        Debug.Log("사용자 이미지 등록 시작: " + texture.name);
        if (trackedImageManager != null && trackedImageManager.referenceLibrary is MutableRuntimeReferenceImageLibrary mutableLibrary)
        {
            mutableLibrary.ScheduleAddImageWithValidationJob(texture, "UserImage_" + System.Guid.NewGuid(), 0.1f);
        }
    }
}