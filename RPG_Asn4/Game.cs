using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RPG_Asn4
{
    public class Game
    {
        Player player = new Player("");
        string path = AppDomain.CurrentDomain.BaseDirectory;  //this will put it in the same directory as executable, which is probably the bin/Debug/net10.0 folder
        //string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "playerData.json");
        public Game()
        {
            
        }

        public void CreatePlayer()
        {
            Console.WriteLine("Creating a new character...");
            string name = TakeInput.GetPlayerName();
            player = new Player(name);
            SavePlayer();
        }

        public void LoadPlayer()
        {
            string[] files = Directory.GetFiles(path, "*.json"); //This gets all the .json files in the directory, which should be the saved player files.
            if (files.Length == 0)  //If there are no .json files, it means there are no saved files to open
            {
                Console.WriteLine("No saved player data found. Please create a character first.");
                return;
            }

            Console.WriteLine("Available saved players:");
            for (int i = 0; i < files.Length; i++ ) {
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileNameWithoutExtension(files[i])}"); //This lists the available saved player files by their names (without the .json extension).
            }
            
            Console.Write ("Enter the number of the player you want to load: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= files.Length)
            {
                string selectedFile = files[choice -1]; //This gets the file path of the selected player based on the user's input.

                    try { }    
                
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }

            if (!File.Exists(Path.Combine(path, $"{player.Name}.json"))) //This checks if the file for the current player's name exists. If it doesn't, it means there's no saved data for that player.
            {
                Console.WriteLine("No saved player data found. Please create a character first.");
                return;
            }
            else
            {
                using StreamReader sr = File.OpenText(Path.Combine(path, $"{player.Name}.json"));
                string content;
                while ((content = sr.ReadLine()) != null)
                {
                    try
                    {
                        Player? filePlayer = JsonSerializer.Deserialize<Player>(content);
                        if (filePlayer != null)
                        {
                            player = filePlayer;
                            Display.Igm($"Player loaded successfully. Name: {player.Name}");
                        }
                    }
                    catch (JsonException e)
                    {
                        Console.WriteLine("Error loading player data: " + e.Message);
                    }
                }
            }
        }

        public void SavePlayer()
        {
            if (!File.Exists(Path.Combine(path, $"{player.Name}.json")))
            {
                using StreamWriter sw = File.CreateText(Path.Combine(path, $"{player.Name}.json"));
                {
                    sw.WriteLine(JsonSerializer.Serialize(player));
                    Display.Igm("Player saved successfully.");
                }
                
            }
            
        }
    }
}
