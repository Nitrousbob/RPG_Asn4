﻿namespace RPG_Asn4
{
    //im starting to notice my Command class needs to know about the Context of the game for different commands.
    public class Command
    {
        public void Look(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is Animal a)
            {
                Display.Action(a.GetDescription());
            }
            else if (c.CurrentTarget is Npc n)
            {
                Display.Action(n.GetDescription());
                string eyeBodyLanguage = DialogFactory.NpcEyeBehavior(n);
                Display.Igm($"'{eyeBodyLanguage}'");
            }
            else
            {
                Console.WriteLine("There is nothing to look at.");
            }
        }
        public void Talk(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is ITalkable talkable)
            {
                Display.Action($"You talk to {talkable.Name}");
                Display.Igm(talkable.GetTalkResponse());
            }
            else
                {
                    Display.Igm($"{c.CurrentTarget.Name} doesn't seem to be able to talk.");
                }
        }

        public void Ask(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is IQuestionable questionable)
            {
                Display.Action($"You ask {questionable.Name} a question.");
                Display.Igm(questionable.GetQuestionResponse());
            }
            else
            {
                Display.Igm($"{c.CurrentTarget} doesn't seem to be able to answer questions.");
            }
        }


        public void Pet(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is IPettable pettable)
            {
                Display.Action($"You pet {pettable.Name}");
                Display.Igm(pettable.GetPetResponse());
            }
            else if (c.CurrentTarget is Npc n)
            {
                Display.Action($"You try to pet {n.Name}");
                Display.Igm($"{n.Name} doesn't seem to like that.");
            }
            else
            {
                Display.Igm("Very unusual, that's not something you can pet.");
            }

        }

        public void Slap(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is Npc npc)
            {
                Display.Action($"You slap {npc.Name}");
                Display.DarkAction($"{npc.Name} looks at you with shock and anger.");
                npc.BlockInteraction(3);  //mad for 3 turns, you can't interact with them for 3 turns.
                //remove interactable from npc while they are slapped, then add them back after a few turns to simulate them being mad at you for a while.
                //this was put into the Animals and Npcs OnInteract method, so they will stop interacting with you for a few turns after being slapped.
            }
            else if (c.CurrentTarget is Animal animal)
            {
                Display.Action($"You slap {animal.Name}");
                Display.DarkAction($"{animal.Name} looks at you with shock and anger.");
                animal.BlockInteraction(3);  //mad for 3 turns, you can't interact with them for 3 turns.
            }
            else
            {
                Display.Igm("That didn't just happen again!");  //enter combat state?
            }
        }

        public void Laugh(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is Npc npc)
            {
                Display.Action($"You laugh at {npc.Name}");
                Display.DarkAction($"{npc.Name} laughs back at you.");
            }
            else if (c.CurrentTarget is Animal animal)
            {
                Display.Action($"You laugh at {animal.Name}");
                Display.DarkAction($"{animal.Name} tilts its head, confused by the noise.");
            }
            else
            {
                Display.Igm("There I go just laughing out loud again.");
            }
        }   

        public void Flirt(List<Token> tokens, ComContext c)
        {
            if (c.CurrentTarget is IInteractable interactable)
            {
                Display.Action($"You flirt with {interactable.Name}");
                Display.DarkAction($"{interactable.Name} blushes and looks away.");
                //TODO maybe need to add a mood property or enum
            }
            else if (c.CurrentTarget is Animal animal)
            {
                Display.Action($"You try to flirt with {animal.Name}");
                Display.DarkAction($"{animal.Name} ignores you completely.");
            }
            else
            {
                Display.Igm("You can't flirt with that. Im sure its flattered though");
            }
        }

        public void Fart(List<Token> tokens, ComContext c)
        {
            if(c.CurrentTarget is IInteractable interactable)
            {
                Display.Action($"You break wind in their general direction");

                int choice = Random.Shared.Next(3);
                switch (choice)
                {
                    case 0:
                        Display.DarkAction($"{interactable.Name} laughs at your display of bodily function.");
                        break;
                    case 1:
                        Display.DarkAction($"{interactable.Name} is not amused.");
                        break;
                    case 2:
                        Display.DarkAction($"{interactable.Name} fires back with their own brand of flatulence");
                        break;
                }
            }
        }

        public void Help(List<Token> tokens, ComContext c)
        {
            Display.Action("Available commands: ");
            Display.Bright("pet, look, help, exit, quit, bye, hit, slap, talk, laugh, flirt, fart");
            //can the list for actions build up from a dictionary and display available options?
        }

        public void Exit(List<Token> tokens, ComContext c)
        {
            Display.Igm("Ending conversation...");
            c.EndInteration = true;
        }
    }
}
