// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree {
    public class Define : Special {
        public Define() { }
        
        // TODO: implement eval
        public override Node eval(Node exp, Environment env) {
            Console.Error.WriteLine("TODO: eval not implemented");
            return Nil.getInstance();
        }
        
        public override void print(Node t, int n, bool p) {
            Printer.printDefine(t, n, p);
        }
    }
}


