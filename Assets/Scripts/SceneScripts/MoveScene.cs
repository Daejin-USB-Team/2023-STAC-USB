using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    /*
    인트로(화면 터치 시 이동) ⇒ 캐릭터 선택(캐릭터 누르고 시작버튼 눌러서 이동)

    ⇒ 진영 선택(아무 진영 이미지 눌러서 이동)

    ⇒ 스테이지 선택(스테이지 이미지 누르면 이동) ⇒ 코딩 화면(시작 버튼 누르면 이동) ⇒인 게임 

    ⇒ 승리 and 패배 창(확인 버튼 누르면 이동)

    ⇒ 스테이지 선택
    */

    //이동할 맵 이름
    public string transferMapName;
    //버튼을 클릭시 씬 이동
    public void ButtonClicked()
    {
        SceneManager.LoadScene(transferMapName);
    }
}
