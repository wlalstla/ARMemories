using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject guidePopup;
    public GameObject scanGuideText;

    public void OnClickOK()
    {
        if (guidePopup != null)
            guidePopup.SetActive(false);

        if (scanGuideText != null)
            scanGuideText.SetActive(true);
    }

    // 조건식 다 걷어내고 무조건 끄도록 단순화
    public void ForceHideScanText()
    {
        if (scanGuideText != null && scanGuideText.activeSelf)
        {
            scanGuideText.SetActive(false);
        }
    }

    public void ResetUI()
    {
        if (guidePopup != null) guidePopup.SetActive(true);
        if (scanGuideText != null) scanGuideText.SetActive(false);
    }
}