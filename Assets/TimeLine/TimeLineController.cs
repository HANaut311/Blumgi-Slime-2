using UnityEngine;
using UnityEngine.Playables;

public class TimeLineController : MonoBehaviour
{
    [SerializeField] private PlayableDirector timeline; // Kéo và thả Timeline vào đây trong Inspector
    private bool isTimelineActive = false; // Điều kiện để kích hoạt Timeline

    private void Update()
    {
        if (isTimelineActive)
        {
            timeline.Play(); // Bắt đầu chạy Timeline khi điều kiện đúng
        }
        else
        {
            timeline.Stop(); // Dừng Timeline nếu điều kiện không đúng
        }
    }

    // Hàm này có thể được gọi từ ____script để kích hoạt hoặc tắt Timeline.
    public void SetTimelineActive(bool isActive)
    {
        isTimelineActive = isActive;
    }

    public void OnTimelineFinished()
    {
        // Tắt Timeline khi kết thúc.
        SetTimelineActive(false);
        GameController.instance.SwitchOnNextScreen();
    }
}