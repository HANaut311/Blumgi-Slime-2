using UnityEngine;

public class BackGroundChange : MonoBehaviour
{

    // Được gọi khi Timeline kết thúc.
    public void OnTimelineEnd()
    {
        // Tắt Player Clone.
        gameObject.SetActive(false);


    }
}
