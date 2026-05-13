namespace RPG_Asn4
{
    public class AnimalDialogFactory
    {

        public static string GetRandomAnimalNoise()
        {
            string[] noises =  //chatGpt generated list, and I editied it a bit to be more fitting for the game, and less repetitive.
            {
                "a low growl through the darkness.",
                "chittering sounds.",
                "an echoing wet snarl.",
                "a claw scrape.",
                "a rising howl, then cuts off suddenly.",
                "a sharp screech tears through the silence.",
                "a broken, rasping cry.",
                "a deep hiss seeps from the shadows.",
                "a loud gnawing.",
                "a guttural bark.",
                "a long, mournful wail.",
                "a shrill cry, almost like laughter.",
                "a rattling wheeze.",
                "a sudden snort.",
                "a deep croak.",
                "a snarl, then goes completely quiet.",
                "strange animal cries that echoe like a warning."
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
                            if (!a.canInteract)
                            {
                                talk = false;
                            }
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
