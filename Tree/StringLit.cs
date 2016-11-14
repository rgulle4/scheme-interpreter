// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree {
    public class StringLit : Node {
        private string stringVal;

        public static bool QUOTES_SHOULD_BE_PRINTED = true;
        public static bool SHOULD_PRINT_AT_ALL = true;

        public StringLit(string s) { stringVal = s; }
        public StringLit(string s, bool quotesShouldBePrinted) {
            this.stringVal = s;
            StringLit.QUOTES_SHOULD_BE_PRINTED = quotesShouldBePrinted;
        }

        public override void print(int n) {
            if (!SHOULD_PRINT_AT_ALL)
                return;
            if (QUOTES_SHOULD_BE_PRINTED) {
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

