using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Asn4
{
    public class AnimalDialogFactory
    {

        public static string GetRandomAnimalNoise()
        {
            string[] noises =
            {
                "A low growl rolls through the darkness.",
                "Something chitters from inside the walls.",
                "A wet snarl echoes nearby.",
                "Claws scrape slowly across stone.",
                "A distant howl rises, then cuts off suddenly.",
                "Something breathes heavily just out of sight.",
                "A sharp screech tears through the silence.",
                "Tiny feet skitter across the floor.",
                "A beast lets out a broken, rasping cry.",
                "Wings flap overhead, but you see nothing.",
                "A deep hiss seeps from the shadows.",
                "Something gnaws loudly in the dark.",
                "A guttural bark answers from far away.",
                "A long, mournful wail drifts through the air.",
                "Something clicks its teeth together.",
                "A low purr vibrates from the blackness.",
                "A creature sniffs loudly, searching for you.",
                "A shrill cry echoes, almost like laughter.",
                "Something drags its claws across wood.",
                "A pack of unseen creatures yips in the distance.",
                "A hollow hoot sounds from above.",
                "A beast exhales with a rattling wheeze.",
                "Something splashes in unseen water.",
                "A raspy caw echoes between the trees.",
                "A soft whimper comes from somewhere nearby.",
                "A sudden snort breaks the silence.",
                "Something lets out a clicking, insect-like trill.",
                "A deep croak bubbles from the darkness.",
                "A creature snarls, then goes completely quiet.",
                "A strange animal cry echoes like a warning."
                };

            int index = Random.Shared.Next(noises.Length);
            return noises[index];
        }


    public static void Dialogger(Animal a, Player p)
        {
            bool talk = true;
            while (talk == true)
            {
                LookupTable lookupTable = new LookupTable();
                Console.WriteLine("What would you like to do?");
                var input = Console.ReadLine()?.ToLower();  //this can be migrated to TakeInput?
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("No command entered.");
                    continue;
                }

                if (input == "quit" || input == "exit" || input == "bye")
                {
                    talk = false;
                }
                else
                {
                    Tokenizer t = new Tokenizer();
                    var ast = t.Tokenize(input);
                    var verb = ast?.Where(x => x.Name == TokenType.verb).FirstOrDefault();
                    if (verb is not null)  //if no verb is found.
                    {
                        try
                        {
                            Action action = lookupTable[verb.Value];
                            ComContext context = new ComContext(p, a);
                            action(ast, context);

                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("That verb is not recognized.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No verb found.");
                    }
                }
            }
        }
    }
}
