using UnityEngine.UI;

/// <summary>
/// 아이템 획득 시, 아이템을 획득하려 했을 때 인벤토리가 꽉찼을 시, 경험치 획득 시, 퀘스트 완료 가능 시
/// </summary>

public class NotificationManager : Singleton<NotificationManager> {
    private int count = 0;
    private int Count { get { return count; } set { if(value >= NotificationTexts.Length) count = 0; else count++; } }

    public bool ShowingMessage = false;

    public Text[] NotificationTexts;

    //알림 텍스트 생성
    private void Generate(string message) {
        Text textObj = NotificationTexts[count];

        if(textObj.gameObject.activeSelf)
            textObj.gameObject.SetActive(false);
        textObj.gameObject.SetActive(true);
        textObj.transform.SetAsLastSibling();  //최신에 생성된 알림이 맨 아래에 위치하기 위함.

        textObj.text = message;
        Count++;
    }

    public void Generate_GetItem(string ItemName, int count) {
        string str = "アイテムを獲得しました。 (" + ItemName + " +" + count + "個)";
        Generate(str);
    }

    public void Generate_InventoryIsFull() {
        string str = "インベントリに空きがありません。";
        Generate(str);
    }

    public void Generate_GetExp(float Exp) {
        string str = "経験値を獲得しました。 (+" + Exp.ToString() + ")";
        Generate(str);
    }

    public void Generate_CompletableQuest() {
        string str = "クエスト完了！NPCに行って報酬をもらいましょう。";
        Generate(str);
    }
}