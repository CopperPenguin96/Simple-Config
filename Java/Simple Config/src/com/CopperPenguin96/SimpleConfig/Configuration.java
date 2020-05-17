package com.CopperPenguin96.SimpleConfig;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;

import com.CopperPenguin96.SimpleConfig.Properties.*;
import com.google.gson.*;

/**
 * Root of the config library. Saves and loads
 * @author CopperPenguin96
 *
 */
public class Configuration {
	/**
	 * Gets the version of the config
	 * @return
	 */
	public Version getVersion() {
		return new Version(1, 0);
	}
	
	/**
	 * Gets the property specified.
	 * @param name The name assigned to the property.
	 * @return Returns the ConfigObject
	 * @throws Exception 
	 */
	public ConfigObject getProperty(String name) throws Exception {
		ConfigObject property = Properties.get(name);
		if (property != null) return property;
		throw new Exception("Config property does not exist.");
	}
	
	public PropertyList Properties = new PropertyList();
	
	public void loadDefaults() {
		for (int x = 0; x <= Properties.size() - 1; x++) {
			ConfigObject obj = Properties.get(x);
			obj.setDefault();
			Properties.set(x, obj);
		}
	}
	
	/**
	 * Saves to the specified json file
	 * @param dir
	 * @throws IOException 
	 */
	public void save(String dir) throws IOException {
		Gson gson = new GsonBuilder().setPrettyPrinting().create();
		String json = gson.toJson(this);
		File file = new File(dir);
		if (!file.exists()) file.createNewFile();
		FileWriter writer = new FileWriter(dir);
		writer.write(json);
		writer.flush();
		writer.close();
	}
	
	public static boolean LoadingDefaults = false;
	/**
	 * Loads the configuration
	 */
	public static Configuration load(String dir) throws IOException {
		File file = new File(dir);
		if (!file.exists()) {
			Configuration config = new Configuration();
			LoadingDefaults = true;
			config.loadDefaults();
			return config;
		}
		
		String json = Files.readString(Path.of(file.getPath()));
		Gson gson = new Gson();
		Configuration c = gson.fromJson(json, Configuration.class);
		LoadingDefaults = true;
		return c;
	}
}
