using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool IsBuildTower { set; get; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        OnColorReset();

        IsBuildTower = false;
    }

    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭을 감지
        if (Input.GetMouseButtonDown(0))
        {
            // 클릭된 위치의 collider를 검출
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                // 현재 타일이 선택되었을 때 바뀌는 색상
                //spriteRenderer.color = Color.blue;

                // 클릭 시 프리팹 소환
                Vector3 spawnPosition = transform.position; // 타일의 위치로 프리팹을 소환
                GameObject prefabToSpawn = Resources.Load<GameObject>("PanelBuildTower"); // Resources 폴더에 있는 프리팹 이름 설정
                Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            }
        }
    }
    public void OnSelectedTile()
    {

    }
     public void OnColorReset()
    {
        // 원래 TileWall의 색상
        //spriteRenderer.color = new Color(0, 0.69f, 0.31f);
    }
}
