using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wall;
    public float sizeZ;

    //public Transform[] parent;    // ���� ��ȯ�� �θ��� ��ġ

    public GameObject[] parent;     // ���� ��ȯ�� �ڽĵ��� ����� �θ� ���� �迭

    public bool changePos = true;
    [SerializeField] private int examNo = 99;
    private int test = 0;
    // Start is called before the first frame update

    private void OnEnable()
    {
        try
        {
            examNo = PlayerPrefs.GetInt("Exam");
        }
        catch (System.Exception ex)
        {
            examNo = 99;
        }

        if (examNo == 6)
            return;
        // �߰��� �θ��� �ڽ��� ������ �ľ��ϱ� ���� �ݺ�
        for (int i = 0; i < parent.Length; i++)
        {

            if (examNo != i)
                continue;
            Debug.Log(parent[i].transform.childCount);
            // �ڽ��� ������ŭ ���� �����ϱ� ���� �ݺ���
            for (int j = 0; j < parent[i].transform.childCount; j++)
            {
                //Debug.Log(parent[i].transform.GetChild(j).transform);
                Transform childTransform = parent[i].transform.GetChild(j).transform;   // �ڽ��� ��ġ�� ��������
                GameObject instance = Instantiate(wall, childTransform);                // �ڽ��� ��ġ�� ���� ����
                if (changePos)
                {
                    // ���� ��ġ�� ������ ��ġ���� ������� y��ũ�⸸ŭ y������ �̵�
                    instance.transform.position = instance.transform.position + new Vector3(0, sizeZ, 0);
                    // ���� ũ�⸦ �Էµ� sizeY ��ŭ �߰�
                    instance.transform.localScale = instance.transform.localScale + new Vector3(0, 0, sizeZ);
                }
            }
        }

        test++;
    }

    private void OnDisable()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("wall");
        for (int i = 0; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }
    }
}
