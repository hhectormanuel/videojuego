using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Items : MonoBehaviour
{


    public TMP_Text PotT;

    public TMP_Text PotC;

    private int totalpot;



    private void Start() 
    {
        totalpot = transform.childCount;
    }




    private void Update()
    {
        PotT.text = totalpot.ToString();
        PotC.text = (totalpot-transform.childCount).ToString();

    }





}