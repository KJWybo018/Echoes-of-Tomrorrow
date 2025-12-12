using UnityEngine;

public class TimelineManager : MonoBehaviour
{
  public static TimelineManager Instance;

  public enum Timeline { A, B }
  public Timeline currentTimeline = Timeline.A;

  public delegate void TimelineShift(Timeline newTimeline);
  public static event TimelineShift OnTimelineShift;

  private void Awake()
  {
    if (Instance == null) Instance = this;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.T))
    {
      currentTimeline = currentTimeline == Timeline.A ? Timeline.B : Timeline.A;
      OnTimelineShift?.Invoke(currentTimeline);
    }
  }
}
