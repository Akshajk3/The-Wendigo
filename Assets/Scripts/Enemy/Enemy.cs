using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dead()
    {
        this.gameObject.SetActive(false);
    }

    public void SaveEnemy()
    {
        SaveSystem.SaveEnemy(this);
    }

    public void LoadEnemy()
    {
        EnemyData data = SaveSystem.LoadEnemy();

        if(data.dead)
        {
            Dead();
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
