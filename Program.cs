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
        static readonly string[] Dictionary1 = 
        [
            "Shadow", "Thunder", "Falcon", "Nexus", "Alpha", "Zenith", "Inferno", "Vortex", "Cyber", "Knight",
            "Dragon", "Matrix", "Volt", "Ghost", "Pixel", "Nova", "Dragon", "Mage", "Rune", "Mana",
            "Guild", "Castle", "Knight", "Paladin", "Orc", "Goblin", "Elf", "Dwarf", "Spell", "Potion",
            "Sword", "Shield", "Amulet", "Relic", "Griffin", "Wyvern", "Demon", "Angel", "Spirit", "Wraith",
            "Necromancer", "Warlock", "Druid", "Rogue", "Cleric", "Tavern", "Dungeon", "Loot", "Quest", "Myth",
            "Legend", "Prophecy", "Crystal", "Gem", "Chrome", "Neon", "Netrunner", "Glitch", "Synth", "Sprawl",
            "Implant", "Meatbag", "Cortex", "Jack-in", "Grid", "Nexus", "Byte", "Wire", "Optic", "V-chip",
            "Cred", "Cyberware", "Datapad", "Holo", "Megacorp", "Street-samurai", "Alloy", "Carbon", "Kevlar", "Fiber",
            "Overdrive", "Brass", "Cog", "Aether", "Zeppelin", "Boiler", "Steam", "Clockwork", "Copper", "Gear",
            "Valve", "Flintlock", "Goggles", "Victorian", "Soot", "Piston", "Furnace", "Cylinder", "Airship", "Corset",
            "Telescope", "Monocle", "Gatling", "Smog", "Machinery", "Wrench", "Coil", "Dynamo", "Volt", "Arc",
            "Plasma", "Oscillator", "Cathode", "Anode", "Current", "Surge", "Spark", "Conduit", "Ohm", "Watt",
            "Frequency", "Lightning", "Electrode", "Magnet", "Induction", "Resonator", "Battery", "Generator", "Circuit", "Static",
            "Ion", "Root", "Exploit", "Payload", "Daemon", "Proxy", "Null", "Breach", "Ping", "Node",
            "Cipher", "Encrypt", "Malware", "Trojan", "Botnet", "Phish", "Firewall", "Kernel", "Terminal", "Hash",
            "Script", "Logic", "Bandwidth", "Server", "Client", "Protocol", "Syntax", "Scum", "Trash", "Bastard",
            "Punk", "Dirt", "Rat", "Thug", "Scab", "Grit", "Smut", "Wreck", "Fubar", "Scrap",
            "Junk", "Goon", "Snitch", "Hustler", "Grifter", "Vandal", "Outlaw", "Vector", "Prism", "Laser",
            "Flux", "Core", "Cell", "Chip", "Wire", "Gate", "Lock", "Key", "Cipher", "Hash",
            "Seed", "Root", "Branch", "Bloom", "Fade", "Bright", "Light", "Dark", "Shade", "Glow",
            "Shine", "Spark", "Flash", "Burst", "Blast", "Boom", "Crash", "Hit", "Strike", "Force",
            "Power", "Energy", "Mass", "Scale", "Scope", "Range", "Limit", "Bound", "Edge", "Border",
            "Line", "Curve", "Shape", "Form", "Style", "Color", "Tone", "Hue", "Pixel", "Texture",
            "Normal", "Tangent", "Sine", "Cosine", "Log", "Exp", "Square", "Absolute", "Min", "Max",
            "Avg", "Sum", "Count", "Len", "Idx", "Pos", "Axis", "Matrix", "Array", "List"
        ];

        static readonly string[] Dictionary2 = 
        [
            "Galaxy", "Nebula", "Pulsar", "Quasar", "Orbit", "Comet", "Meteor", "Eclipse", "Zenith", "Void",
            "Asteroid", "Gravity", "Lunar", "Solar", "Cosmic", "Horizon", "Supernova", "Star", "Planet", "Cosmos",
            "Tsunami", "Volcano", "Glacier", "Canyon", "Avalanche", "Tornado", "Monsoon", "Lightning", "Ocean", "Forest",
            "Desert", "Mountain", "River", "Storm", "Hurricane", "Blizzard", "Earthquake", "Typhoon", "Cyclone", "Panther",
            "Cobra", "Shark", "Rhino", "Tiger", "Lion", "Wolf", "Bear", "Eagle", "Falcon", "Hawk",
            "Viper", "Python", "Jaguar", "Leopard", "Grizzly", "Raptor", "Mantis", "Spider", "Scorpion", "Sonata",
            "Canvas", "Rhythm", "Maestro", "Vinyl", "Melody", "Harmony", "Tempo", "Chord", "Bass", "Treble",
            "Acoustic", "Palette", "Sculptor", "Verse", "Stanza", "Chorus", "Symphony", "Opera", "Ballet", "Pharaoh",
            "Rome", "Viking", "Samurai", "Spartan", "Legion", "Empire", "Dynasty", "Shogun", "Aztec", "Mayan",
            "Inca", "Hoplite", "Chariot", "Gladiator", "Anubis", "Zeus", "Odin", "Apollo", "Titan", "Scalpel",
            "Vaccine", "Surgeon", "Clinic", "Plasma", "Anatomy", "Pulse", "Syringe", "Therapy", "Virus", "Pharma",
            "Biotech", "Neuron", "Genetics", "Placebo", "Trauma", "Doctor", "Nurse", "Medic", "Enzyme", "Physics",
            "Quantum", "Atom", "Carbon", "Gravity", "Isotope", "Laser", "Photon", "Kinetic", "Optics", "Proton",
            "Helix", "Theory", "Flask", "Orbit", "Metric", "Matter", "Nucleus", "Vector", "Logic", "Tractor",
            "Harvest", "Wheat", "Barley", "Silo", "Ranch", "Orchard", "Cattle", "Plow", "Farmer", "Crop",
            "Barn", "Pasture", "Seed", "Maize", "Soil", "Field", "Mill", "Grange", "Acre", "Toyota",
            "Honda", "Ford", "Chevy", "Dodge", "Nissan", "Mazda", "Suzuki", "Yamaha", "Ducati", "Harley",
            "Volvo", "Subaru", "Porsche", "Lexus", "Jeep", "Tesla", "Audi", "Fiat", "Rover", "Burger",
            "Pizza", "Sushi", "Taco", "Steak", "Bacon", "Cheese", "Pasta", "Salad", "Bread", "Curry",
            "Ramen", "Chili", "Honey", "Melon", "Berry", "Apple", "Toast", "Mango", "Cocoa", "Gold",
            "Silver", "Bronze", "Iron", "Copper", "Zinc", "Lead", "Tin", "Nickel", "Cobalt", "Chrome",
            "Titanium", "Platinum", "Diamond", "Ruby", "Emerald", "Sapphire", "Opal", "Pearl", "Jade", "Onyx",
            "Quartz", "Amber", "Coral", "Ivory", "Silk", "Cotton", "Wool", "Leather", "Fur", "Wood",
            "Stone", "Clay", "Brick", "Glass", "Plastic", "Rubber", "Foam", "Gel", "Liquid", "Gas",
            "Solid", "Steam", "Fire", "Water", "Earth", "Air", "Metal", "Energy", "Mass", "Time"
        ];

        static readonly string[] Dictionary3 = 
        [
            "Quantum", "Neutron", "Proton", "Electron", "Photon", "Neutrino", "Quark", "Lepton", "Boson", "Fermion",
            "Laser", "Radar", "Sonar", "Lidar", "Sensor", "Signal", "Frequency", "Wavelength", "Spectrum", "Resonance",
            "Rocket", "Missile", "Torpedo", "Bomb", "Shell", "Bullet", "Cartridge", "Magazine", "Clip", "Barrel",
            "Rifle", "Pistol", "Shotgun", "Sniper", "Cannon", "Turret", "Drone", "Satellite", "Probe", "Rover",
            "Armor", "Shield", "Hull", "Plating", "Coating", "Alloy", "Titanium", "Steel", "Iron", "Lead",
            "Engine", "Motor", "Turbine", "Reactor", "Core", "Battery", "Cell", "Fuel", "Oil", "Gas",
            "Pilot", "Captain", "Commander", "Admiral", "General", "Soldier", "Marine", "Trooper", "Scout", "Ranger",
            "Base", "Camp", "Outpost", "Station", "Depot", "Hangar", "Dock", "Port", "Bay", "Lock",
            "Map", "Grid", "Zone", "Sector", "Region", "Territory", "Border", "Frontier", "Abyss", "Space",
            "Time", "Clock", "Watch", "Timer", "Shift", "Cycle", "Phase", "State", "Mode", "Status",
            "Data", "Info", "File", "Doc", "Record", "Log", "Entry", "Note", "Memo", "Report",
            "Code", "Key", "Pass", "Token", "ID", "Tag", "Label", "Name", "Title", "Rank",
            "Red", "Blue", "Green", "Yellow", "Orange", "Purple", "Black", "White", "Gray", "Silver",
            "Gold", "Bronze", "Platinum", "Diamond", "Ruby", "Emerald", "Sapphire", "Opal", "Pearl", "Jade",
            "North", "South", "East", "West", "Up", "Down", "Left", "Right", "Front", "Back",
            "Apex", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa",
            "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon",
            "Phi", "Chi", "Psi", "Omega", "One", "Two", "Three", "Velocity", "Acceleration", "Momentum",
            "Friction", "Tension", "Pressure", "Volume", "Density", "Viscosity", "Elasticity", "Plasticity", "Hardness", "Toughness",
            "Strength", "Durability", "Stability", "Flexibility", "Rigidity", "Porosity", "Permeability", "Conductivity", "Resistivity", "Capacitance",
            "Inductance", "Impedance", "Admittance", "Susceptance", "Reactance", "Reluctance", "Permeance", "Flux", "Field", "Wave",
            "Particle", "String", "Loop", "Knot", "Link", "Chain", "Network", "System", "Structure", "Function",
            "Process", "Method", "Algorithm", "Protocol", "Standard", "Specification", "Requirement", "Design", "Pattern", "Model",
            "Template", "Schema", "Framework", "Platform", "Interface", "Component", "Module", "Package", "Library", "Database",
            "Storage", "Memory", "Cache", "Buffer", "Stream", "Channel", "Port", "Socket", "Endpoint", "Node"
        ];

        static readonly string[] Dictionary4 = 
        [
            "Tower", "Bridge", "Road", "Street", "Avenue", "Boulevard", "Highway", "Freeway", "Turnpike", "Expressway",
            "Alley", "Lane", "Court", "Drive", "Place", "Way", "Circle", "Plaza", "Square", "Parkway",
            "Terminal", "Station", "Depot", "Junction", "Intersection", "Crossroad", "Roundabout", "Overpass", "Underpass", "Tunnel",
            "Viaduct", "Aqueduct", "Causeway", "Footbridge", "Gangway", "Walkway", "Pathway", "Trail", "Track", "Rail",
            "Subway", "Metro", "Tram", "Trolley", "Monorail", "Funicular", "Elevator", "Escalator", "Lift", "Stair",
            "Ramp", "Slope", "Incline", "Decline", "Gradient", "Embankment", "Retaining", "Foundation", "Basement", "Cellar",
            "Attic", "Loft", "Penthouse", "Mezzanine", "Balcony", "Terrace", "Patio", "Veranda", "Porch", "Deck",
            "Gazebo", "Pavilion", "Kiosk", "Booth", "Stall", "Stand", "Counter", "Desk", "Bench", "Seat",
            "Chair", "Stool", "Table", "Cabinet", "Cupboard", "Closet", "Wardrobe", "Drawer", "Shelf", "Rack",
            "Hook", "Hanger", "Bracket", "Mount", "Fixture", "Fitting", "Joint", "Seam", "Edge", "Corner",
            "Angle", "Vertex", "Apex", "Peak", "Summit", "Top", "Bottom", "Side", "Face", "Plane",
            "Surface", "Layer", "Coating", "Finish", "Texture", "Grain", "Pattern", "Design", "Layout", "Plan",
            "Blueprint", "Draft", "Sketch", "Diagram", "Map", "Chart", "Graph", "Plot", "Scheme", "Model",
            "Prototype", "Mockup", "Sample", "Specimen", "Example", "Instance", "Case", "Study", "Test", "Trial",
            "Experiment", "Measurement", "Dimension", "Scale", "Proportion", "Ratio", "Percentage", "Fraction", "Decimal", "Integer",
            "Number", "Digit", "Figure", "Symbol", "Sign", "Mark", "Label", "Tag", "Badge", "Emblem",
            "Logo", "Icon", "Image", "Picture", "Photo", "Portrait", "Landscape", "Scene", "View", "Vista",
            "Panorama", "Perspective", "Angle", "Focus", "Lens", "Mirror", "Reflection", "Shadow", "Silhouette", "Outline",
            "Border", "Frame", "Margin", "Padding", "Spacing", "Gap", "Void", "Empty", "Blank", "Null",
            "Zero", "None", "Nil", "Nada", "Nothing", "Void", "Abyss", "Chasm", "Crevice", "Crack",
            "Fissure", "Split", "Break", "Fracture", "Fault", "Flaw", "Defect", "Error", "Mistake", "Bug",
            "Glitch", "Hiccup", "Stutter", "Lag", "Delay", "Pause", "Stop", "Halt", "End", "Finish"
        ];

        static readonly string[] Dictionary5 = 
        [
            "Tree", "Bush", "Shrub", "Flower", "Plant", "Grass", "Weed", "Vine", "Moss", "Lichen",
            "Fern", "Palm", "Pine", "Oak", "Maple", "Cedar", "Willow", "Birch", "Ash", "Elm",
            "Poplar", "Spruce", "Fir", "Redwood", "Sequoia", "Bamboo", "Cactus", "Succulent", "Aloe", "Agave",
            "Rose", "Tulip", "Daisy", "Lily", "Orchid", "Jasmine", "Lavender", "Marigold", "Sunflower", "Dandelion",
            "Clover", "Ivy", "Hedge", "Thicket", "Grove", "Orchard", "Garden", "Park", "Meadow", "Prairie",
            "Savanna", "Steppe", "Tundra", "Taiga", "Jungle", "Rainforest", "Woodland", "Thicket", "Copse", "Spinney",
            "Valley", "Hill", "Peak", "Ridge", "Cliff", "Crag", "Bluff", "Slope", "Hillside", "Mountainside",
            "Plateau", "Mesa", "Butte", "Canyon", "Gorge", "Ravine", "Gully", "Glen", "Dell", "Hollow",
            "Basin", "Depression", "Crater", "Caldera", "Vent", "Fissure", "Spring", "Well", "Source", "Origin",
            "Stream", "Creek", "Brook", "Rivulet", "Rill", "Runnel", "Channel", "Canal", "Ditch", "Drain",
            "Pond", "Pool", "Lake", "Lagoon", "Reservoir", "Basin", "Bay", "Cove", "Inlet", "Estuary",
            "Delta", "Mouth", "Shore", "Coast", "Beach", "Strand", "Sand", "Dune", "Reef", "Atoll",
            "Island", "Isle", "Archipelago", "Chain", "Cluster", "Group", "Collection", "Assembly", "Gathering", "Crowd",
            "Flock", "Herd", "Pack", "School", "Swarm", "Colony", "Nest", "Hive", "Burrow", "Den",
            "Lair", "Home", "Habitat", "Territory", "Domain", "Realm", "Kingdom", "Empire", "Nation", "State",
            "Country", "Land", "Region", "Zone", "Area", "District", "Province", "County", "City", "Town",
            "Village", "Hamlet", "Settlement", "Community", "Neighborhood", "Quarter", "Ward", "Block", "Lot", "Plot",
            "Site", "Location", "Position", "Place", "Spot", "Point", "Mark", "Station", "Post", "Stop",
            "Rain", "Snow", "Hail", "Sleet", "Frost", "Ice", "Mist", "Fog", "Cloud", "Sky",
            "Sun", "Moon", "Dawn", "Dusk", "Noon", "Midnight", "Morning", "Evening", "Night", "Day"
        ];

        static readonly string[] Dictionary6 = 
        [
            "Hope", "Dream", "Wish", "Desire", "Want", "Need", "Love", "Hate", "Fear", "Joy",
            "Sad", "Anger", "Rage", "Fury", "Wrath", "Calm", "Peace", "Quiet", "Silence", "Noise",
            "Sound", "Voice", "Word", "Speech", "Talk", "Chat", "Discuss", "Debate", "Argue", "Fight",
            "Battle", "War", "Conflict", "Struggle", "Effort", "Work", "Labor", "Task", "Job", "Duty",
            "Role", "Part", "Share", "Portion", "Piece", "Segment", "Section", "Division", "Department", "Unit",
            "Group", "Team", "Crew", "Staff", "Force", "Power", "Might", "Strength", "Vigor", "Energy",
            "Spirit", "Soul", "Mind", "Brain", "Thought", "Idea", "Concept", "Notion", "Theory", "Hypothesis",
            "Assumption", "Belief", "Faith", "Trust", "Confidence", "Doubt", "Question", "Answer", "Solution", "Problem",
            "Issue", "Matter", "Subject", "Topic", "Theme", "Motif", "Pattern", "Style", "Form", "Shape",
            "Size", "Length", "Width", "Height", "Depth", "Weight", "Mass", "Volume", "Capacity", "Space",
            "Room", "Area", "Zone", "Region", "Territory", "Domain", "Field", "Sphere", "Realm", "World",
            "Universe", "Cosmos", "Reality", "Existence", "Being", "Life", "Death", "Birth", "Growth", "Decay",
            "Change", "Shift", "Move", "Motion", "Action", "Reaction", "Response", "Effect", "Result", "Outcome",
            "Cause", "Reason", "Purpose", "Goal", "Target", "Aim", "Objective", "Mission", "Vision", "Plan",
            "Strategy", "Tactic", "Method", "Approach", "Way", "Path", "Route", "Direction", "Course", "Track",
            "Journey", "Trip", "Travel", "Voyage", "Adventure", "Quest", "Mission", "Expedition", "Tour", "Visit",
            "Arrival", "Departure", "Entry", "Exit", "Start", "Beginning", "Origin", "Source", "Root", "Base",
            "Foundation", "Ground", "Floor", "Level", "Stage", "Phase", "Step", "Grade", "Rank", "Order",
            "Sequence", "Series", "Chain", "Line", "Row", "Column", "List", "Set", "Collection", "Array",
            "Group", "Cluster", "Bundle", "Batch", "Lot", "Heap", "Pile", "Stack", "Queue", "Deck"
        ];

        // Single Random instance (prevents seed duplication issues)
        static readonly Random _random = new();
        // FIXED: Removed 'async' since no await is used
        static void Main(string[] args)
        {
            // Set UTF-8 encoding for proper Unicode display in console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║     SECURE PASSWORD GENERATOR v1.2 (Self-Keyed)      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

            Console.WriteLine("Choose password generation mode:");
            Console.WriteLine("  [1] Manual");
            Console.WriteLine("  [2] Auto");
            Console.Write("\nYour choice (1/2): ");

            string choice = Console.ReadLine();
            string[] words = new string[7];
            Console.Clear();
            // MANUAL MODE: 4 user words + 3 random words
            if (choice == "1")
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  MANUAL MODE                          ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");
                Console.WriteLine("Enter 4 personal words:\n");

                words[0] = GetWordInput("Favorite car brand/model");
                words[1] = GetWordInput("Favorite food/dish");
                words[2] = GetWordInput("Favorite game/hobby");
                words[3] = GetWordInput("KEY WORD (any word)");

                // Fill remaining 3 positions with random words from dictionaries
                words[4] = GetRandomWordFromAllDictionaries();
                words[5] = GetRandomWordFromAllDictionaries();
                words[6] = GetRandomWordFromAllDictionaries();

            }
            
            // AUTO MODE: 6 random words + 1 user key word
            else
            {
                Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
                Console.WriteLine("║                   AUTO MODE                           ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");
                Console.WriteLine("Enter 1 KEY WORD:\n");

                words[0] = GetWordInput("KEY WORD");

                // Fill remaining 6 positions with random words from dictionaries
                for (int i = 1; i < 7; i++)
                {
                    words[i] = GetRandomWordFromAllDictionaries();
                }
            }

            // ENSURE UNIQUENESS: Check for duplicate words
            int attempts = 0;
            while (words.Distinct().Count() != words.Length && attempts < 100)
            {
                attempts++;
                var duplicates = words.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                foreach (var dup in duplicates)
                {
                    var indices = words.Select((x, i) => x == dup ? i : -1).Where(i => i != -1).ToList();
                    for (int i = 1; i < indices.Count; i++)
                    {
                        words[indices[i]] = GetRandomWordFromAllDictionaries();
                    }
                }
            }

            // PASSWORD GENERATION: Using self-keyed obfuscation with random positions
            var result = PSWRDGN.PassWizard(words);
            string password = result.letter;
            var config = result.config;
            Console.Clear();
            // OUTPUT: Display results
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║              GENERATED PASSWORD                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝\n");

            Console.WriteLine($" PASSWORD:\n{password}\n");
            Console.WriteLine($" Length: {password.Length} characters");
            Console.WriteLine($"\n Original Words: {string.Join(" ", config.OriginalWords)}");

            // What user needs to save
            Console.WriteLine("┌────────────────────────────────────────────────────────────────┐");
            Console.WriteLine("│  BACKUP CARD                                                   │");
            Console.WriteLine("├────────────────────────────────────────────────────────────────┤");
            Console.WriteLine($"│  Words: {string.Join(", ", config.OriginalWords),-50}     │");
            Console.WriteLine($"│  Key Position: {config.KeyPosition}                                               │");
            Console.WriteLine($"│  Algorithm: PSWRDGN.PassWizard()                               │");
            Console.WriteLine("└────────────────────────────────────────────────────────────────┘\n");

            // VERIFICATION: Test that password can be verified
            Console.WriteLine("Running verification test...");
            int verifiedPos = PSWRDGN.Guardians(password, config.OriginalWords);
            Console.WriteLine($"Verification: Key position {(verifiedPos >= 0 ? "FOUND" : "FAILED")} (Position: {verifiedPos})\n");

            // OPTIONAL: Generate reverse version for backup
            Console.WriteLine("Generate reverse version for backup? (y/n):");
            string reverseChoice = Console.ReadLine();

            if (reverseChoice?.ToLower() == "y")
            {
                string reversedPassword = string.Join("-", password.Split('-').Reverse());
                Console.WriteLine($"\nREVERSE PASSWORD:\n{reversedPassword}\n");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // HELPER: Get word input from user with validation
        static string GetWordInput(string prompt)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine()?.Trim();

                if (!string.IsNullOrEmpty(input) && input.Length >= 3)
                {
                    return input.ToLower();
                }

                Console.WriteLine("Word must be at least 3 characters!\n");
            }
        }

        // HELPER: Get random word from all 6 dictionaries
        static string GetRandomWordFromAllDictionaries()
        {
            var allDictionaries = new[] { Dictionary1, Dictionary2, Dictionary3,
                                          Dictionary4, Dictionary5, Dictionary6 };

            var dict = allDictionaries[_random.Next(allDictionaries.Length)];
            return dict[_random.Next(dict.Length)].ToLower();
        }
    }
}
 