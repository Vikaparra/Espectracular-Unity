using UnityEngine;
public class TrashGenerator : MonoBehaviour
{
    [SerializeField]
    private int quantity;
    [SerializeField]
    private GameObject trashPrefab;
    [SerializeField]
    private float radius;

    private void Start()
    {
        this.InstantiateTrash();
    }

    private void InstantiateTrash()
    {
        var trashObject = GameObject.Instantiate(this.trashPrefab);
        this.DefinirPosicaoInimigo(trashObject);
    }

    private void DefinirPosicaoInimigo(GameObject trashObject)
    {
        // var randomPosition = new Vector3(
        //                 Random.Range(-this.radius, this.radius),
        //                 Random.Range(-this.radius, this.radius),
        //                 0);
                              var randomPosition = new Vector3(
                       this.radius,
                       this.radius
                   );

        var trashPosition = this.transform.position + randomPosition;
        trashObject.transform.position = trashPosition;
    }
}
