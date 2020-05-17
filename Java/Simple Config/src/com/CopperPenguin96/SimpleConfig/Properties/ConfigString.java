package com.CopperPenguin96.SimpleConfig.Properties;

public class ConfigString extends ConfigProperty<String> {

	/**
	 * Max value for the property
	 */
	public int MaxLength;
	
	/**
	 * Min value for the property
	 */
	public int MinLength;
	
	private boolean _isMax;
	private boolean checkString(int value) {
		if (MaxLength > 0 && value > MaxLength) {
			_isMax = true;
			return false;
		} else if (MinLength > 0 && value < MinLength) {
			_isMax = false;
			return false;
		}
		
		return true;
	}
	
	public String getDefaultValue() {
		return (String) super.getDefaultValue();
	}
	
	public void setDefaultValue(String val) {
		if (checkString(val.length())) {
			super.setDefaultValue(val);
		} else {
			String message = _isMax ? "Too many characters" 
					: "Too few characters";
			throw new IndexOutOfBoundsException(message);
		}
	}
	
	public String getValue() {
		return (String) super.getValue();
	}
	
	public void setValue(String val) {
		if (checkString(val.length())) {
			super.setValue(val);
		} else {
			String message = _isMax ? "Too many characters" 
					: "Too few characters";
			throw new IndexOutOfBoundsException(message);
		}
	}
	
	public ConfigString(String name, String defaultValue) throws Exception {
		super(name, defaultValue);
		// TODO Auto-generated constructor stub
	}
	
	public ConfigString(String name, String defaultValue, int max) throws Exception {
		this(name, defaultValue);
		MaxLength = max;
	}
	
	public ConfigString(String name, String defaultValue, int min, int max) throws Exception {
		this(name, defaultValue, max);
		MinLength = min;
	}
}
