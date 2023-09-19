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
        if(IsBuildTower == false)
        {
            // 마우스 왼쪽 버튼 클릭을 감지
            if (Input.GetMouseButtonDown(0))
            {
                // 클릭된 위치의 collider를 검출
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);
                Debug.Log(hitCollider);
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
