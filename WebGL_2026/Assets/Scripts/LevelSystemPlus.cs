using UnityEngine;

// 10강 선택 과제 정답: 기본 과제에 업그레이드 1 (경험치 막대), 2 (남은 마릿수), 3 (천 단위 쉼표) 를 모두 넣은 것
// 학생은 하나만 해도 됨. 기본 과제 정답은 LevelSystem.cs
public class LevelSystemPlus : MonoBehaviour
{
    public int[] expList = { 3000, 7000, 3000, 60000, 7000, 3000 };

    [ContextMenu("레벨 계산")]
    void CalculateLevel()
    {
        int level = 1;
        int exp = 0;
        int totalExp = 0;                       // 업그레이드 3: 얻은 경험치 합계

        for (int i = 0; i < expList.Length; i++)
        {
            exp += expList[i];
            totalExp += expList[i];

            while (exp >= level * 10000)
            {
                exp -= level * 10000;
                level++;
                Debug.Log("레벨업! Lv " + level);
            }
        }

        int needExp = level * 10000;

        // 업그레이드 1: 경험치 막대 (10 칸)
        int barLength = 10;
        int filledCount = exp * barLength / needExp;
        string bar = "";
        for (int i = 0; i < barLength; i++)
        {
            if (i < filledCount) bar += "■";
            else bar += "□";
        }
        Debug.Log("최종 Lv " + level + " " + bar + " " + exp + " / " + needExp);

        // 업그레이드 2: 마지막에 잡은 몬스터를 몇 마리 더 잡으면 레벨업하는지
        // 0 칸이면 마지막 칸이 없으므로 건너뜀 (expList[-1] 은 IndexOutOfRangeException)
        if (expList.Length > 0)
        {
            int lastExp = expList[expList.Length - 1];
            int remainExp = needExp - exp;
            int moreCount = remainExp / lastExp;
            if (remainExp % lastExp != 0) moreCount++;   // 나머지가 있으면 한 마리 더 (올림)
            Debug.Log("마지막 몬스터를 " + moreCount + " 마리 더 잡으면 레벨업");
        }

        // 업그레이드 3: 천 단위 쉼표
        // 뒤에서부터 세 자리씩 잘라 글자 앞에 붙임. 잘라 낸 세 자리는 005 처럼 0 을 채움
        int rest = totalExp;
        string totalText = "";
        while (rest >= 1000)
        {
            int part = rest % 1000;
            totalText = "," + part / 100 + part / 10 % 10 + part % 10 + totalText;
            rest /= 1000;
        }
        totalText = rest + totalText;
        Debug.Log("얻은 경험치 합계 " + totalText);
    }
}
