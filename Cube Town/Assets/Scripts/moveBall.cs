using UnityEngine;
using System.Collections;

public class moveBall : MonoBehaviour {
    
    Vector3 pos;
    float spawned;
    float halfIntervall;
    public float intervall = 2;
    public float offset = 0;
    public int distX = 8;
    public int distY = 0;
    public int distZ = 0;
    
    // Use this for initialization
    void Start () {
        halfIntervall = intervall / 2;
        pos = transform.position;
        spawned = Time.realtimeSinceStartup - offset*intervall;
    }
    
    // Update is called once per frame
    void Update () {
        float time = Time.realtimeSinceStartup-spawned;
        time %= halfIntervall*2;
        if (time > halfIntervall)
        {
            time = 2*halfIntervall - time;
        }
        time /= halfIntervall;
        
        transform.position = new Vector3(pos.x + distX*time, pos.y + distY *time, pos.z + distZ *time);
    }
}
