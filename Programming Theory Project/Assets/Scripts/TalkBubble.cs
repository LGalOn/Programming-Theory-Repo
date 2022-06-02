using UnityEngine;
using UnityEngine.UI;

public class TalkBubble : MonoBehaviour
{
    public static TalkBubble Ins;

    public Text text;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    Text nameText;

    Character character;
    InputField field;
    Text placeHolderText;


    void Awake()
    {
        if (Ins != null)
            Destroy(Ins.gameObject);

        Ins = this;

        field = GetComponentInChildren<InputField>(true);
        field.onEndEdit.AddListener(SetName);
        placeHolderText = field.placeholder.GetComponent<Text>();
    }

    public void Open(Character character)
    {
        panel.SetActive(true);

        this.character = character;

        nameText.color = character.Color;
        SetNameText();
        SetPlaceHolderText();
    }

    // ABSTRACTION
    void SetNameText() => nameText.text = character.CharacterName + " :";
    void SetPlaceHolderText() => placeHolderText.text = $"Rename {character.CharacterName}...";

    public void Close()
    {
        if (character != null)
            character.EndTalk();

        panel.SetActive(false);
    }

    void SetName(string name)
    {
        if (character == null)
            return;

        character.CharacterName = name;

        field.text = string.Empty;

        SetNameText();
        SetPlaceHolderText();
    }
}
