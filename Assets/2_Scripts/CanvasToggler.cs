using UnityEngine;

/// <summary>
/// I키를 누르면 특정 캔버스를 켜고 끄는 스크립트
/// </summary>
public class CanvasToggler : MonoBehaviour
{
    [Header("Canvas Settings")]
    [Tooltip("토글할 캔버스 (인스펙터에서 할당)")]
    public Canvas targetCanvas;
    
    [Header("Input Settings")]
    [Tooltip("캔버스를 토글할 키 (기본값: I)")]
    public KeyCode toggleKey = KeyCode.I;
    
    [Header("Options")]
    [Tooltip("시작 시 캔버스를 비활성화할지 여부")]
    public bool startDisabled = true;
    
    void Start()
    {
        // 캔버스가 할당되지 않았으면 자동으로 찾기 시도
        if (targetCanvas == null)
        {
            targetCanvas = GetComponent<Canvas>();
            if (targetCanvas == null)
            {
                Debug.LogWarning($"[CanvasToggler] {gameObject.name}: Canvas가 할당되지 않았습니다. 인스펙터에서 할당해주세요.");
            }
        }
        
        // 시작 시 캔버스 상태 설정
        if (targetCanvas != null && startDisabled)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        // I키 입력 감지
        if (Input.GetKeyDown(toggleKey))
        {
            ToggleCanvas();
        }
    }
    
    /// <summary>
    /// 캔버스를 토글합니다 (켜져있으면 끄고, 꺼져있으면 켭니다)
    /// </summary>
    public void ToggleCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(!targetCanvas.gameObject.activeSelf);
        }
        else
        {
            Debug.LogWarning($"[CanvasToggler] {gameObject.name}: Canvas가 할당되지 않았습니다.");
        }
    }
    
    /// <summary>
    /// 캔버스를 켭니다
    /// </summary>
    public void ShowCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(true);
        }
    }
    
    /// <summary>
    /// 캔버스를 끕니다
    /// </summary>
    public void HideCanvas()
    {
        if (targetCanvas != null)
        {
            targetCanvas.gameObject.SetActive(false);
        }
    }
}

