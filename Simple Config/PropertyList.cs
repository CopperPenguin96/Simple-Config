using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConfig
{
	public class PropertyList : List<ConfigProperty>
	{
		public new void Add(ConfigProperty property)
		{
			base.Add(property);
		}

		public ConfigProperty Get(string name)
		{
			return this.FirstOrDefault(prop 
				=> string.Equals(prop.Name, 
					name, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
