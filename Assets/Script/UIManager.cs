using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject guidePopup;
    public GameObject scanGuideText;
    public GameObject resetButton;

    private void Start()
    {
        if (resetButton != null)
        {
            resetButton.SetActive(true);
        }

        ResetUI();
    }
    public void OnClickOK()
    {
        if (guidePopup != null)
            guidePopup.SetActive(false);

        if (scanGuideText != null)
            scanGuideText.SetActive(true);

    }

    public void ForceHideScanText()
    {
        if (scanGuideText != null && scanGuideText.activeSelf)
        {
            scanGuideText.SetActive(false);
        }
    }

    public void ResetUI()
    {
        // 1. 안내 팝업을 다시 켭니다.
        if (guidePopup != null)
            guidePopup.SetActive(true);

        // 2. 스캔 가이드 텍스트는 끕니다.
        if (scanGuideText != null)
            scanGuideText.SetActive(false);

        // 3. [핵심] 리셋 버튼을 끄던 코드를 지우고, 무조건 'true'로 유지합니다.
        if (resetButton != null)
        {
            resetButton.SetActive(true);
        }
    }
}