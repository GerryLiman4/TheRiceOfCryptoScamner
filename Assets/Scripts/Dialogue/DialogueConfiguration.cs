using UnityEngine;

[CreateAssetMenu(menuName = "2DMovementTuning/Create Dialogue Node")]
public class DialogueConfiguration : ScriptableObject
{
    [SerializeField] private DialogueNode dialogueNode;
    [SerializeField] private CharacterID speaker;
    
    public string GetDialogueTitle(){
        return dialogueNode.title;
    }
    public string GetDialogueContent(){
        return dialogueNode.content;
    }
    public int GetDialogueID(){
        return dialogueNode.id;
    }
}

