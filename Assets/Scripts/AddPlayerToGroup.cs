using Cinemachine;
using TMPro;
using UnityEngine;

public class AddPlayerToGroup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clock;
    
    private void Awake()
    {
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        PlayerController controller = player.GetComponent<PlayerController>();
        CinemachineTargetGroup group = GetComponent<CinemachineTargetGroup>();
     
        // change controller camera ref, timer text ref add player to target group
        DimensionTimer.Instance.ClockText = clock;
        controller.Camera = Camera.main;
        group.AddMember(playerTransform, 1.0f, 5.4f);
    }
}
