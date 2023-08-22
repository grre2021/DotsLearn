using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    
        [SerializeField] Pool[] PlayerProjectilePools;
        static Dictionary<GameObject, Pool> dictionary;
        private void Start()
        {
            dictionary = new Dictionary<GameObject, Pool>();//ע���ֵ�
            Initialize(PlayerProjectilePools);
        }
        /// <summary>
        /// ��ʼ�����������,��ʹ������еĶ���Ϊ��Gameobject���Ӷ���
        /// </summary>
        /// <param name="pools"></param>
        void Initialize(Pool[] pools)
        {
            foreach (var pool in pools)
            {
                if (dictionary.ContainsKey(pool.prefad))
                {
                    Debug.Log("wrong");
                    continue;
                }
                dictionary.Add(pool.prefad, pool);
                Transform PoolParent = new GameObject("Pool" + pool.prefad.name).transform;
                PoolParent.parent = transform;
                pool.Initialize(PoolParent);
            }
        }
        /// <summary>
        /// ����ȡ�����󣬲���д�Ը�����
        /// </summary>
        /// <param name="prefad"></param>
        /// <returns></returns>
        public static GameObject Release(GameObject prefad)
        {
            if (!dictionary.ContainsKey(prefad))
            {
                Debug.Log("wrong");
                return null;
            }
            return dictionary[prefad].PreparedObject();
        }

        public static GameObject Release(GameObject prefad, Vector3 position)
        {
            if (!dictionary.ContainsKey(prefad))
            {
                Debug.Log("wrong");
                return null;
            }
            return dictionary[prefad].PreparedObject(position);
        }

        public static GameObject Release(GameObject prefad, Vector3 position, Quaternion rotation)
        {
            if (!dictionary.ContainsKey(prefad))
            {
                Debug.Log("wrong");
                return null;
            }
            return dictionary[prefad].PreparedObject(position, rotation);
        }

        public static GameObject Release(GameObject prefad, Vector3 position, Quaternion rotation, Vector3 localscale)
        {
            if (!dictionary.ContainsKey(prefad))
            {
                Debug.Log("wrong");
                return null;
            }
            return dictionary[prefad].PreparedObject(position, rotation, localscale);
        }
    }
