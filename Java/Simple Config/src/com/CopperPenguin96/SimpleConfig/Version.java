package com.CopperPenguin96.SimpleConfig;

public class Version {

	public static final Version App = new Version(1, 0);
	
	/**
	 * The first number in the version.
	 * Major API/Graphical changes.
	 * Default = 1
	 */
	public int Major;
	
	/**
	 * The second number in the version.
	 * Smaller but noticeable changes.
	 * Default = 0
	 */
	public int Minor;
	
	/**
	 * The third number in the version.
	 * Default = -1 (not visible)
	 */
	public int Revision;
	
	/**
	 * Where there are bugs that get fixed and things corrected.
	 * Default = -1 (not visible).
	 * Revision must be set for this one to show.
	 */
	public int Build;
	
	/**
	 * Basic version. 1.0
	 */
	public Version() {
		Major = 1;
		Minor = 0;
		Revision = -1;
		Build = -1;
	}
	
	/**
	 * Version = (major).0
	 * @param major
	 */
	public Version(int major) {
		Major = major;
		Minor = 0;
		Revision = -1;
		Build = -1;
	}
	
	/**
	 * Version = (major).(minor)
	 * @param major
	 * @param minor
	 */
	public Version(int major, int minor) {
		Major = major;
		Minor = minor;
		Revision = -1;
		Build = -1;
	}
	
	/**
	 * Version = (major).(minor).(revision)
	 * @param major
	 * @param minor
	 * @param rev
	 */
	public Version(int major, int minor, int rev) {
		Major = major;
		Minor = minor;
		Revision = rev;
		Build = -1;
	}
	
	/**
	 * Version = (major).(minor).(revision).(build)
	 * @param major
	 * @param minor
	 * @param rev
	 * @param bui
	 */
	public Version(int major, int minor, int rev, int bui) {
		Major = major;
		Minor = minor;
		Revision = rev;
		Build = bui;
	}
	
	/**
	 * Returns version object as a string x.x.x.x
	 */
	@Override
	public String toString() {
		String fin = Major + "." + Minor;
		
		if (Revision < 0) return fin;
		fin += "." + Revision;
		if (Build >= 0) {
			fin += "." + Build;
		}
		
		return fin;
	}
	
	/**
	 * Compares the two versions supplied.
	 * Returns 0 if v1 is greater, 1 if v2 is, 2 if equal
	 * @param v1
	 * @param v2
	 * @return
	 */
	public static byte compare(Version v1, Version v2) {
		if (v1.Major > v2.Major) {
			return 0;
		} else if (v1.Major < v2.Major) {
			return 1;
		} else {
			if (v1.Minor > v2.Minor) {
				return 0;
			} else if (v1.Minor < v2.Minor) {
				return 1;
			} else {
				if (v1.Revision > v2.Revision) {
					return 0;
				} else if (v1.Revision < v2.Revision) {
					return 1;
				} else {
					if (v1.Build > v2.Build) {
						return 0;
					} else if (v1.Build < v2.Build) {
						return 1;
					} else {
						return 2; // At this point, all points have been checked, so the versions must be the same
					}
				}
			}
		}
	}
}
