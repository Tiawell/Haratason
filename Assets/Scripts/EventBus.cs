using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventBus
{
    private class EventListeners
    {
        public List<object> _listeners = new();
    }

    private static readonly Dictionary<Type, EventListeners> _listeners = new();
    //������� ������� ������ ���� ������������� �� �����-���� �����
    public static void AddListener<TListener>(TListener listener) where TListener : class
    { //TListener ������ ���� ������� � �� struct, ����� �� ����� ����������� � object
        var type = typeof(TListener);
        //���� ���� ������ ���� �����������, ������
        if (!_listeners.TryGetValue(type, out EventListeners listeners))
        {
            listeners = new EventListeners();
            _listeners.Add(type, listeners);
        }
        listeners._listeners.Add(listener);
    }
    //methodGetter ��� ������� ������� ������� ������� ������� ��������� �� �����. ���.
    public static void Invoke<TListener, TArgument>(Func<TListener, Action<TArgument>> methodGetter, TArgument arg) where TListener : class
    {
        //���� ���� ���� ���� �������������
        if (_listeners.TryGetValue(typeof(TListener), out EventListeners listeners))
        {
            //��� ������� ��������������
            foreach (var obj in listeners._listeners)
            {
                //������� �����
                var method = methodGetter(obj as TListener);
                //������� �����
                method.Invoke(arg);
            }
        }
    }
}
