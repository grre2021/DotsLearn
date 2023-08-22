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
    /// �˺��������ʼ��
    /// </summary>
    public void Initialize(Transform parent)
    {
        quene = new Queue<GameObject>();

        this.parent = parent;
        for (var i = 0; i < Size; i++)
        {
            quene.Enqueue(Copy());//����
        }
    }

    GameObject Copy()
    {
        var copy = GameObject.Instantiate(Prefad, parent);

        copy.SetActive(false);

        return copy;
    }

    /// <summary>
    /// �˺�������ȡ�����ö���,ͬʱ���𷵻س��ж���
    /// </summary>
    /// <returns></returns>
    GameObject AvialiableObject()
    {
        GameObject avialiableObject = null;

        //�����еĵ�һ��Ԫ��δ����ʱ���ܳ���
        if (quene.Count > 0 && quene.Peek().activeSelf)
        {
            avialiableObject = quene.Dequeue();//����
        }
        else
        {
            avialiableObject = Copy();
        }

        quene.Enqueue(avialiableObject);//����
        return avialiableObject;
    }

    /// <summary>
    /// ���ÿ��ö���,��Ϊ�˺���д�������
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
