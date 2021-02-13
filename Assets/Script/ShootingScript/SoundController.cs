using UnityEngine;
using UnityEngine.UI;

//AudioSourceコンポーネントを自動的に追加
[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    //音量
    private float _volume;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        //スライダーの値を音量に設定
        _audioSource.volume = _volume;
    }
    public void ChangeVolume()
    {
        //スライダーの値を取得
        _volume = this.GetComponent<Slider>().normalizedValue;
    }
}