package com.CopperPenguin96.SimpleConfig.Properties;

public class ConfigObject {

	/**
	 * The name of the property, how json identifies it.
	 */
	public String Name;
	
	/**
	 * The default value of the property.
	 * if the library needs to reset a value,
	 * it uses this.
	 */
	private Object _defaultValue;
	
	public Object getDefaultValue() {
		return _defaultValue;
	}
	
	public void setDefaultValue(Object value) {
		_defaultValue = value;
	}
	
	private Object _value;
	
	public Object getValue() {
		return _value;
	}
	
	public void setValue(Object obj) {
		if (obj == null) {
			_value = _defaultValue;
		} else {
			_value = obj;
		}
	}
	
	public ConfigObject(String name, Object defaultValue) throws Exception {
		if (name == null) throw new Exception("name");
		if (defaultValue == null) throw new Exception("defaultValue");
	
		Name = name;
		setDefaultValue(defaultValue);
	}
	
	public void setDefault() {
		setValue(getDefaultValue());
	}
}
