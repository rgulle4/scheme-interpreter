// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree {
    public class StringLit : Node {
        private string stringVal;

        public static bool SHOULD_PRINT_QUOTES = true;
        public static bool SHOULD_PRINT_AT_ALL = true;

        public StringLit(string s) { stringVal = s; }
        public StringLit(string s, bool shouldPrintQuotes) {
            this.stringVal = s;
            StringLit.SHOULD_PRINT_QUOTES = shouldPrintQuotes;
        }
        public StringLit(string s, bool shouldPrintQuotes, bool shouldPrintAtAll) {
            this.stringVal = s;
            StringLit.SHOULD_PRINT_QUOTES = shouldPrintQuotes;
            StringLit.SHOULD_PRINT_AT_ALL = shouldPrintAtAll;
        }

        public override void print(int n) {
            if (!SHOULD_PRINT_AT_ALL)
                return;
            if (SHOULD_PRINT_QUOTES) {
                Printer.printStringLit(n, stringVal);
            } else {
                if (n >= 0) {
                    Console.Write(stringVal.PadLeft(Math.Abs(n)));                 
                    Console.WriteLine();
                } else {
                    Console.Write(stringVal);
                }
            }
        }

        public override bool isString() { return true; }

        public override Node eval(Environment e) { return this; }
    }
}

