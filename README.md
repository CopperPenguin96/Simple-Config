# Simple Config
Simple configuration library for your applications by _CopperPenguin96_ written in C#
**Java and C++ version(s) coming soon**
 
## Why?
I began to notice a lot of applications have configs (kind of obvious, right?) but I feel like coding a simple and elegent config for everyone could save everyone a big amount of time! They can focus more on what's important in their software than worrying about an old dry config.
 
That's where this library comes in! With predefined property types and the ability to add properties with custom types, it does all the grunt work for you by saving your config to an elegent .json file and will load it for you to!
 
## How?
 
Here is an example of how to use this tool. This example covers everything from saving, loading, adding properties, and displaying properties. From Example.cs

    // Initiate the config
    Configuration config = new Configuration();
    
    // Create some properties
    // new ConfigBool(name, defaultValue)
    ConfigBool autoSave = new ConfigBool("auto-save", false);
    
    // new ConfigString(name, defaultValue, min, max)
    ConfigString userName = new ConfigString("username", "joe12345", 6, 16);
    
    // new ConfigString(name, defaultValue, max)
    ConfigString firstName = new ConfigString("first-name", "Billy", 30);
    
    // Follows same parameters as string
    ConfigInt age = new ConfigInt("age", 25, 99);
    
    // Now let's create the user
    autoSave.Value = true;
    userName.Value = "billyNotBob123";
    firstName.Value = "BillyBob";
    age.Value = 69;
    
    // Set the properties
    config.Properties.Add(autoSave);
    config.Properties.Add(userName);
    config.Properties.Add(firstName);
    config.Properties.Add(age);
    
    // Save it, 1 of 2 ways
    config.Save("config.json", Formatting.Indented); // For pretty json printing
    config.Save("config.json");
    
    // load it
    config = Configuration.Load("config.json", out bool defaults);
    
    if (defaults) // file doesn't exist or something went wrong.
    {
    	config.LoadDefaults(); // Loads the defaults
    }
    
    // Display a property.
    ConfigInt savedAge = (ConfigInt) config.GetProperty("age");
    ConfigString savedUsername = (ConfigString) config.GetProperty("username");
    
    Console.WriteLine(savedAge.Value + " is " + savedAge.Value + " years old");


 
## Issues
 
This is a relatively small library, so there shouldn't be many issues, but if there is, you are more than welcome to submit them! I accept critism and will carefully consider things I feel to be real issues. Just be polite and don't be rude.
 
## Contributing
 
Think of something that I didn't? Do a pull request! I'll consider your work! I would be honored if you wanted to help. My goal is to make this the defacto for programmers to use when making their programs!

 


