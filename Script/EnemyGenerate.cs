using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


//（敌人数基数）y ={_{}}^{}log^{a} （关卡数）x +(初始基数)
//敌人的实际数量在这个基数上随机波动，范围要根据实际情况自定，同时应该定一个上限，即最高可以生成多少敌人。最好到达19或者20关时刚好基数到达上限

//假设同时打8个敌人就是最高难度上限

//上述表达式a的取值应该为y=log x+(8-4)，则

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
