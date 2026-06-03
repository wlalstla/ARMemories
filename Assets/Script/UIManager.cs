using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject guidePopup;
    public GameObject scanGuideText;
    public GameObject resetButton;

    public void OnClickOK()
    {
        if (guidePopup != null)
            guidePopup.SetActive(false);

        if (scanGuideText != null)
            scanGuideText.SetActive(true);

        if (resetButton != null)
            resetButton.SetActive(false);

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
        if (guidePopup != null) guidePopup.SetActive(true);
        if (scanGuideText != null) scanGuideText.SetActive(false);
        if (resetButton != null) resetButton.SetActive(true);
    }
}