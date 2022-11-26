using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartStage : MonoBehaviour
{
    [SerializeField] private Text _uiText;

    private string[] _uiTextValue = new string[]{
        "첫 튜토리얼을 시작합니다. 안내 지시에 잘 따라주세요.",
        "좌측(우측) 방향지시등을 켜세요.",
        "방향지시등을 끄세요.",
        "와이퍼를 작동하세요.",
        "와이퍼를 끄세요.",
        "브레이크를 밟은 상태에서 기어를 리버스(R)로 바꾸세요.",
        "악셀을 살짝 밟아 속도 12 ~ 20Km/H로 5초 동안 유지하세요.",
        "브레이크를 밟아 멈추세요.",
        "브레이크를 밟은 상태에서 기어를 드라이브(D)로 바꾸세요.",
        "악셀을 살짝 밟아 속도 12 ~ 20Km/H로 5초 동안 유지하세요.",
        "핸들을 반 시계반향으로 돌리고 노란 선을 밟지 않게 앞으로 나아가세요.",
        "핸들을 시계반향으로 돌리고 노란 선을 밟지 않게 앞으로 나아가세요.",
        "성공적으로 모두 완료했습니다!"
    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
