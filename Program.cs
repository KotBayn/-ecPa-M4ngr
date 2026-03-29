using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;


namespace SecPassM4ngr
{
    public class Program
    {
        static readonly string[] Dictionary1 = [ "Shadow", "Thunder", "Falcon", "Nexus", "Alpha", "Zenith", "Inferno",
                "Vortex", "Cyber", "Knight", "Dragon", "Matrix", "Volt", "Ghost", "Pixel", "Nova",
                "Dragon", "Mage", "Rune", "Mana", "Guild", "Castle", "Knight", "Paladin", "Orc", "Goblin",
                "Elf", "Dwarf", "Spell", "Potion", "Sword", "Shield", "Amulet", "Relic", "Griffin", "Wyvern",
                "Demon", "Angel", "Spirit", "Wraith", "Necromancer", "Warlock", "Druid", "Rogue", "Cleric",
                "Tavern", "Dungeon", "Loot", "Quest", "Myth", "Legend", "Prophecy", "Crystal", "Gem",
                "Chrome", "Neon", "Netrunner", "Glitch", "Synth", "Sprawl", "Implant", "Meatbag", "Cortex",
                "Jack-in", "Grid", "Nexus", "Byte", "Wire", "Optic", "V-chip", "Cred", "Cyberware", "Datapad",
                "Holo", "Megacorp", "Street-samurai", "Alloy", "Carbon", "Kevlar", "Fiber", "Overdrive",
                "Brass", "Cog", "Aether", "Zeppelin", "Boiler", "Steam", "Clockwork", "Copper", "Gear",
                "Valve", "Flintlock", "Goggles", "Victorian", "Soot", "Piston", "Furnace", "Cylinder",
                "Airship", "Corset", "Telescope", "Monocle", "Gatling", "Smog", "Machinery", "Wrench",
                "Coil", "Dynamo", "Volt", "Arc", "Plasma", "Oscillator", "Cathode", "Anode", "Current",
                "Surge", "Spark", "Conduit", "Ohm", "Watt", "Frequency", "Lightning", "Electrode", "Magnet",
                "Induction", "Resonator", "Battery", "Generator", "Circuit", "Static", "Ion",
                "Root", "Exploit", "Payload", "Daemon", "Proxy", "Null", "Breach", "Ping", "Node", "Cipher",
                "Encrypt", "Malware", "Trojan", "Botnet", "Phish", "Firewall", "Kernel", "Terminal", "Hash",
                "Script", "Logic", "Bandwidth", "Server", "Client", "Protocol", "Syntax",
                "Scum", "Trash", "Bastard", "Punk", "Dirt", "Rat", "Thug", "Scab", "Grit", "Smut", "Wreck",
                "Fubar", "Scrap", "Junk", "Goon", "Snitch", "Hustler", "Grifter", "Vandal", "Outlaw"
            ];

