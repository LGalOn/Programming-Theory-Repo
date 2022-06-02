using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Character : MonoBehaviour
{
    public Color Color => color;
    // ENCAPSULATION
    public string CharacterName
    {
        get
        {
            return characterName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                Debug.Log("character name cannot be empty");
            else if (charactersNames.Contains(value))
                Debug.Log($"name {value} is taken");
            else
            {
                if (charactersNames.Contains(characterName))
                    charactersNames.Remove(characterName);

                characterName = value;
                charactersNames.Add(value);
            }
        }
    }

    [SerializeField]
    Color color;

    [SerializeField]
    string baseName;

    [SerializeField]
    protected string talkText;

    string characterName;

    static List<string> charactersNames = new List<string>();


    void Awake()
    {
        color.a = 1;
        transform.GetChild(2).GetComponent<MeshRenderer>().material.color = color;

        CharacterName = baseName;
    }

    // POLYMORPHISM
    public virtual void DisplayText()
    {
        var bubble = TalkBubble.Ins;
        bubble.Open(this);
        bubble.text.text = talkText;
    }

    // POLYMORPHISM
    public virtual void EndTalk() { }
}
