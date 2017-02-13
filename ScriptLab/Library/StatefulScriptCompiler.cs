//	Copyright © 2017, EPSITEC SA, CH-1400 Yverdon-les-Bains, Switzerland
//	Author: Pierre ARNAUD, Maintainer: Pierre ARNAUD

using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace ScriptLab
{
	public class StatefulScriptCompiler<T>
	{
		public void Setup(object globals)
		{
			var options = ScriptOptions.Default;
			this.script = CSharpScript.Create<T> ($"default ({typeof (T).FullName})", options: options, globalsType: globals.GetType ());
			var runner = this.script.CreateDelegate ();
		}

		public System.Func<T> Compile(string source, object globals)
		{
			this.script = this.script.ContinueWith<T> ($"return {source};");
			var runner = script.CreateDelegate ();
			return () => runner (globals).Result;
		}

		private Script<T> script;
	}
}
