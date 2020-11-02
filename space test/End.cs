using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Text;

namespace space_test
{
    class End
    {
        private static string[] qoutes = { "It's not my fault. - Han Solo", "Your focus determines your reality. - Qui-Gon Jinn",
            "Do. Or do not. There is no try. - Yoda", "Somebody has to save our skins. - Leia Organa",
            "In my experience there is no such thing as luck. - Obi-Wan Kenobi", "I find your lack of faith disturbing. - Darth Vader",
            "I've got a bad feeling about this. - basically everyone", "It's a trap! - Admiral Ackbar",
            "So this is how liberty dies...with thunderous applause. - Padme Amidala", "Your eyes can deceive you. Don't trust them. - Obi-Wan Kenobi"
            , "Never tell me the odds. - Han Solo", "Mind tricks don't work on me. - Watto", "Great, kid. Don't get cocky. - Han Solo",
            "Stay on target. - Gold Five", "This is a new day, a new beginning. - Ahsoka Tano", "Perfectly balanced, as all things should be. - Thanos" ,
            "Help me, Obi-Wan Kenobi. You're my only hope. - Leia Organa", "The Force will be with you. Always. - Obi-Wan Kenobi",
            "No. I am your father. - Darth Vader", "Now, young Skywalker, you will die. - Emperor Palpatine",
            "There's always a bigger fish. - Qui-Gon Jinn", "I'm just a simple man trying to make my way in the universe. - Jango Fett",
            "Power! Unlimited power! - Darth Sidious", "Logic is the beginning of wisdom, not the end. -- Spock", "Highly illogical. -- Spock",
            "Live long, and prosper. -- Spock", "Things are only impossible until they're not. -- Captain Jean-Luc Picard",
            "Insufficient facts always invite danger. -- Spock",
            "I canna' change the laws of physics. -- Montgomery 'Scotty' Scott", "KHAAANNN! -- Captain James T. Kirk",
            "One man cannot summon the future. --Spock", "But one man can change the present! -- Kirk",
            "Change is the essential process of all existence. -- Spock",   "It is the lot of 'man' to strive no matter how content he is. -- Spock",
            "Without freedom of choice there is no creativity. -- Captain James T. Kirk",
            "To boldly go where no man has gone before. -- Captain James T. Kirk", "I Am Groot. -- Groot", "Great, the digital pimp at work. -- Switch",
            "Human beings are a disease, cancer of this planet. -- Agent Smith", "The matrix is a system Neo, that system is our enemy. -- Morpheus",
            "There is no spoon. -- Neo", "Reality is often disappointing. -- Thanos", "nope"};
        private static int num = 0;

        public static void SetQ()
        {
            Random rand = new Random();
            num = rand.Next(0, qoutes.Length);
        }

        public static string Qoute() 
        {
            return qoutes[num];
        }
    }
}
