using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjictle : Projictle
{
    private Collider bu_collider;
    public GameObject hit_pari_perfad;
    private ParticleSystem particle;

    private void Start()
    {
        bu_collider = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log(other.name);
        if(other.CompareTag("Player") != true)
        {
            Debug.Log("triggerenter");
            Vector3 location = this.transform.position;
            Vector3 pos = other.ClosestPoint(location);
            GameObject hit_pari=GameObject.Instantiate(hit_pari_perfad,pos,transform.rotation);
            particle=hit_pari.GetComponent<ParticleSystem>();
            particle.Play();
            Destroy(hit_pari);
            Destroy(this.gameObject);
        }
    }
}
