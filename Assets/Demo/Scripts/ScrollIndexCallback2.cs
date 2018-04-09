using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollIndexCallback2 : MonoBehaviour 
{
    public Text text;
    public LayoutElement element;
    private static float[] randomWidths = new float[3] { 250, 300, 350 };
    void ScrollCellIndex(int idx)
    {
        string name = "Last Cell";
        if (idx == TestScript.Instance.loopScrollRect.totalCount - 1) {
            element.preferredHeight = 500;
        } else {
            element.preferredHeight = randomWidths[Mathf.Abs(idx) % 3];
            name = "Cell " + idx.ToString();
        }
        if (text != null) {
            text.text = name;
        }
        gameObject.name = name;
    }
}
