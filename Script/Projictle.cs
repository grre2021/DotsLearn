using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projictle : MonoBehaviour
{
    [SerializeField] public Vector3 shot_direction;
    [SerializeField] float shot_speed;

    private void OnEnable()
    {
        StartCoroutine(nameof(MoveDirectly));
    }

    IEnumerator MoveDirectly()
    {
        while(gameObject.activeSelf)
        {
            transform.Translate(shot_direction*shot_speed*Time.deltaTime);
            yield return null;
        }
    }
}
