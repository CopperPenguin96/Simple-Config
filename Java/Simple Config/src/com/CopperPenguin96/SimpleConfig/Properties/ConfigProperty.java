package com.CopperPenguin96.SimpleConfig.Properties;

/**
 * Properties for the config
 * @author CopperPenguin96
 *
 * @param <T> Type
 */
public class ConfigProperty<T> extends ConfigObject {
	
	public T DefaultValue;
	
	private T _value;
	
	@Override
	public T getValue() {
		return _value;
	}
	
	public void setItemValue(T value) {
		try {
			_value = value;
		} catch (Exception ex) {
			setDefault();
		}
	}
	
	public ConfigProperty(String name, T defaultValue) throws Exception {
		super(name, defaultValue);
	}
}
