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
        //スライダーの値を音量に設定
        _audioSource = this.GetComponent<AudioSource>();
        _volume = this.GetComponent<Slider>().normalizedValue;
    }

    void Update()
    {
        //スライダーで音量を変更
        _audioSource.volume = this.GetComponent<Slider>().normalizedValue;
    }
}