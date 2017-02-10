//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

namespace ScriptLab
{
	class Program
	{
		static void Main(string[] args)
		{
			var func = ScriptCompiler.Compile<decimal> ("42M");
			System.Console.WriteLine (func ());
		}
	}
}
