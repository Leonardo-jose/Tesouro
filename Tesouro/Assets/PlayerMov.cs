using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
   [Header("Mov")] 
   public float movSpeed;

   public Transform orientation;

   float horInput;
   float verInput;

   Vector3 movDir;

   Rigidbody rb;

   private void Start()
   {
      rb = GetComponent<Rigidbody>();
      rb.freezeRotation = true;
   }

   private void Update()
   {
      MyInput();
   }

   private void FixedUpdate()
   {
      MovePlayer();
   }
   private void MyInput()
   {
      horInput = Input.GetAxisRaw("Horizontal");
      verInput = Input.GetAxisRaw("Vertical");
   }
   
   private void MovePlayer()
   {
      movDir = orientation.forward * verInput + orientation.right * horInput;

      rb.AddForce(movDir.normalized * movSpeed * 10f, ForceMode.Force);
   }
}
