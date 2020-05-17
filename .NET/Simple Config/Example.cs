using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleConfig
{
	public class Example
	{
		public static void MyMethod()
		{
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

			// Save it, 1 of 3 ways
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


		}
	}
}