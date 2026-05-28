using UnityEngine;

public class ImageRegister : MonoBehaviour
{
    public ARVideoManager arVideoManager;
    public Texture2D testTexture;

    public void RegisterNewImage()
    {
        if (testTexture != null)
        {
            if (arVideoManager != null)
            {
                // ARVideoManager의 OnClickAddImage 함수를 올바르게 호출합니다.
                arVideoManager.OnClickAddImage(testTexture);
            }
            else
            {
                Debug.LogError("ARVideoManager가 연결되지 않았습니다!");
            }
        }
        else
        {
            Debug.LogError("등록할 테스트 이미지가 없습니다!");
        }
    }
}