using System;

namespace SimpleConfig
{
	/// <summary>
	/// Properties for the config.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ConfigProperty<T>
	{
		/// <summary>
		/// The name of the property, how json identifies it
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// The default value of the property.
		/// If the server needs to reset a value, it uses this.
		/// </summary>
		public virtual T DefaultValue { get; set; }

		private T _value;
		/// <summary>
		/// The value of the property.
		/// </summary>
		public virtual T Value
		{
			get => _value;
			set
			{
				if (value == null)
				{
					_value = DefaultValue;
				}
			}
		}

		public ConfigProperty(string name, T defaultValue)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (defaultValue == null) throw new ArgumentNullException(nameof(defaultValue));

			Name = name;
			DefaultValue = defaultValue;
		}

		public void SetDefault()
		{
			Value = DefaultValue;
		}
	}

	/// <summary>
	/// Basic object for the config. Use if you don't know the type. Very rare though.
	/// Extends ConfigProperty - object
	/// </summary>
	public class ConfigProperty : ConfigProperty<object>
	{
		public ConfigProperty(string name, object defaultValue) : base(name, defaultValue)
		{
		}
	}

	public class ConfigInt : ConfigProperty<int>
	{
		/// <summary>
		/// Maximum value for the property.
		/// Set to 0 for not set.
		/// </summary>
		public int MaxValue { get; set; }

		/// <summary>
		/// Minimum value for the property.
		/// Set to 0 for not set.
		/// </summary>
		public int MinValue { get; set; }

		private bool CheckInt(int value, out bool isMax)
		{
			if (MaxValue > 0 && value > MaxValue)
			{
				isMax = true;
				return false;
			}
			else if (MinValue > 0 && value < MinValue)
			{
				isMax = false;
				return false;
			}

			isMax = false;
			return true;
		}

		public override int DefaultValue
		{
			get => base.DefaultValue;
			set
			{
				if (CheckInt(value, out bool isMax)) base.DefaultValue = value;
				else
				{
					string message = isMax ? "Number is too high" : "Number is too low";
					throw new IndexOutOfRangeException(message);
				}
			}
		}

		public override int Value
		{
			get => base.Value;
			set
			{
				if (CheckInt(value, out bool isMax)) base.Value = value;
				else
				{
					string message = isMax ? "Number is too high" : "Number is too low";
					throw new IndexOutOfRangeException(message);
				}
			}
		}

		public ConfigInt(string name, int defaultValue) : base(name, defaultValue)
		{
		}

		public ConfigInt(string name, int defaultValue, int max) : this(name, defaultValue)
		{
			MaxValue = max;
		}

		public ConfigInt(string name, int defaultValue, int min, int max) : this(name, defaultValue, max)
		{
			MinValue = min;
		}
	}

	public class ConfigString : ConfigProperty<string>
	{
		/// <summary>
		/// Maximum value for the property.
		/// Set to 0 for not set.
		/// </summary>
		public int MaxLength { get; set; }

		/// <summary>
		/// Minimum value for the property.
		/// Set to 0 for not set.
		/// </summary>
		public int MinLength { get; set; }

		private bool CheckString(int value, out bool isMax)
		{
			if (MaxLength > 0 && value > MaxLength)
			{
				isMax = true;
				return false;
			}
			else if (MinLength > 0 && value < MinLength)
			{
				isMax = false;
				return false;
			}

			isMax = false;
			return true;
		}

		public override string DefaultValue
		{
			get => base.DefaultValue;
			set
			{
				if (CheckString(value.Length, out bool isMax)) base.DefaultValue = value;
				else
				{
					string message = isMax ? "Too many characters" : "Too few characters";
					throw new IndexOutOfRangeException(message);
				}
			}
		}

		public override string Value
		{
			get => base.Value;
			set
			{
				if (CheckString(value.Length, out bool isMax)) base.Value = value;
				else
				{
					string message = isMax ? "Too many characters" : "Too few characters";
					throw new IndexOutOfRangeException(message);
				}
			}
		}

		public ConfigString(string name, string defaultValue) : base(name, defaultValue)
		{
		}

		public ConfigString(string name, string defaultValue, int max) : this(name, defaultValue)
		{
			MaxLength = max;
		}

		public ConfigString(string name, string defaultValue, int min, int max) : this(name, defaultValue, max)
		{
			MinLength = min;
		}
	}

	/// <summary>
	/// Exists to just exist. Makes coding the config easier.
	/// </summary>
	public class ConfigBool : ConfigProperty<bool>
	{
		public ConfigBool(string name, bool defaultValue) : base(name, defaultValue)
		{
		}
	}
}
