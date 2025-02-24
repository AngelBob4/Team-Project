using System.Collections.Generic;
using UnityEngine;

public class DataList<T>
{
    private List<T> _list;

    public DataList(List<T> values)
    {
        _list = values;
    }

    public T GetRandomValue()
    {
        return _list[Random.Range(0, _list.Count)];
    }
}
