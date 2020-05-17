package com.CopperPenguin96.SimpleConfig;

import java.util.ArrayList;
import com.CopperPenguin96.SimpleConfig.Properties.*;

public class PropertyList extends ArrayList<ConfigObject> {

	@Override
	public boolean add(ConfigObject property) {
		return super.add(property);
	}
	
	public ConfigObject get(String name) {
		for(ConfigObject prop : this) {
			if (prop.Name.equalsIgnoreCase(name)) {
				return prop;
			}
		}
		
		return null;
	}
}
