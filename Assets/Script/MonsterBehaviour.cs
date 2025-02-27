using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MonsterBehaviour : MonoBehaviour
{
    public BaseMonster monster; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float curr_cd = 0f;
    private float max_cd = 5f; 

    public enum State {
        dead, 
        current, 
        waiting, 
        selecting, 
        attacking
    }
    public State current; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (current == State.waiting){

        }
        else if (current == State.dead){

        }
        else if (current == State.selecting){

        }
        else if(current == State.attacking){

        }
    }
    
    void UpdateBar(){
        curr_cd = curr_cd + Time.deltaTime; 
        float calc_cd = curr_cd / max_cd; 
        // ProgressBar.transform.localscale = new Vector3 (Mathf.Clamp (calc_cd, 0, 1, ProgressBar.transform.localscale.y, ProgressBar.transform.localscale.z));
    }
}
