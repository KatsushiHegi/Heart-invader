using UnityEngine;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// 対象のオブジェクトを追跡するカメラ
/// </summary>
public class TrackingCameraRx : MonoBehaviour
{
    public GameObject _targetObj;   // 対象オブジェクト
    public Vector3 _offsetPos;  // 位置補正
    [Tooltip("カメラとオブジェクトの距離"),SerializeField] private float _distance = -4.0f;
    [Tooltip("Y軸の回転"),SerializeField] private float _polarAngle = 1.0f;
    [Tooltip("X軸の回転"),SerializeField] private float _azimuthalAngle = 180.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Select(cameraPos => _targetObj.transform.position + _offsetPos)
            .Subscribe(lookAtPos=>
            {
                UpdatePosition(lookAtPos);
                transform.LookAt(lookAtPos);
            }
        );
    }

    /// <summary>
    /// 指定のカメラアングルでオブジェクトを追跡するためのポジションを計算する関数
    /// </summary>
    /// <param name="lookAtPos"></param>
    private void UpdatePosition(Vector3 lookAtPos)
    {
        var degAzi = _azimuthalAngle * Mathf.Deg2Rad;
        var degPol = _polarAngle * Mathf.Deg2Rad;
        transform.position = new Vector3(
            lookAtPos.x + _distance * Mathf.Sin(degPol) * Mathf.Cos(degAzi),
            lookAtPos.y + _distance * Mathf.Cos(degPol),
            lookAtPos.z + _distance * Mathf.Sin(degPol) * Mathf.Cos(degAzi));
    }
}
