//このプログラムはスライダーにアタッチして使用してください。
using UnityEngine;
using UnityEngine.UI;

//AudioSourceコンポーネントを自動的に追加
[RequireComponent(typeof(AudioSource))]
public class SoundController : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        ChangeVolume();
    }
    private void ChangeVolume()
    {
        //スライダーの値を音量に設定
        _audioSource.volume = this.GetComponent<Slider>().normalizedValue;
    }
}