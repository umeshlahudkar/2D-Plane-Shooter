using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] Transform healthBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void setEnemyHealth( float damage)
   {
        if (healthBar.localScale.x >= 0)
        {
            healthBar.localScale = new Vector2((healthBar.localScale.x - damage), healthBar.localScale.y);
        }
       
   }
}
