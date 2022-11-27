using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{

private float checkpointPositionX, checkpointPositionY;

public GameObject[] hearts;
private int life;
public Animator animator;


    void Start()
    {
        life= hearts.Length;

        // if (PlayerPrefs.GetFloat("checkpointPositionX")!=0)
        // {
        //     transform.position=(new Vector2(PlayerPrefs.GetFloat("checkpointPositionX"),PlayerPrefs.GetFloat("checkpointPositionY")));
        // }
    }
    public void ReachedCheckPoint(float x, float y){
        PlayerPrefs.SetFloat("checkpointPositionX",x);
        PlayerPrefs.SetFloat("checkpointPositionY",y);
    }
 private void CheckLife(){
if (life<1)
{
    Destroy(hearts[0].gameObject);
     animator.Play("Hurt");
     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
else if(life <2)
{
    Destroy(hearts[1].gameObject);
     animator.Play("Hurt");
}
else if(life <3)
{
    Destroy(hearts[2].gameObject);
     animator.Play("Hurt");
}
} 

public void PlayerDamaged()
{
    life --;
    CheckLife(); 
     }
}

