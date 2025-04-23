using System;
using System.Media;
using System.Threading;

class CyberSecurityChatbot
{
    static void Main()
    {
        
        PlayWelcomeSound();
        
        DisplayAsciiArt();
        
        string userName = GetUserName();
        
        RunChatLoop(userName);
    }

    static void PlayWelcomeSound()
    {
        
        string audioPath = "Welcome";

        if (!File.Exists(audioPath))
        {
            audioPath = @"C:\Users\lab_services_student\source\repos\Part 1\Part 1\Welcome.wav\Welcome.wav";
        }

        if (File.Exists(audioPath))
        {
            try
            {
                using (var player = new System.Media.SoundPlayer(audioPath))
                {
                    player.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Welcome audio file not found in either location");
        }
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.ResetColor();
    }
    
    static string GetUserName()
    {
        Console.Write("Hello! What's your name? ");
        string name = Console.ReadLine();
        
        while(string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please enter a valid name.");
            name = Console.ReadLine();
        }
        
        return name;
    }
    
    static void RunChatLoop(string userName)
    {
        bool continueChat = true;
        
        Console.WriteLine($"Welcome {userName}! How can I help you with cybersecurity today?");
        
        while(continueChat)
        {
            string input = Console.ReadLine().ToLower();
            
            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("I didn't hear anything. Could you repeat that?");
                continue;
            }
            
            string response = GenerateResponse(input, userName);
            
            TypeOutResponse(response);
            
            if(input.Contains("bye") || input.Contains("exit"))
            {
                continueChat = false;
            }
        }
    }
    
    static string GenerateResponse(string input, string userName)
    {
        if(input.Contains("how are you"))
            return "I'm just a bot, but I'm functioning well! How about you, " + userName + "?";
        
        if(input.Contains("purpose") || input.Contains("what can you do"))
            return "I help South Africans learn about cybersecurity - passwords, phishing, and safe browsing!";
        
        if(input.Contains("password"))
            return "Strong passwords should be long, unique, and include numbers/symbols. Never share them!";
            
        if(input.Contains("phishing"))
            return "Phishing scams try to trick you into revealing info. Always check sender addresses carefully!";
            
        if(input.Contains("browsing") || input.Contains("safe internet"))
            return "Only visit HTTPS websites, don't download unknown files, and use antivirus software.";
        
        return "I'm not sure I understand. Could you ask about cybersecurity topics like passwords or phishing?";
    }
    
    static void TypeOutResponse(string response)
    {
        foreach(char c in response)
        {
            Console.Write(c);
            Thread.Sleep(20); 
        }
        Console.WriteLine();
    }
}