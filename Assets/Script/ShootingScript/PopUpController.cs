//ポップアップ処理のプログラムです。
/**
        モーダルウィンドウとポップアップの違いは、こちら(https://goworkship.com/magazine/modal-windows-mobileui/)を参考にして作成しました。
                                        -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
            モーダル：表示されたタスクが完了するまで、ユーザーは他の作業を行えない。ユーザーは表示内容に従うか、モーダルウィンドウを閉じなければならない。
            ポップアップ：ポップアップウィンドウが表示されても、作業中の画面の操作を続行できる。
                                        -*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
**/
using UnityEngine;
using DG.Tweening;

public class PopUpController : MonoBehaviour
{
    [SerializeField] private RectTransform _window;
    [SerializeField] private GameObject _closeButton;
    [SerializeField] private Vector3 _maxScale;
    [SerializeField] private float _scaleExecutionTime;
    
    //「ポップアップを出したい時にこのメソッドを実行すると、ポップアップが表示される」という使い方を想定しています。
    public void PopUp()
    {
        _window.DOScale (
            _maxScale,
            _scaleExecutionTime
            );
    }
}