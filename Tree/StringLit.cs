// StringLit -- Parse tree node class for representing string literals

using System;

namespace Tree {
    public class StringLit : Node {
        private string stringVal;

        public bool isQuoted = true;

        public StringLit(string s) { stringVal = s; }
        public StringLit(string s, bool isQuoted) {
            this.stringVal = s;
            this.isQuoted = isQuoted;
        }

        public override void print(int n) {
            if (isQuoted) {
                Printer.printStringLit(n, stringVal);
            } else {
                Console.Write(stringVal.PadLeft(n));
                Console.WriteLine();
            }
        }

        public override bool isString() { return true; }

        public override Node eval(Environment e) { return this; }
    }
}

