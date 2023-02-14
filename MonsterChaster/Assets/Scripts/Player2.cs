using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    [SerializeField]
    private LayerMask jumpAbleGround;

    private float MoveX;
    private BoxCollider2D coll;
    private SpriteRenderer sr;
    private Rigidbody2D myBody;
    private Animator anim;
    private string WALK_ANI = "Walk";
    private bool isGround =false;
    private string GROUND = "Ground";
    private string ENEMY_TAG = "Enemy";

    // Start is called before the first frame update

    void Start()
    {
        myBody= GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sr=GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveKeybroad();
        AnimatedPlayer();
        PlayerJump();

    }

    

    void MoveKeybroad()
    {
        //hàm getaxis trả về giá trị âm hoặc dương dựa theo tên đối tượng,
        //ở đây horizontal là chiều ngang nên nó sẽ trả về trái là -1 hoặc phải là 1
        MoveX = Input.GetAxisRaw("Horizontal");
        //Thay đổi vị trí (di chuyển nhân vật) bằng lấy vị trí hiện tại + với vị trí mới, trong đó ví trí mới được tính trái hoặc phải
        //như đã chỉ định ở trên * với moveX là tốc độ di chuyển * time.deltatime là di chuyển dựa trên frame-khung hình, nếu không
        //nhân vật sẽ thành the flash.
        transform.position += new Vector3(MoveX, 0f, 0f) * Time.deltaTime * moveSpeed;
    }

    void AnimatedPlayer()
    {
        if (MoveX < 0)
        {
            //Sang trái
            anim.SetBool(WALK_ANI, true);
            sr.flipX = true;
        }
        else if (MoveX > 0)
        {
            //Sang phải
            anim.SetBool(WALK_ANI, true);
            sr.flipX = false;
            //đặt sang phải là false vì đúng hướng mặc định của nhân vật nên k cần lật
        }
        else
        {
            //Đứng yên
            anim.SetBool(WALK_ANI, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.J) && isGround)
        {

            //mybody.velocity = new Vector2(mybody.velocity.x, jumpHeight);
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
