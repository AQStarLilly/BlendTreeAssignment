using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public GameObject popupWindow;
    public GameObject backgroundOverlay;

    // Start is called before the first frame update
    void Start()
    {
        popupWindow.SetActive(true);
        backgroundOverlay.SetActive(true);

        backgroundOverlay.GetComponent<Button>().onClick.AddListener(HidePopup);
    }

    public void HidePopup()
    {
        popupWindow.SetActive(false);
        backgroundOverlay.SetActive(false);
    }
}
