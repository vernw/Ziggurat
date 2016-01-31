using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
  public GameObject respawnPoint;
  public const float MAX_HEALTH = 100.0f;

  [SerializeField]
  private float _health = MAX_HEALTH;
  public float health
  {
    get { return _health; }
    set {
      _health = value;

      if (_health > MAX_HEALTH)
        _health = MAX_HEALTH;
      else if (_health <= 0.0f)
      {
        _health = 0.0f;
        onDead();
      }

      updateHealthBar();
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

  public bool isLit() {
    return lightCounter > 0;
  }

  public void takeDamage(float damage) {
    health -= damage;
  }

  public void updateHealthBar() {
    GameObject healthBar = GameObject.FindWithTag("HP");
    GameObject maxHealthBar = GameObject.FindWithTag("MaxHP");

    RectTransform healthBarRectTransform = healthBar.GetComponent<RectTransform>();
    RectTransform maxHealthBarRectTransform = maxHealthBar.GetComponent<RectTransform>();

    Rect maxHealthBarRect = maxHealthBarRectTransform.rect;

    healthBarRectTransform.sizeDelta = new Vector2(maxHealthBarRect.width, maxHealthBarRect.height * (health / MAX_HEALTH));
  }

  public void onDead() {
    health = MAX_HEALTH;
    Debug.Log("Dead");
    if (respawnPoint == null)
      respawnPoint = GameObject.FindWithTag("Respawn");
    if (respawnPoint != null)
      this.transform.position = respawnPoint.transform.position;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}
