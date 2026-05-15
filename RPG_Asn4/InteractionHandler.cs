namespace RPG_Asn4
{
    public static class InteractionHandler
    {
        public static bool InteractWith(List<IInteractable> targets, Player player)
        {
            
            if (targets.Count == 0)  
            {
                Display.Igm("There is nothing to interact with.");
                return true;
            }

            Display.Igm("You see the following:");

            for (int i = 0; i < targets.Count; i++)
            {
                string stateLabel = "";

                if (targets[i] is Actor actor && actor.StateMachine.CurrentState != null)
                {
                    stateLabel = $" ({actor.StateMachine.CurrentState.Name})";
                }
                Display.List($"{i + 1}. {targets[i].Name}{stateLabel}");
            }

            int waitOption = targets.Count + 1;  //this adds a wait option to let an npc finish their state before they are ready to interact
            int exitOption = targets.Count + 2; // this adds the number of targets + 2 to the list of available selections
            Display.Igm($"{waitOption}. Wait a moment.");
            Display.Igm($"{exitOption}. Back to Main Menu.");
            int choice = TakeInput.PromptIntRange("Your selection adventurer: ", 1, exitOption);

            if (choice == exitOption)
            {
                Display.Igm("\nYou step back from the interaction.");
                return false;
            }
            else if (choice == waitOption)
            {
                Display.Igm("\nYou stand quietly, watching the area.");
                return true;
            }
            else if (choice > 0 && choice <= targets.Count)
            {
                targets[choice - 1].OnInteract(player);
                return true;
            }
            else
            {
                Display.Error("Invalid Choice.");
                return true;
            }
            
        }
    }
}
