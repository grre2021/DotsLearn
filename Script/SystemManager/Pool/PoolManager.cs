using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    
        [SerializeField] Pool[] PlayerProjectilePools;
        static Dictionary<GameObject, Pool> dictionary;
        private void Start()
        {
            dictionary = new Dictionary<GameObject, Pool>();//注册字典
            Initialize(PlayerProjectilePools);
        }
        /// <summary>
        /// 初始化整个对象池,并使对象池中的对象为此Gameobject的子对象
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
        /// 负责取出对象，并编写对个重载
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
