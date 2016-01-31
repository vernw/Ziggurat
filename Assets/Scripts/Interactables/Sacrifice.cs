using UnityEngine;
using System.Collections;

public class Sacrifice : Interactable {
  [SerializeField]
  private GameObject _altar;
  public GameObject altar
  {
    get { return _altar; }
    set { _altar = value; }
  }

  void Start() {
    // Keeps sacrifice floating until dropped onto altar
    GetComponent<Rigidbody>().useGravity = false;
  }

  private void dropToAltar() {
    // Warps to altar
    gameObject.transform.position = altar.transform.position + new Vector3(0, 2, 0);
    GetComponent<Rigidbody>().useGravity = true;
  }

  public override void onStartInteract() {
    dropToAltar();
  }
}
