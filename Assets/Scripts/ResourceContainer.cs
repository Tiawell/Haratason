using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceContainer : MonoBehaviour
{
    [Serializable]
    private class StartingValue
    {
        public Resource _resource;
        public int _value;
        public int _maxValue;
    }
    private class Value
    {
        public int _value;
        public int _maxValue;
        public Value(int value, int maxValiue)
        {
            _value = value;
            _maxValue = maxValiue;
        }
    }
    public struct Context
    {
        public Resource _resource;
        public int _currentValue, _maxValue, _deltaValue;
        public Context(Resource resource, int value, int max, int delta)
        {
            _resource = resource;
            _currentValue = value;
            _maxValue = max;
            _deltaValue = delta;
        }
    }
    [SerializeField]
    private StartingValue[] _startingValues;
    private readonly Dictionary<Resource, Value> _values = new();
    private void Awake()
    {
        foreach (var v in _startingValues)
            _values.Add(v._resource, new Value(v._value, v._maxValue));
    }
    public void ToStartingValues(Resource resource)
    {
        foreach(var result in _startingValues)
            if(result._resource == resource)
            {
                if(_values.TryGetValue(resource, out var v))
                {
                    v._value = result._value;
                    v._maxValue = result._maxValue;
                    SetContextAndInvoke(resource, v._value, v._maxValue, 0);
                }
            }
    }
    public void Add(Resource resource, int value)
    {
        if (_values.TryGetValue(resource, out var v))
        {
            var newValue = Mathf.Clamp(v._value + value, 0, v._maxValue);
            var delta = newValue - v._value;
            if (delta != 0)
            {
                v._value = newValue;
                SetContextAndInvoke(resource, newValue, v._maxValue, delta);
                //IOnResourceChange.Context context = new(resource, newValue, v._maxValue, delta);
                //EventBus.Invoke<IOnResourceChange, IOnResourceChange.Context>(l => l.OnResourceChange, context);
            }
        }
    }
    public void Increase()
    {

    }
    private void SetContextAndInvoke(Resource resource, int value, int maxValue, int delta)
    {
        IOnResourceChange.Context context = new(resource, value, maxValue, delta);
        EventBus.Invoke<IOnResourceChange, IOnResourceChange.Context>(l => l.OnResourceChange, context);
    }
    public bool TryGetValues(Resource resource, out int currentValue, out int maxValue)
    {
        if (_values.TryGetValue(resource, out var v))
        {
            currentValue = v._value;
            maxValue = v._maxValue;
            return true;
        }
        else
        {
            currentValue = maxValue = 0;
            return false;
        }
    }
}
