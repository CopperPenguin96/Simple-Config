using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConfig
{
	public class Version
	{
		public static readonly Version App = new Version(1, 0);

		/// <summary>
		/// The first number in the version.
		/// Major API/Graphical changes.
		/// Default = 1.
		/// </summary>
		public int Major;

		/// <summary>
		/// The second number in the version.
		/// Smaller but noticeable changes.
		/// Default = 0.
		/// </summary>
		public int Minor;

		/// <summary>
		/// The third number in the version.
		/// Default = -1 (not visible).
		/// </summary>
		public int Revision;

		/// <summary>
		/// Where there are bugs get fixed and things are corrected.
		/// Default = -1 (not visible). Revision must be set for this one to show.
		/// </summary>
		public int Build;

		/// <summary>
		/// Makes and a new version object. With no params is 1.0.
		/// Major Default is 1.
		/// Minor Default is 0.
		/// Revision/Build Default is -1.
		/// </summary>
		public Version(int maj = 1, int minor = 0, int rev = -1, int bui = -1)
		{
			Major = maj;
			Minor = minor;
			Revision = rev;
			Build = bui;
		}

		public override string ToString()
		{
			string fin = Major + "." + Minor;

			if (Revision < 0) return fin;
			fin += "." + Revision;
			if (Build >= 0)
			{
				fin += "." + Build;
			}

			return fin;
		}

		/// <summary>
		/// Compares the two versions supplied.
		/// Returns 0 if v1 is greater, 1 if v2, 2 if equal
		/// </summary>
		public static byte Compare(Version v1, Version v2)
		{
			if (v1.Major > v2.Major)
			{
				return 0;
			}
			else if (v1.Major < v2.Major)
			{
				return 1;
			}
			else
			{
				if (v1.Minor > v2.Minor)
				{
					return 0;
				}
				else if (v1.Minor < v2.Minor)
				{
					return 1;
				}
				else
				{
					if (v1.Revision > v2.Revision)
					{
						return 0;
					}
					else if (v1.Revision < v2.Revision)
					{
						return 1;
					}
					else
					{
						if (v1.Build > v2.Build)
						{
							return 0;
						}
						else if (v1.Build < v2.Build)
						{
							return 1;
						}
						else
						{
							return 2; // At this point, all points have been checked, so the versions must be the same
						}
					}
				}
			}
		}
	}
}
