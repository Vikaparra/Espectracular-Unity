using UnityEngine;
public class TrashGenerator : MonoBehaviour
{
    [SerializeField]
    private int quantity;
    [SerializeField]
    private GameObject trashPrefab;
    [SerializeField]
    private Rect area;

    private void Start()
    {
        this.InstantiateTrash();
    }

    public void InstantiateTrash()
    {
        var trashObject = GameObject.Instantiate(this.trashPrefab);
        this.DefinirPosicaoInimigo(trashObject);
    }

    private void DefinirPosicaoInimigo(GameObject trashObject)
    {
        var randomPosition = new Vector3(
                        Random.Range(this.area.xMin, this.area.xMax),
                        Random.Range(this.area.yMin, this.area.yMax),
                        0);

        var trashPosition = this.transform.position + randomPosition;
        trashObject.transform.position = trashPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(100, 0, 100);
        var position = this.area.position + (Vector2)this.transform.position + this.area.size / 2;
        Gizmos.DrawWireCube(position, this.area.size);
    }
}
