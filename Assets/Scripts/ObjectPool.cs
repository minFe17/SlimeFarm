using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // 싱글턴
    Dictionary<ESlimeType, Queue<GameObject>> _slimeobjectPool = new Dictionary<ESlimeType, Queue<GameObject>>();

    public void Init()
    {
        for (int i = 0; i < (int)ESlimeType.Max; i++)
        {
            _slimeobjectPool.Add((ESlimeType)i, new Queue<GameObject>());
        }
    }

    GameObject CreateSlime(GameObject slimePrefab)
    {
        return Instantiate(slimePrefab);
    }

    public GameObject PushSlime(ESlimeType slimeType, GameObject slimePrefab)
    {
        Queue<GameObject> slimeQueues;
        GameObject slime = null;

        _slimeobjectPool.TryGetValue(slimeType, out slimeQueues);
        if(slimeQueues.Count > 0)   // Queue에 슬라임이 있는지 체크
            slime = slimeQueues.Dequeue();  // 슬라임 꺼내기
        else
           slime = CreateSlime(slimePrefab);
        return slime;
    }

    public void PullSlime(Slime slime)
    {
        Queue<GameObject> slimeQueues;
        _slimeobjectPool.TryGetValue(slime.SlimeType, out slimeQueues);
        slime.gameObject.SetActive(false);
        slimeQueues.Enqueue(slime.gameObject);  // 슬라임 넣기
        slime.gameObject.transform.parent = this.transform;
    }
}