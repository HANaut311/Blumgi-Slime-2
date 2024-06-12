using UnityEngine;

public class TextChange : MonoBehaviour
{

    // Được gọi khi Timeline kết thúc.
    public void OnTimelineEnd()
    {
        // Tắt Player Clone.
        gameObject.SetActive(false);


    }
}
