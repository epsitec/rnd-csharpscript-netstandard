//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

namespace ScriptLab
{
	class Program
	{
		static void Main(string[] args)
		{
			Program.Compile (new Mine ());
			Program.Compile (new Locals ());

			//	Throws:
			//
			//	An unhandled exception of type 'Microsoft.CodeAnalysis.Scripting.CompilationErrorException'
			//	occurred in Microsoft.CodeAnalysis.Scripting.dll
			//
			//	Additional information:
			//	(1,1): error CS0012: The type 'Decimal' is defined in an assembly that is not referenced.
			//	You must add a reference to assembly 'System.Runtime, Version=4.0.20.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'.

			Program.Compile (new Globals ());
		}

		private static void Compile(object globals)
		{ 
			var func = ScriptCompiler.Compile<decimal> (@"UniversalConstant", globals);
			System.Console.WriteLine (func ());
		}
	}
}
