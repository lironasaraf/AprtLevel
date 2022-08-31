using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSampleCharacterControl : MonoBehaviour
{
    private enum ControlMode
    {
        /// <summary>
        /// Up moves the character forward, left and right turn the character gradually and down moves the character backwards
        /// </summary>
        Tank,
        /// <summary>
        /// Character freely moves in the chosen direction from the perspective of the camera
        /// </summary>
        Direct
    }

    [SerializeField] private float m_moveSpeed = 2;

    [SerializeField] private float m_jumpForce = 4;

    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    [SerializeField] private ControlMode m_controlMode = ControlMode.Direct;

    [SerializeField] private AudioManager audioManager;
    [SerializeField] private Image imageTutorial;

    private float m_currentV = 0;
    private float m_currentH = 0;

    private readonly float m_interpolation = 10;
    private readonly float m_walkScale = 1.5f;
    private readonly float m_backwardsWalkScale = 0.16f;
    private readonly float m_backwardRunScale = 0.66f;

    private bool m_wasGrounded;
    private Vector3 m_currentDirection = Vector3.zero;

    private float m_jumpTimeStamp = 0;
    private float m_minJumpInterval = 0.25f;
    private bool m_jumpInput = false;

    private bool m_isGrounded;
    [SerializeField] private GameObject hand;
    [SerializeField] private List<Collider> m_collisions = new List<Collider>();

    private float speedSkill = 1;
    //[SerializeField] private GameObject menu;

    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "pickup" && hand.transform.childCount == 0)
        {
            return;
        }
        ContactPoint[] contactPoints = collision.contacts;

       
        
            for (int i = 0; i < contactPoints.Length; i++)
            {
                if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
                {
                    if (!m_collisions.Contains(collision.collider))
                    {
                        m_collisions.Add(collision.collider);
                    }
                    m_isGrounded = true;
                }
            }
        
        
        /*
        if (hand.transform.childCount > 0 && m_collisions.Count > 0)
        {
            if(m_collisions[0].gameObject == hand.transform.GetChild(0).gameObject)
                m_collisions.Remove(m_collisions[0]);
        }
        */
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "pickup" && hand.transform.childCount == 0)
        {
            return;
        }
        ContactPoint[] contactPoints = collision.contacts;
        bool validSurfaceNormal = false;
        for (int i = 0; i < contactPoints.Length; i++)
        {
            if (Vector3.Dot(contactPoints[i].normal, Vector3.up) > 0.5f)
            {
                validSurfaceNormal = true; break;
            }
        }

        if (validSurfaceNormal)
        {
            m_isGrounded = true;
            if (!m_collisions.Contains(collision.collider))
            {
                m_collisions.Add(collision.collider);
            }
        }
        else
        {
            if (m_collisions.Contains(collision.collider))
            {
                m_collisions.Remove(collision.collider);
            }
            if (m_collisions.Count == 0) { m_isGrounded = false; }
        }
        //if (m_collisions.Count > 1) { m_collisions.Remove(m_collisions[0]); }
        /*
        if (hand.transform.childCount > 0 && m_collisions.Count > 0)
        {
            if (m_collisions[0].gameObject == hand.transform.GetChild(0).gameObject)
                m_collisions.Remove(m_collisions[0]);
        }
        */
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "pickup" && hand.transform.childCount == 0)
        {
            return;
        }
        if (m_collisions.Contains(collision.collider))
        {
            m_collisions.Remove(collision.collider);
        }
        if (m_collisions.Count == 0) { m_isGrounded = false; }
        //if (m_collisions.Count > 1) { m_collisions.Remove(m_collisions[0]); }
        /*
        if (hand.transform.childCount > 0 && m_collisions.Count>0)
        {
            if (m_collisions[0].gameObject == hand.transform.GetChild(0).gameObject)
                m_collisions.Remove(m_collisions[0]);
        }
        */

    }

    private void Update()
    {

        //menu = GameObject.Find("MenuGamePlay").gameObject;
        //if (Input.GetKeyDown(KeyCode.Escape))
      //  {
          //  menu.gameObject.SetActive(true);

       // }
        if (!m_jumpInput && Input.GetKey(KeyCode.Space))
        {
            //m_animator.SetBool("PickUp", false);
            m_jumpInput = true;
            //audioManager.jump();
        }


    }

    private void FixedUpdate()
    {
        m_animator.SetBool("Grounded", m_isGrounded);

        switch (m_controlMode)
        {
            

            case ControlMode.Tank:
                if (imageTutorial == null && !OptionsGamePlay.menuIsActive)
                    TankUpdate();
                else if(imageTutorial != null && !imageTutorial.IsActive() && !OptionsGamePlay.menuIsActive)
                    TankUpdate();
                else if (!OptionsGamePlay.menuIsActive)
                    TankUpdate();
                break;

            default:
                Debug.LogError("Unsupported state");
                break;
        }
        m_animator.SetBool("PickUp", false);
        m_wasGrounded = m_isGrounded;
        m_jumpInput = false;
    }

    private void TankUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        



        



        m_currentV = Mathf.Lerp(m_currentV, v, Time.deltaTime * m_interpolation);
        m_currentH = Mathf.Lerp(m_currentH, h, Time.deltaTime * m_interpolation);
        m_rigidBody.velocity = transform.forward * m_currentV * m_moveSpeed * + speedSkill + transform.right * m_currentH * m_moveSpeed + transform.up*m_rigidBody.velocity.y;
     
        m_animator.SetBool("PickUp", false);
      
            
        m_animator.SetFloat("MoveSpeed", (m_currentV+ Mathf.Abs(m_currentH))/2);
       
        
            
        JumpingAndLanding();
    }


    private void JumpingAndLanding()
    {
        bool jumpCooldownOver = (Time.time - m_jumpTimeStamp) >= m_minJumpInterval;

        if (jumpCooldownOver && m_isGrounded && m_jumpInput)
        {
            m_jumpTimeStamp = Time.time;
            m_rigidBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            audioManager.jump();
        }

        if (!m_wasGrounded && m_isGrounded)
        {
            m_animator.SetTrigger("Land");
        }

        if (m_wasGrounded)
        {
            m_animator.SetTrigger("Jump");
        }
    }

    public void increaseSpeedSkill(float speedSkill)
    {
        this.speedSkill = speedSkill;
    }
}
