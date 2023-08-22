using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool 
{
    public GameObject prefad { get { return Prefad; } }

    [SerializeField] GameObject Prefad;
    [SerializeField] int Size;
    Queue<GameObject> quene;

    Transform parent;

    /// <summary>
    /// 此函数负责初始化
    /// </summary>
    public void Initialize(Transform parent)
    {
        quene = new Queue<GameObject>();

        this.parent = parent;
        for (var i = 0; i < Size; i++)
        {
            quene.Enqueue(Copy());//入列
        }
    }

    GameObject Copy()
    {
        var copy = GameObject.Instantiate(Prefad, parent);

        copy.SetActive(false);

        return copy;
    }

    /// <summary>
    /// 此函数负责取出可用对象,同时负责返回出列对象
    /// </summary>
    /// <returns></returns>
    GameObject AvialiableObject()
    {
        GameObject avialiableObject = null;

        //队列中的第一个元素未启用时才能出列
        if (quene.Count > 0 && quene.Peek().activeSelf)
        {
            avialiableObject = quene.Dequeue();//出列
        }
        else
        {
            avialiableObject = Copy();
        }

        quene.Enqueue(avialiableObject);//入列
        return avialiableObject;
    }

    /// <summary>
    /// 启用可用对象,并为此函数写多个重载
    /// </summary>
    /// <returns></returns>
    public GameObject PreparedObject()
    {
        GameObject preparedObject = AvialiableObject();
        preparedObject.SetActive(true);

        return preparedObject;
    }
    public GameObject PreparedObject(Vector3 position)
    {
        GameObject preparedObject = AvialiableObject();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;


        return preparedObject;
    }

    public GameObject PreparedObject(Vector3 position, Quaternion rotation)
    {
        GameObject preparedObject = AvialiableObject();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;


        return preparedObject;
    }

    public GameObject PreparedObject(Vector3 position, Quaternion rotation, Vector3 localscale)
    {
        GameObject preparedObject = AvialiableObject();

        preparedObject.SetActive(true);
        preparedObject.transform.position = position;
        preparedObject.transform.rotation = rotation;
        preparedObject.transform.localScale = localscale;

        return preparedObject;
    }
}
