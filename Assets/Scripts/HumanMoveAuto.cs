using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMoveAuto : MonoBehaviour
{
    [SerializeField] private GameObject human;
    [SerializeField] private Transform[] ListPointMove;
    [SerializeField] private float speedRun = 10;
    private float timeSleep;
    private bool isMove;
    private Vector3 target;
    private int index;
    private float timeIma;
    private void Start() {
        timeSleep = 0.0f;
        index = 0;
        target = ListPointMove[index].position;
        isMove = true;
        InvokeRepeating(nameof(randomTimeSleep),10.0f,20.0f);
        timeIma = 0;
    }
    private void Update() {
        timeIma += Time.fixedDeltaTime/10;
        if(timeIma >= timeSleep){
            isMove = false;
            Invoke(nameof(resetMove),timeSleep);
            timeIma = 0;
        }
        if(isMove){
            MoveHoyNao();
        }
    }
    private void resetMove(){
        isMove = true;
    }
    private void MoveHoyNao(){
        if(human.transform.position ==target){
            index++;
            if(index>=ListPointMove.Length){
                index = 0;
            }
            target = ListPointMove[index].position;
        }
        human.transform.position = Vector3.MoveTowards(human.transform.position,target,speedRun * Time.fixedDeltaTime);
    }
    private void randomTimeSleep(){
        timeSleep = Random.Range(2.0f,5.0f);
    }
}
