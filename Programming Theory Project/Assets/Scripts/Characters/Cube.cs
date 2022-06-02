using UnityEngine;

// INHERITANCE
public class Cube : Character
{
    [SerializeField]
    string talkText2;

    [SerializeField]
    float text2Delay = .5f, repeatRate = 2;

    // POLYMORPHISM
    public override void DisplayText()
    {
        base.DisplayText();

        Invoke(nameof(AddText2), text2Delay);
    }

    void AddText2()
    {
        var bubble = TalkBubble.Ins;
        bubble.text.text += $"\n{talkText2}";

        Invoke(nameof(DisplayText), repeatRate);
    }

    // POLYMORPHISM
    public override void EndTalk()
    {
        CancelInvoke();
        base.EndTalk();
    }
}
