using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace SimpleConfig
{
	/// <summary>
	/// Root of the configuration library. Saves and Loads. 
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// The version of the library
		/// </summary>
		public Version Version
		{
			get
			{
				int major = GetAssemName().Version.Major;
				int minor = GetAssemName().Version.Minor;
				int bui = GetAssemName().Version.Build;
				int rev = GetAssemName().Version.Revision;
				return Version.Parse(
					$"{major}.{minor}.{bui}.{rev}"
					);
			}
		}

		/// <summary>
		/// Gets the assembly so we can call the version
		/// </summary>
		/// <returns></returns>
		private AssemblyName GetAssemName()
		{
			Assembly assem = Assembly.GetExecutingAssembly();
			return assem.GetName();
		}

		public ConfigProperty GetProperty(string name)
		{
			// Loops over each config item and then finds the correct one by name
			foreach (var prop in Properties.Where(prop => string.Equals(prop.Name, name, StringComparison.CurrentCultureIgnoreCase)))
			{
				return prop;
			}

			throw new Exception("Config property does not exist");
		}

		/// <summary>
		/// List of properties added
		/// </summary>
		public List<ConfigProperty> Properties = new List<ConfigProperty>();

		/// <summary>
		/// Loads the default values of all properties
		/// </summary>
		public void LoadDefaults()
		{
			for (int x = 0; x <= Properties.Count - 1; x++)
			{
				Properties[x].SetDefault();
			}
		}

		/// <summary>
		/// Saves to the specified json file
		/// </summary>
		/// <param name="dir">File you want to save to</param>
		/// <param name="formatting">Set to Formatting.Indented for pretty printing</param>
		public void Save(string dir, Formatting formatting = Formatting.None)
		{
			string json = JsonConvert.SerializeObject(this, formatting);
			var writer = File.CreateText(dir);
			writer.WriteLine(json);
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Tries to save to the specified file
		/// </summary>
		/// <param name="dir">File you want to save to</param>
		/// <param name="formatting">Set to Formatting.Indented for pretty printing</param>
		/// <param name="ex">If an exception occurs</param>
		/// <returns>Returns true/false if it succeeds/fails</returns>
		public bool TrySave(string dir, Formatting formatting, out Exception ex)
		{
			try
			{
				Save(dir, formatting);
				ex = null;
				return true;
			}
			catch (Exception e)
			{
				ex = e;
				return false;
			}
		}

		/// <summary>
		/// Loads the configuration
		/// </summary>
		/// <param name="dir">File to load the configuration from</param>
		/// <param name="loadingDefaults">True if file doesn't exist.</param>
		/// <returns>Loaded config</returns>
		public static Configuration Load(string dir, out bool loadingDefaults)
		{
			if (!File.Exists(dir))
			{
				Configuration config = new Configuration();
				loadingDefaults = true;
				config.LoadDefaults();
				return config;
			}

			string json = File.ReadAllText(dir);
			Configuration configuration =
				JsonConvert.DeserializeObject<Configuration>(json);
			loadingDefaults = false;
			return configuration;
		}

		/// <summary>
		/// Tries to load the configuration
		/// </summary>
		/// <param name="dir">File to load the configuration from</param>
		/// <param name="config">The configuration</param>
		/// <param name="loadingDefaults">True if file doesn't exist.</param>
		/// <param name="ex">Exception that occurs if it fails.</param>
		/// <returns>Returns true/false if it succeeds/fails</returns>
		public static bool TryLoad(string dir, out Configuration config, out bool loadingDefaults, out Exception ex)
		{
			try
			{
				config = Load(dir, out loadingDefaults);
				ex = null;
				return true;
			}
			catch (Exception e)
			{
				config = null;
				loadingDefaults = false;
				ex = e;
				return false;
			}
		}
	}
}
