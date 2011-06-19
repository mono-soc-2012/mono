// ScannerAdapter.cs
// (C) Sergey Chaban (serge@wildwestsoftware.com)
using System;

namespace Mono.ILAsm {
	internal sealed class ScannerAdapter : yyParser.yyInput {
		public ScannerAdapter (ILTokenizer tokenizer)
		{
			BaseStream = tokenizer;
		}

		public ILTokenizer BaseStream { get; private set; }

		//
		// yyParser.yyInput interface
		//
		
		public bool advance ()
		{
			return BaseStream.GetNextToken () != ILToken.EOF;
		}

		public int token ()
		{
			return BaseStream.LastToken.TokenId;
		}

		public object value ()
		{
			return BaseStream.LastToken.Value;
		}
	}
}
