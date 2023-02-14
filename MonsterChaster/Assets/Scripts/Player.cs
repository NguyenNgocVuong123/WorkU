using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //Để public để có thể truy cập và chỉnh sửa từ inspector trong unity
    //public float MoveSpeed = 10f;
    //public float JumpHeight = 5f;

    //Còn nếu muốn giữ các biến ở riêng tư nhưng vẫn chỉnh sửa được thì dùng[SerializeField] 
    [SerializeField]
    private float MoveSpeed = 10f;
    [SerializeField]
    private float jumpHeight = 11f;
    [SerializeField]
    private LayerMask jumpAbleGround;
    //khai báo các compo cần dùng
    private float MoveX;
    private BoxCollider2D coll;
    private SpriteRenderer sr;
    private Rigidbody2D mybody;
    private Animator anim;
    //Giá trị đặt tên phải trùng với clip trong animation
    private string WALK_ANI = "Walk2";
    private string GROUND_TAG = "Ground";
    private bool IsGround = false;
    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        //Lấy và gắn các compo từ inspector vào các biến
        mybody=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        PJump();
        MoveKeybroad();
        AnimatedPlayer();
    }

    
    void MoveKeybroad()
    {
        //hàm getaxis trả về giá trị âm hoặc dương dựa theo tên đối tượng,
        //ở đây horizontal là chiều ngang nên nó sẽ trả về trái là -1 hoặc phải là 1
        MoveX = Input.GetAxisRaw("Horizontal");
        //Thay đổi vị trí (di chuyển nhân vật) bằng lấy vị trí hiện tại + với vị trí mới, trong đó ví trí mới được tính trái hoặc phải
        //như đã chỉ định ở trên * với moveX là tốc độ di chuyển * time.deltatime là di chuyển dựa trên frame-khung hình, nếu không
        //nhân vật sẽ thành the flash.
        transform.position += new Vector3(MoveX, 0f, 0f) * Time.deltaTime * MoveSpeed;
        //mybody.velocity = new Vector2(MoveX * MoveSpeed, mybody.velocity.y);
    }

    void AnimatedPlayer()
    {
        if (MoveX < 0)
        {
            //Sang trái
            anim.SetBool(WALK_ANI, true);
            sr.flipX= true;
        }else if(MoveX > 0)
        {
            //Sang phải
            anim.SetBool(WALK_ANI, true);
            sr.flipX= false;
            //đặt sang phải là false vì đúng hướng mặc định của nhân vật nên k cần lật
        }else
        {
            //Đứng yên
            anim.SetBool(WALK_ANI, false);
        }
    }

    void PJump()
    {
        if (Input.GetKeyDown(KeyCode.J) && IsGround )
        {
            
            //mybody.velocity = new Vector2(mybody.velocity.x, jumpHeight);
            mybody.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
           
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGround = true;
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGround = false;

    }
}
