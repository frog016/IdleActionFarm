using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Seller : MonoBehaviour
{
    [SerializeField] private int _wheatBlockCost;
    [SerializeField] private float _flyDuration;
    [SerializeField] private float _delay;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _moneyPrefab;
    [SerializeField] private Canvas _canvas;

    public void ReceiveMoniesInPosition(Vector3 worldPosition)
    {
        var position = FindObjectOfType<Camera>().WorldToScreenPoint(worldPosition);
        StartCoroutine(MoveCoins(position));
    }

    private IEnumerator MoveCoins(Vector3 position)
    {
        var endPosition = _canvas.GetComponentInChildren<MoneyText>().GetComponent<RectTransform>().position;
        for (var i = 0; i < _wheatBlockCost; i++)
        {
            var coin = Instantiate(_moneyPrefab, position, Quaternion.identity, _canvas.transform);
            var tweener = coin.GetComponent<RectTransform>().DOMove(endPosition, _flyDuration);
            tweener
                .OnComplete(() =>
                {
                    _wallet.AddMoney(1);
                    Destroy(coin);
                    tweener.Kill();
                });
            yield return new WaitForSeconds(_delay);
        }
    }
}
