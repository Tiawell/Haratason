using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardResourceText : MonoBehaviour, IOnResourceChange
{
    public Resource _resource;
    private TextMeshProUGUI _text;
    private ResourceContainer _container;

    private void Awake()
    {
        EventBus.AddListener<IOnResourceChange>(this);
    }
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        if (transform.parent.TryGetComponent(out ResourceContainer container))
        {
            _container = container;
            if (_container.TryGetValues(_resource, out int value, out int maxValue))
            {
                _text.text = maxValue.ToString();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void OnResourceChange(IOnResourceChange.Context context)
    {
        if(context._resource == _resource)
        {
            _text.text = context._value.ToString();
        }
    }
}