        static readonly string[] Dictionary2 = [
                "Galaxy", "Nebula", "Pulsar", "Quasar", "Orbit", "Comet", "Meteor", "Eclipse", "Zenith", "Void",
                "Asteroid", "Gravity", "Lunar", "Solar", "Cosmic", "Horizon", "Supernova", "Star", "Planet",
                "Cosmos", "Tsunami", "Volcano", "Glacier", "Canyon", "Avalanche", "Tornado", "Monsoon",
                "Lightning", "Ocean", "Forest", "Desert", "Mountain", "River", "Storm", "Hurricane", "Blizzard",
                "Earthquake", "Typhoon", "Cyclone", "Panther", "Cobra", "Shark", "Rhino", "Tiger", "Lion",
                "Wolf", "Bear", "Eagle", "Falcon", "Hawk", "Viper", "Python", "Jaguar", "Leopard", "Grizzly",
                "Raptor", "Mantis", "Spider", "Scorpion", "Sonata", "Canvas", "Rhythm", "Maestro", "Vinyl",
                "Melody", "Harmony", "Tempo", "Chord", "Bass", "Treble", "Acoustic", "Palette", "Sculptor",
                "Verse", "Stanza", "Chorus", "Symphony", "Opera", "Ballet", "Pharaoh", "Rome", "Viking",
                "Samurai", "Spartan", "Legion", "Empire", "Dynasty", "Shogun", "Aztec", "Mayan", "Inca",
                "Hoplite", "Chariot", "Gladiator", "Anubis", "Zeus", "Odin", "Apollo", "Titan", "Scalpel",
                "Vaccine", "Surgeon", "Clinic", "Plasma", "Anatomy", "Pulse", "Syringe", "Therapy", "Virus",
                "Pharma", "Biotech", "Neuron", "Genetics", "Placebo", "Trauma", "Doctor", "Nurse", "Medic",
                "Enzyme", "Physics", "Quantum", "Atom", "Carbon", "Gravity", "Isotope", "Laser", "Photon",
                "Kinetic", "Optics", "Proton", "Helix", "Theory", "Flask", "Orbit", "Metric", "Matter",
                "Nucleus", "Vector", "Logic", "Tractor", "Harvest", "Wheat", "Barley", "Silo", "Ranch",
                "Orchard", "Cattle", "Plow", "Farmer", "Crop", "Barn", "Pasture", "Seed", "Maize", "Soil",
                "Field", "Mill", "Grange", "Acre", "Toyota", "Honda", "Ford", "Chevy", "Dodge", "Nissan",
                "Mazda", "Suzuki", "Yamaha", "Ducati", "Harley", "Volvo", "Subaru", "Porsche", "Lexus",
                "Jeep", "Tesla", "Audi", "Fiat", "Rover", "Burger", "Pizza", "Sushi", "Taco", "Steak", "Bacon",
                "Cheese", "Pasta", "Salad", "Bread", "Curry", "Ramen", "Chili", "Honey", "Melon", "Berry",
                "Apple", "Toast", "Mango", "Cocoa"
            ];

        
        static async Task Main(string[] args)
        {

            Console.WriteLine("Choose type of password to generate.\n" +
                "Manual or Auto(y/n):");
            string u = Console.ReadLine();

            string[] box;


            if (u?.ToLower() == "y")
            {
                Console.WriteLine("Enter favorit animal: ");
                string an = Console.ReadLine();

                Console.WriteLine("Enter favorit sport: ");
                string sp = Console.ReadLine();

                Console.WriteLine("Enter name of friend: ");
                string fr = Console.ReadLine();

                Console.WriteLine("Enter favorit car: ");
                string cr = Console.ReadLine();

                box = [an, sp, fr, cr];
                Random rnd = new();

            }
            else
            {
                Random rnd = new();

                string ky = Dictionary1[rnd.Next(Dictionary1.Length)];
                string bw = Dictionary2[rnd.Next(Dictionary2.Length)];
                string rp = Dictionary1[rnd.Next(Dictionary1.Length)];
                string tp = Dictionary2[rnd.Next(Dictionary2.Length)];

                box = [ky, bw, rp, tp];

            }

            // Cicle through each word in the password array
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = PSWRDGN.FullMap(box[i]);
            }
            Random random = new();
            //Mix the array to make it more secure
            // making sure to add 2 more random words from the dictionaries
            Array.Resize(ref box, box.Length + 2);
            string p1 = Dictionary1[random.Next(Dictionary1.Length)];
            string p2 = Dictionary2[random.Next(Dictionary2.Length)];
            box[box.Length - 2] = PSWRDGN.FullMap(p1);
            box[box.Length - 1] = PSWRDGN.FullMap(p2);
            bool sz = box.Distinct().Count() != box.Length; // Ensure all words are unique

            box = [.. box.OrderBy(x => random.Next())];

            // Result
            string pakman = string.Join("-", box);
            string ghost = string.Join("-", box.Reverse());

            Console.WriteLine($"Generated Key: {pakman}");
            Console.WriteLine($"Reverse Key:   {ghost}");

        }
              
    }
}