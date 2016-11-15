// Node -- Base class for parse tree node objects

using System;
using System.Collections.Generic;

namespace Tree {
    public class Node : INode {
        // The argument of print(int) is the number of characters to indent.
        // Every subclass of Node must implement print(int).
        public virtual void print(int n) { }

        // The first argument of print(int, bool) is the number of characters
        // to indent.  It is interpreted the same as for print(int).
        // The second argument is only useful for lists (nodes of classes
        // Cons or Nil).  For all other subclasses of Node, the boolean
        // argument is ignored.  Therefore, print(n,p) defaults to print(n)
        // for all classes other than Cons and Nil.
        // For classes Cons and Nil, print(n,TRUE) means that the open
        // parenthesis was printed already by the caller.
        // Only classes Cons and Nil override print(int, bool).
        // For correctly indenting special forms, you might need to pass
        // additional information to print.  What additional information
        // you pass is up to you.  If you only need one more bit, you can
        // encode that in the sign bit of n. If you need additional parameters,
        // make sure that you define the method print in all the appropriate
        // subclasses of Node as well.
        public virtual void print(int n, bool p) {
            print(n);
        }

        // For parsing Cons nodes, for printing trees, and later for
        // evaluating them, we need some helper functions that test
        // the type of a node and that extract some information.

        // These are implemented in the appropriate subclasses to return true.
        public virtual bool isBool()   { return false; }  // BoolLit
        public virtual bool isNumber() { return false; }  // IntLit
        public virtual bool isString() { return false; }  // StringLit
        public virtual bool isSymbol() { return false; }  // Ident
        public virtual bool isNull()   { return false; }  // Nil
        public virtual bool isPair()   { return false; }  // Cons
        public virtual bool isProcedure() { return false; } // BuiltIn, Closure

        // eval() should be implemented in
        // - Special/Begin
        // - Special/Cond
        // - Special/Define
        // - Special/If
        // - Special/Lambda
        // - Special/Let
        // - Special/Quote
        // - Special/Regular
        // - Special/Set
        // - Special/Special (as an abstract method)
        // - Tree/BoolLit
        // - Tree/Cons
        // - Tree/Ident
        // - Tree/IntLit
        // - Tree/StringLit
        public virtual Node eval(Environment env) {
            return nilNodeWithErrorMsg("Error: cant eval this node");
        }

        // apply() should be implemented in
        // - BuiltIn
        // - Closure
        public virtual Node apply(Node args) {
            return nilNodeWithErrorMsg("Error: attempt to call a non-procedure");
        }

        public static List<Node> getArgsList(Node args) {
            List<Node> argsList = new List<Node>();
            while (!args.isNull()) {
                argsList.Add(args.getCar());
                args = args.getCdr();
            }
            return argsList;
        }

        public static int countNodes(Node exp) {
            return countNodes(exp, 0);
        }

        private static int countNodes(Node exp, int count) {
            // Console.Write("--- branch: ");
            // exp.getCar().print(0);
            Node cdr  = exp.getCdr();
            if (cdr.isNull())
                return count;
            return countNodes(cdr, count + 1);
        }

        public static Node nilNodeWithErrorMsg(Object msg) {
            Console.Error.WriteLine(msg);
            return Nil.getInstance();
        }

        // Since C# does not have covariant override, it is not possible
        // for the getCar and getCdr methods to implement the interface
        // methods from INode directly.
        public INode GetCar()  { return getCar(); }
        public INode GetCdr()  { return getCdr(); }

        // Report an error in these default methods and implement them
        // in class Cons.  After setCar, a Cons cell needs to be `parsed' again
        // using parseList.
        public virtual Node getCar() {
            Console.Error.WriteLine("Error: argument of car is not a pair");
            return null;
        }

        public virtual Node getCdr() {
            Console.Error.WriteLine("Error: argument of cdr is not a pair");
            return null;
        }

        public virtual void setCar(Node a) {
            Console.Error.WriteLine("Error: argument of set-car! is not a pair");
        }

        public virtual void setCdr(Node d) {
            Console.Error.WriteLine("Error: argument of set-cdr! is not a pair");
        }
  
        public virtual string getName() { return ""; }

        public virtual int getIntVal() {
            Console.Error.WriteLine("Error: this node isn't an IntLit");
            return 0;
        }
    }
}
