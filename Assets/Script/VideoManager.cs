using UnityEngine;
using UnityEngine.Video;
using UnityEngine.XR.ARFoundation;

public class VideoManager : MonoBehaviour
{
    public void PlayVideoAtImage(ARTrackedImage trackedImage)
    {
        // 이미지의 자식으로 붙어있는 프리팹 복사본을 직접 검사
        VideoPlayer vp = trackedImage.GetComponentInChildren<VideoPlayer>(true);

        if (vp != null)
        {
            // 비디오 스크린 오브젝트 강제 활성화
            if (!vp.gameObject.activeSelf)
            {
                vp.gameObject.SetActive(true);
            }

            // 회전/크기 꼬임 방지를 위해 로컬 좌표 보정
            vp.transform.localPosition = Vector3.zero;
            vp.transform.localRotation = Quaternion.identity;

            if (!vp.isPlaying)
            {
                Debug.Log("[Video] 영상 재생 시도: " + trackedImage.referenceImage.name);
                vp.Play();
            }
        }
        else
        {
            // 간혹 첫 프레임에 찾지 못했을 때 로그 기록
            Debug.LogWarning("[Video] 이미지 위에 VideoPlayer 프리팹을 찾을 수 없음!");
        }
    }

    public void StopVideo(ARTrackedImage trackedImage)
    {
        VideoPlayer vp = trackedImage.GetComponentInChildren<VideoPlayer>();
        if (vp != null && vp.isPlaying)
        {
            vp.Pause();
            vp.gameObject.SetActive(false);
        }
    }
}