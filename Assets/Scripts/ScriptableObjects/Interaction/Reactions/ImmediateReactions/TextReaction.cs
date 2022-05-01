using UnityEngine;

// This Reaction has a delay but is not a DelayedReaction.
// This is because the TextManager component handles the
// delay instead of the Reaction.
public class TextReaction : Reaction
{
    public string message;                      // The text to be displayed to the screen.
	public CharacterProps character;
    public float delay;                         // How long after the React function is called before the text is displayed.


    private TextManager textManager;            // Reference to the component to display the text.


    protected override void SpecificInit()
    {
        textManager = FindObjectOfType<TextManager> ();
    }


    protected override void ImmediateReaction()
    {
        textManager.DisplayMessage (message, character, delay);
    }
}