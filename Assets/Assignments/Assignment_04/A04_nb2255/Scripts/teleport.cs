using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

    public ParticleSystem effect;
    public float maxActivationDistance = 10f;
    private ParticleSystem party;
    bool playing = false;

	// Use this for initialization
	void Start () {
        party = Instantiate(effect, this.transform);
        party.Stop();
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ptr = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ptr, out hit))
        {
            if (hit.distance <= maxActivationDistance)
            {
                Debug.Log("hit a something within distance!");
                party.transform.position = hit.point;
                if (!playing)
                {
                    playing = true;
                    party.Play();
                }
                if ( Input.GetMouseButtonDown(0) )
                {
                    transform.position = hit.point + Vector3.up * 1.3f;
                }
            }
            else
            {
                if (playing)
                {
                    playing = false;
                    party.Stop();
                }
            }
        }
        else
        {
            if (playing)
            {
                playing = false;
                party.Stop();
            }
        }
    }
}
