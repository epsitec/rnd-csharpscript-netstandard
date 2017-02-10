//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

namespace ScriptLab
{
	public static class ScriptCompiler
	{
		public static System.Func<T> Compile<T>(string source)
		{
			return () => default (T);
		}
	}
}
