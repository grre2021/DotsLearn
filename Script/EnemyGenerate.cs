using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


//��������������y ={_{}}^{}log^{a} ���ؿ�����x +(��ʼ����)
//���˵�ʵ����������������������������ΧҪ����ʵ������Զ���ͬʱӦ�ö�һ�����ޣ�����߿������ɶ��ٵ��ˡ���õ���19����20��ʱ�պû�����������

//����ͬʱ��8�����˾�������Ѷ�����

//�������ʽa��ȡֵӦ��Ϊy=log x+(8-4)����

//a==20^ (1/(8-4))= 2.11

public class EnemyGenerate : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float[] probabilitys;

    [SerializeField] private int maxSpownNumber=8;
    [SerializeField] private int minSpownNumber=4;
    [SerializeField] private int spownNubmerDownFloat=1;
    [SerializeField] private int spownNubmerUpFloat=1;
    int level = 20;
    [SerializeField]int currentLevel;
    int mBaseSpownCount;
    int SpownNumber;
    private void Start()
    {
        probabilitys=new float[3] {20,30,30};
        
        StartCoroutine(nameof(test));
        

    }
   

   
    private int GetSpownIndex()
    {
        int index=0;
        float total = 0;
        foreach(var p in probabilitys)
        {
           
            total += p;
        }        
            float value=Random.Range(0,total);
        while(value>=0)
        {
            value-=probabilitys[index];
            index++;
            if(index == mBaseSpownCount)
            {
                break;
            }
            
        }
        return index-1;
    }

    IEnumerator test()
    {
        while (true)
        {
            currentLevel++;
            float a = Mathf.Pow((float)maxSpownNumber, 1f / level);
            mBaseSpownCount = Mathf.Min(Mathf.FloorToInt(Mathf.Log(a, currentLevel)) + minSpownNumber, maxSpownNumber);
            SpownNumber = Random.Range(mBaseSpownCount - spownNubmerDownFloat, mBaseSpownCount + spownNubmerUpFloat);
            //Debug.Log("mbasespowncount"+(int)mBaseSpownCount);
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              Debug.Log(SpownNumber);

            int spownIndex = GetSpownIndex();
            Debug.Log("spownIndex"+spownIndex);
            yield return new WaitForSeconds(1f);
        }
    }
}
