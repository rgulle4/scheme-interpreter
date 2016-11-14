# A scheme interpreter

by: Roy Gullem, Vincent Rodomista

An interpreter for a subset of Scheme in C#. Reads a Scheme
program from stdin and prints it properly indented to stdout.

Usage with a Scheme file:

```
    make && cat test1.scm | mono Scheme4101.exe
```

Or, usage as a REPL

```
    make && cat | mono Scheme4101.exe
```

## What it should do

This interpreter should implement

- symbols, 32 bit integers, booleans, strings, lists, and closures;
- the test `symbol?` for identifying an identifier;
- the test `number?` for identifying integers
- the binary arithmetic operations `b+`, `b-`, `b*`, `b/`, `b=`, `b<`;
- the list operations `car`, `cdr`, `cons`, `set-car!`, `set-cdr!`, `null?`, `pair?`, `eq?`;
- the test `procedure?` for identifying a closure;
- the I/O functions `read`, `write`, `display`, `newline` (without the optional _port_ argument);
- the functions `eval`, `apply`, and `interaction-environment`.

This is built on top of working pretty-printer libraries `SPP.{dll,netmodule}`.

The parse trees from `SPP` should be used as the internal data
structure for lists. The arithmetic and list operations would then
be simply implemented by the appropriate C# operations on parse
trees.

The following built-in Scheme functions should call parts of this
interpreter:

- `read` calls the parser and returns a parse tree,
- `write` calls the pretty-printer,
- `eval` calls the C# `eval()` function,
- `apply` calls the C# `apply()` function,
- `interaction-environment` returns a pointer to the interpreter's  global environment.

## Environments

For keeping track of the values of variables during evaluation, we
need a data structure for storing these values. That's the
environment. Scheme is a language with nested scopes. Given the
function definition:

```scheme
    (define (z x) (+ x y))
    (define y 42)
    (define x 17)
```

When evaluating the body of the function call `(z y)`, we need to
look for the values of ` +,` `x`, and `y`. For each variable, we
first look in the local function scope, then in the outer file
scope, then in the scope containing the built-in function
definitions. We will find `x` in the function scope, `y` in file
scope, and `+ `in built-in scope `(+` is nothing special, it's a
regular variable which has a function as its value). The environment
data structure needs to be designed to allow this search.

... _(More details in `proj2.pdf`)_ ...

## Evaluation

For evaluating Scheme programs, you will implement the two mutually
recursive functions `eval` and `apply`. The main evaluation
function, `eval`, takes two arguments, a Scheme expression and an
environment. E.g., the call

```scheme
    (eval '(z y) env)
```

where `env` is defined as above, will result in the value `84`.

The function `eval` needs to perform the following tasks:

- extend the environment for variable or function definitions,
- extend the environment for `let` expressions,
- update the environment for `set!` assignments,
- look up variables in the environment,
- handle the special forms `quote`, `lambda`, `begin`, `if`, and `cond` (including the `else` keyword in `cond`), and
- recursively call `apply` for function calls.

Note that some of the special forms as well as some of the built-in
functions do not return a value.

... _(More details in `proj2.pdf`)_ ...

## Top-Level Loop

The Scheme interpreter `eval` should be run with a top-level loop
such as the following:

```scheme
    (define (Scheme)
      (display "Scheme 4101> ")
      (let ((input (read)))
        (if (not (eof-object? input))
        (begin
          (write (eval input global-environment))
          (newline)
          (Scheme))
        (newline))))
```

This top-level loop could either be implemented directly in C# or
read from a file of Scheme definitions. It'll be easiest to
implement this loop directly in your main function.

## References

The previous [scheme-pp](https://github.com/rgulle4/scheme-pp)
project will probably helpful, but not sure.

The `Scheme/` directory has an interpreter implemented in Scheme.
There's psuedocode, actual code, and a walkthrough of a sample
execution.

Also, some files of interest (not in this repo):

| File(s)               | Description                      |
| --------------------- | -------------------------------- |
| `proj2.pdf`           | Background info                  |
| `prog2/Csharp/`       | Skeleton code                    |
| `proj2-uml.pdf`       | UML diagram of the skeleton code |
| `prog2.bin/`          | Reference binaries               |
