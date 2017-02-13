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

			Program.TimeIt1 (10);
			Program.TimeIt2 (10);

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

		private static void TimeIt1(int count)
		{
			System.Console.WriteLine ("Using CSharpScript.Create every time:");

			var watch = new System.Diagnostics.Stopwatch ();

			watch.Start ();
			for (int i = 0; i < count; i++)
			{
				Program.Compile (new Locals ());
			}
			watch.Stop ();

			System.Console.WriteLine ("Time to compile and run is {0} ms", watch.ElapsedMilliseconds / count);
			System.Console.ReadLine ();
		}

		private static void TimeIt2(int count)
		{
			System.Console.WriteLine ("Using CSharpScript.Create once and then only Script.ContineWith:");

			var compiler = new StatefulScriptCompiler<decimal> ();
			compiler.Setup (new Locals ());

			var watch = new System.Diagnostics.Stopwatch ();

			watch.Start ();
			for (int i = 0; i < count; i++)
			{
				var func = compiler.Compile ("@UniversalConstant", new Locals ());
				System.Console.WriteLine (func ());
			}
			watch.Stop ();

			System.Console.WriteLine ("Time to compile and run is {0} ms", watch.ElapsedMilliseconds / count);
			System.Console.ReadLine ();
		}
	}
}
