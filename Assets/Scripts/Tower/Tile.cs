using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public GameObject PanelBuildTower; // 활성화할 프리팹
    private Vector3 originalPosition; // 타일의 원래 위치
    private GameObject activeTower; // 활성화된 타워
    public Button tileButton; // UI 버튼

    // 타일에 타워가 건설되어 있는지 검사하는 변수
    public bool IsBuildTower { set; get; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //OnColorReset();

        IsBuildTower = false;
        originalPosition = transform.position;
        // 버튼 클릭 이벤트에 함수 연결
        tileButton.onClick.AddListener(OnTileButtonClick);
    }
	public void OnSelectedTile()
	{
		// 현재 타일이 선택되었을 때 바뀌는 색상
		//spriteRenderer.color = Color.blue;
	}

	public void OnColorReset()
	{
		// 원래 TileWall의 색상
		//spriteRenderer.color = new Color(0, 0.69f, 0.31f);
	}

    

    // UI 버튼 클릭 시 호출되는 함수
    private void OnTileButtonClick()
    {
        // 타일이 선택되었을 때 프리팹 활성화
        if (!IsBuildTower && PanelBuildTower != null)
        {
            // 프리팹을 활성화하고 위치를 변경합니다.
            if (activeTower != null)
            {
                Destroy(activeTower);
            }

            activeTower = Instantiate(PanelBuildTower, originalPosition, Quaternion.identity);
            // 여기에서 새로 생성된 타워의 위치와 로직을 설정할 수 있습니다.
        }
        spriteRenderer.color = Color.blue;
    }

}
