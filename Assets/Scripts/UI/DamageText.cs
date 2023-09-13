using Redcode.Pools;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour, IPoolObject
{
    private float moveSpeed;
    private float alphaSpeed;
    private float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int damage;
    public Transform spawnPosition;
    private Color originColor;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnPosition.position;
        moveSpeed = 2.0f;
        alphaSpeed = 2.0f;
        destroyTime = 2.0f;
        originColor = text.color;
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // �ؽ�Ʈ ��ġ

        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // �ؽ�Ʈ ���İ�
        text.color = alpha;
    }

    private void DestroyObject()
    {
        PoolManager.Instance.TakeToPool(4, this);
    }

    public void OnCreatedInPool() { }

    public void OnGettingFromPool()
    {
        text.color = originColor;
        transform.position = spawnPosition.position;
    }
}