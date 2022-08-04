using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Wallet", fileName = "Wallet")]
public class Wallet : ScriptableObject
{
    [SerializeField] private int _balance;

    public int Balance { get => _balance; set => _balance = value; }
    public readonly UnityEvent OnBalanceChangedEvent = new UnityEvent();

    public void AddMoney(int value)
    {
        Balance += value;
        OnBalanceChangedEvent.Invoke();
    }
}
