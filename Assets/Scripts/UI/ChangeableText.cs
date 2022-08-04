using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class ChangeableText : MonoBehaviour
{
    protected TextMeshProUGUI _changeableText;

    private string _initialText;

    protected virtual void Awake()
    {
        _changeableText = GetComponent<TextMeshProUGUI>();
        _initialText = _changeableText.text;
    }

    protected virtual void Start()
    {
        SubscribeOnTargetEvent();
    }

    protected abstract void SubscribeOnTargetEvent();

    protected void ChangeValue(string value)
    {
        _changeableText.text = _initialText + value;
    }
}
