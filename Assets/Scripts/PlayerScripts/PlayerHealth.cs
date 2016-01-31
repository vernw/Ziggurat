using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
  public GameObject respawnPoint;

  [SerializeField]
  private float _health = 100.0f;
  public float health
  {
    get { return _health; }
    set
    {
      _health = value;
      if (_health > 100.0f)
        _health = 100.0f;
      else if (_health <= 0.0f)
      {
        _health = 0.0f;
        onDead();
      }
    }
  }

  // How much damage per tick of damage
  [SerializeField]
  private float darknessDamage = 2.0f;

  // Damage tick in seconds
  [SerializeField]
  private float damageTick = 1.0f;

  // Light counter; repeats darkness damage when (lightCounter == 0)
  [SerializeField]
  private int _lightCounter = 0;
  public int lightCounter
  {
    get { return _lightCounter; }
    set
    {
      _lightCounter = value;
      if (_lightCounter <= 0)
      {
        _lightCounter = 0;
        // Prevent duplicate calling of damage function
        CancelInvoke("DarknessDamagePerSecond");
        InvokeRepeating("DarknessDamagePerSecond", damageTick, damageTick);
      }
      else if (_lightCounter > 0)
        CancelInvoke("DarknessDamagePerSecond");
    }
  }

  // Light count increases when entering light collider
  public void OnTriggerEnter (Collider col)
  {
    //Debug.Log("Collision Stay " + col.gameObject.tag);
    if (col.gameObject.tag == "Light" || col.gameObject.tag == "Fire")
      lightCounter++;
  }

  // Light count decreases on exiting light collider
  public void OnTriggerExit (Collider col)
  {
    if (col.gameObject.tag == "Light" || col.gameObject.tag == "Fire")
      lightCounter--;
  }

  public void DarknessDamagePerSecond()
  {
    // Add damage animations/overlays here
    // Subtracts damage from health total until (lightCounter > 0) via InvokeRepeat; will be cancelled automatically otherwise
    if (lightCounter <= 0)
    {
      health -= darknessDamage;
      Debug.Log("Health: " + health + ". Time: " + Time.timeSinceLevelLoad);
    }
  }

  public bool isLit()
  {
    if (lightCounter > 0)
      return true;
    else
      return false;
  }

  public void takeDamage(float damage) {
    health -= damage;
  }

  public void onDead() {
    health = 100.0f;
    Debug.Log("Dead");
    if (respawnPoint == null)
      respawnPoint = GameObject.FindWithTag("Respawn");
    if (respawnPoint != null)
      this.transform.position = respawnPoint.transform.position;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
