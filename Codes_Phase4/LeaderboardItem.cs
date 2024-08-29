using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardItem : MonoBehaviour
{
    public TMP_Text rankText;
    public TMP_Text nameText;
    public TMP_Text scoreText;

    public void SetValues(int rank, string name, int score)
    {
        rankText.text = rank.ToString();
        nameText.text = name;
        scoreText.text = score.ToString();
    }

    public void SetItemPosition(Vector2 position)
    {
        GetComponent<RectTransform>().anchoredPosition += position;
    }
}