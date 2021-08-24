using UnityEngine;
using UnityEngine.UI; // UI 관련 코드
using UnityEngine.Video;
using UnityEngine.SceneManagement;

using Photon.Pun;
// 필요한 UI에 즉시 접근하고 변경할 수 있도록 허용하는 UI 매니저
public class UIManager : MonoBehaviourPun
{
    // 싱글톤 접근용 프로퍼티
    public static UIManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<UIManager>();
            }

            return m_instance;
        }
    }

    private static UIManager m_instance; // 싱글톤이 할당될 변수

    [SerializeField]
    public Slider hpslider; //hp슬라이더 
    [SerializeField]
    public GameObject gameoverUI; // 게임 오버시 활성화할 UI 
    [SerializeField]
    public GameObject damagedUI; // 데미지시 활성화할 UI 
    [SerializeField]
    public GameObject BulletUI;

    public GameObject bulletImage1;
    public GameObject bulletImage2;
    public GameObject bulletImage3;
    public GameObject bulletImage4;
    public GameObject bulletImage5;

    public GameObject bearImage1;
    public GameObject bearImage2;
    public GameObject bearImage3;
    public GameObject bearImage4;
    public GameObject bearImage5;


    [SerializeField]
    public Text actionText;
    [SerializeField]
    public Text openText;

    public GameObject inventory;

    [SerializeField]
    public Image itemImage1; //아이템 1 이미지
    [SerializeField]
    public Image itemImage2; //아이템 2 이미지


    //옹졸이 ui
    public GameObject saveUI1;
    //움파룸파UI
    public GameObject saveUI2;
    //구미베어UI
    public GameObject saveUI3;
    //판다UI
    public GameObject saveUI4;
    //투머치톡어UI
    public GameObject saveUI5;

    public GameObject movie;
    public VideoPlayer daymovie;



    //public void judge(int num)
    //{
    //    if (allfriend <= 0)
    //    {

    //        if (PhotonNetwork.IsMasterClient&& num==1)
    //        {

    //        }
    //        else
    //        {



    //        }
    //    }

    //}





    //public void getScore(int num)
    //{
    //    scoreText.text = "Saved Friend: " + "<color=orange>" + num + "</color>";
    //}

    public void getScore(int num)
    {
        if (num == 0)
        {
            bearImage1.SetActive(false);
            bearImage2.SetActive(false);
            bearImage3.SetActive(false);
            bearImage4.SetActive(false);
            bearImage5.SetActive(false);
        }
        else if (num == 1)
        {
            bearImage1.SetActive(true);
            bearImage2.SetActive(false);
            bearImage3.SetActive(false);
            bearImage4.SetActive(false);
            bearImage5.SetActive(false);
        }
        else if (num == 2)
        {
            bearImage1.SetActive(true);
            bearImage2.SetActive(true);
            bearImage3.SetActive(false);
            bearImage4.SetActive(false);
            bearImage5.SetActive(false);
        }
        else if (num == 3)
        {
            bearImage1.SetActive(true);
            bearImage2.SetActive(true);
            bearImage3.SetActive(true);
            bearImage4.SetActive(false);
            bearImage5.SetActive(false);
        }
        else if (num == 4)
        {
            bearImage1.SetActive(true);
            bearImage2.SetActive(true);
            bearImage3.SetActive(true);
            bearImage4.SetActive(true);
            bearImage5.SetActive(false);
        }
        else if (num == 5)
        {
            bearImage1.SetActive(true);
            bearImage2.SetActive(true);
            bearImage3.SetActive(true);
            bearImage4.SetActive(true);
            bearImage5.SetActive(true);
        }

    }

    public void getitem(string name)
    {
        actionText.text = name + " 획득 " + "<color=yellow>" + "(E)" + "</color>";
    }
    public void openitem(string name)
    {
        openText.text = name + " 열기/닫기 " + "<color=yellow>" + "(Q)" + "</color>";

    }
    public void friendfind(string name)
    {
        openText.text = name + "와의 상호작용은 " + "<color=yellow>" + "(E)" + "</color>" + "Key";
    }

    public void onactiontxt()
    {
        actionText.gameObject.SetActive(true);
    }
    public void offactiontxt()
    {
        actionText.gameObject.SetActive(false);
    }
    public void onopentxt()
    {
        openText.gameObject.SetActive(true);
    }
    public void offopentxt()
    {
        openText.gameObject.SetActive(false);
    }

    public void offallUI()
    {
        //잔가지 치우기
        BulletUI.gameObject.SetActive(false);
        hpslider.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);


    }
    public void onallUI()
    {
        BulletUI.gameObject.SetActive(true);
        hpslider.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);

    }
    public void UpdateHPSlider(int hp)
    {
        hpslider.value = hp;
    }
    // 게임 오버 UI 활성화
    public void SetActiveGameoverUI(bool active)
    {
        gameoverUI.SetActive(active);

    }

    // 데미지 UI 활성화
    public void SetActiveDamagerUI(bool active)
    {
        damagedUI.SetActive(active);
    }


    //이미지 투명도 조절 (이미지 비어있을땐 투명하게 한다)
    public void SetColor(float _alpha, Image _image)
    {
        Color color = _image.color;
        color.a = _alpha;
        _image.color = color;
    }

    public void AddItem1(Item _item)
    {
        itemImage1.sprite = _item.itemImage;
        SetColor(1, itemImage1); //아이템 보여준다.
    }

    public void AddItem2(Item _item)
    {
        itemImage2.sprite = _item.itemImage;
        SetColor(1, itemImage2); //아이템 보여준다.
    }
    public void UseItem1()
    {
        itemImage1.sprite = null;
        SetColor(0, itemImage1);
    }

    public void MoveItem2()
    {
        itemImage2.sprite = null;
        SetColor(0, itemImage2);
    }




    public void OnsaveUI(int num)
    {
        if (num == 1)
        {
            saveUI1.SetActive(true);

        }
        if (num == 2)
        {
            saveUI2.SetActive(true);

        }
        if (num == 3)
        {
            //구미베ㅔ어
            saveUI3.SetActive(true);

        }
        if (num == 4)
        {//툼어치톡어
            saveUI4.SetActive(true);

        }
        if (num == 5)
        {
            // 판
            saveUI5.SetActive(true);
        }





    }

    public void OffSaveUI()
    {

        saveUI1.SetActive(false);


        saveUI2.SetActive(false);

        saveUI3.SetActive(false);

        saveUI4.SetActive(false);
        saveUI5.SetActive(false);





    }



    public void updateBullet(int sb)
    {

        if (sb == 5)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(true);
            bulletImage5.SetActive(true);
        }
        else if (sb == 4)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(true);
            bulletImage5.SetActive(false);
        }
        else if (sb == 3)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(true);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 2)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(true);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 1)
        {
            bulletImage1.SetActive(true);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }
        else if (sb == 0)
        {
            bulletImage1.SetActive(false);
            bulletImage2.SetActive(false);
            bulletImage3.SetActive(false);
            bulletImage4.SetActive(false);
            bulletImage5.SetActive(false);
        }

    }

    public void playMovie()
    {
        movie.gameObject.SetActive(true);
        daymovie.Play();

    }
    public void EndMovie()
    {
        movie.gameObject.SetActive(false);
    }



}