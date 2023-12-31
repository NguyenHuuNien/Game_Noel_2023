using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerCheck : MonoBehaviour
{
    [SerializeField] private int numGiftBedInScene;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject PlayCanvas;
    [SerializeField] private SantaMove player;
    public static int numGiftBed;
    // Start is called before the first frame update
    void Start()
    {
        winCanvas.SetActive(false);
        numGiftBed = 0;
    }
    private void Update() {
        if(transform.position.y < -8.5f && numGiftBed == numGiftBedInScene){
            winCanvas.SetActive(true);
            PlayCanvas.SetActive(false);
            SantaMove.move = false;
            player.offGhost();
        }
    }
    public void incNumGiftBed(){
        numGiftBed++;
    }
}
