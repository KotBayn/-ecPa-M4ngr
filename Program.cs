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


        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

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
                string io = Dictionary3[rnd.Next(Dictionary3.Length)];
                string rp = Dictionary4[rnd.Next(Dictionary4.Length)];
                string tp = Dictionary5[rnd.Next(Dictionary5.Length)];
                string mn = Dictionary6[rnd.Next(Dictionary6.Length)];

                box = [ky, bw, rp, tp, io, mn];

            }

            // Cicle through each word in the password array
            for (int i = 0; i < box.Length; i++)
            {
                box[i] = PSWRDGN.FullMap(box[i]);
            }
            Random random = new();
            //Mix the array to make it more secure
            // making sure to add 3 more random words from the dictionaries
            Array.Resize(ref box, box.Length + 2);
            string p1 = Dictionary1[random.Next(Dictionary1.Length)];
            string p2 = Dictionary2[random.Next(Dictionary2.Length)];
            string p3 = Dictionary3[random.Next(Dictionary3.Length)];
            string p4 = Dictionary4[random.Next(Dictionary4.Length)];
            string p5 = Dictionary5[random.Next(Dictionary5.Length)];
            string p6 = Dictionary6[random.Next(Dictionary6.Length)];
            box[box.Length - 2] = PSWRDGN.FullMap(p1);
            box[box.Length - 1] = PSWRDGN.FullMap(p2);
            box[box.Length - 2] = PSWRDGN.FullMap(p3);
            box[box.Length - 1] = PSWRDGN.FullMap(p4);
            box[box.Length - 2] = PSWRDGN.FullMap(p5);
            box[box.Length - 1] = PSWRDGN.FullMap(p6);
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