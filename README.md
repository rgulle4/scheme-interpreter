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
- the test `symbol?` for identifying an identifier; the test number?
- the test `number?` for identifying integers
- the binary arithmetic operations `b+`, `b-`, `b*`, `b/`, `b=`, `b<`;
- the list operations `car`, `cdr`, `cons`, `set-car!`, `set-cdr!`, `null?`, `pair?`, `eq?`;
- the test `procedure?` for identifying a closure;
- the I/O functions `read`, `write`, `display`, `newline` (without the optional _port_ argument);
- the functions `eval`, `apply`, and `interaction-environment`.

This should be built on top of [scheme-pp](https://github.com/rgulle4/scheme-pp).  

The parse trees from that project should be used as the internal
data structure for lists. The arithmetic and list operations would
then be simply implemented by the appropriate C# operations on parse
trees.

The following built-in Scheme functions should call parts of this
interpreter:

- `read` calls the parser and returns a parse tree,
- `write` calls the pretty-printer,
- `eval` calls the C# `eval()` function,
- `apply` calls the C# `apply()` function,
- `interaction-environment` returns a pointer to the interpreter's  global environment.

## Environments

See `proj2.pdf` for details.

## Evaluation

See `proj2.pdf` for details.

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
