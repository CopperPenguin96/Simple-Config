package com.CopperPenguin96.SimpleConfig.Properties;

public class ConfigInt extends ConfigProperty<Integer> {

	/**
	 * Max value for the property.
	 * Set to 0 for not set.
	 */
	public int MaxValue;
	
	/**
	 * Min value for the property.
	 * Set to 0 for not set.
	 */
	public int MinValue;
	
	private boolean _isMax;
	private boolean checkInt(int value) {
		if (MaxValue > 0 && value > MaxValue) {
			_isMax = true;
			return false;
		} else if (MinValue > 0 && value < MinValue) {
			_isMax = false;
			return false;
		}
		
		return true;
	}
	
	public Integer getDefaultValue() {
		return (int) super.getDefaultValue();
	}
	
	public void setDefaultValue(int i) {
		if (checkInt(i)) {
			super.setDefaultValue(i);
		} else {
			String message = _isMax ? "Number is too high" 
					: "Number is too low";
			throw new IndexOutOfBoundsException(message);
		}
	}
	
	public Integer getValue() {
		return (int) super.getValue();
	}
	
	public void setValue(int i) {
		if (checkInt(i)) {
			super.setValue(i);
		} else {
			String message = _isMax ? "Number is too high" 
					: "Number is too low";
			throw new IndexOutOfBoundsException(message);
		}
	}
	
	public ConfigInt(String name, Integer defaultValue) throws Exception {
		super(name, defaultValue);
		// TODO Auto-generated constructor stub
	}
	
	public ConfigInt(String name, int defaultValue, int max) throws Exception {
		this(name, defaultValue);
		MaxValue = max;
	}
	
	public ConfigInt(String name, int defaultValue, int min, int max) throws Exception {
		this(name, defaultValue, max);
		MinValue = min;
	}
	
}
