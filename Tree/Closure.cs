// Closure -- the data structure for function closures

// Class Closure is used to represent the value of lambda expressions.
// It consists of the lambda expression itself, together with the
// environment in which the lambda expression was evaluated.

// The method apply() takes the environment out of the closure,
// adds a new frame for the function call, defines bindings for the
// parameters with the argument values in the new frame, and evaluates
// the function body.

using System;

namespace Tree {
    public class Closure : Node {
        private Node fun;          // a lambda expression
        private Environment env;   // the environment in which
                                   // the function was defined

        public Closure(Node f, Environment e) { fun = f;  env = e; }

        public Node getFun() { return fun; }
        public Environment getEnv() { return env; }

        // The method isProcedure() should be defined in
        // class Node to return false.
        public override bool isProcedure() { return true; }

        public override void print(int n) {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.WriteLine("#{Procedure");
            if (fun != null)
                fun.print(Math.Abs(n) + 4);
            for (int i = 0; i < Math.Abs(n); i++)
                Console.Write(' ');
            Console.WriteLine('}');
        }

        // apply() should be overridden only in classes BuiltIn and Closure.
        // In Closure, apply() needs to perform the following tasks:
        //   - extract the environment out of the closure
        //   - add a new frame to the environment that binds the parameters 
        //     to the corresponding argument values.
        //   - recursively call eval for the fn body and the new environment.
        public override Node apply(Node args) {
            return new StringLit("Error: Closure.apply not yet implemented");
        }
    }    
}
