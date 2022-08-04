using DG.Tweening;
using UnityEngine;

public class MoneyText : ChangeableText
{
    [SerializeField] private Wallet _wallet;

    protected override void SubscribeOnTargetEvent()
    {
        ChangeValue(_wallet.Balance.ToString());
        _wallet.OnBalanceChangedEvent.AddListener(() =>
        {
            ChangeValue(_wallet.Balance.ToString());
            _changeableText.transform.DOShakePosition(1f);
        });
    }
}
