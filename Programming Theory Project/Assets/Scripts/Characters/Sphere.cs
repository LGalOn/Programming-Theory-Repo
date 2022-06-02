using System.Collections;
using UnityEngine;

// INHERITANCE
public class Sphere : Character
{
    [SerializeField]
    int repeatTimes = 3;
    
    [SerializeField]
    float repeatRate = .5f, intervalsTime = 3;

    // POLYMORPHISM
    public override void DisplayText()
    {
        base.DisplayText();
        StartCoroutine(StartTalk());
    }

    IEnumerator StartTalk()
    {
        var bubble = TalkBubble.Ins;
        bubble.text.text = talkText;
        int count = 0;

        while (count < repeatTimes)
        {
            yield return new WaitForSeconds(repeatRate);

            bubble.text.text = $"    {bubble.text.text}";
            count++;
        }

        yield return new WaitForSeconds(intervalsTime);
        yield return StartTalk();
    }

    // POLYMORPHISM
    public override void EndTalk()
    {
        StopAllCoroutines();
        base.EndTalk();
    }
}
