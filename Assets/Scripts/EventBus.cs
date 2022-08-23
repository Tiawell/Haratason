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
    //словарь который держит всех подписавшихся на какой-либо эвент
    public static void AddListener<TListener>(TListener listener) where TListener : class
    { //TListener должен быть классом а не struct, иначе он плохо конвертится в object
        var type = typeof(TListener);
        //если нету такого типа подписчиков, создай
        if (!_listeners.TryGetValue(type, out EventListeners listeners))
        {
            listeners = new EventListeners();
            _listeners.Add(type, listeners);
        }
        listeners._listeners.Add(listener);
    }
    //methodGetter это функция которая находит функцию которая реагирует на эвент. Угу.
    public static void Invoke<TListener, TArgument>(Func<TListener, Action<TArgument>> methodGetter, TArgument arg) where TListener : class
    {
        //если есть хоть один подписавшийся
        if (_listeners.TryGetValue(typeof(TListener), out EventListeners listeners))
        {
            //для каждого подписавшегося
            foreach (var obj in listeners._listeners)
            {
                //достать метод
                var method = methodGetter(obj as TListener);
                //вызвать метод
                method.Invoke(arg);
            }
        }
    }
}
