(display "/ -- Test1 ------------------ ")
(display "/ print the integer constant 42 ")
(display 42)
(write 42)


(display "/ -- Test2 ------------------ ")
(display "/ print the list '(Hello World!)")
(display '("Hello" "World!"))
(write '("Hello" "World!"))


(display "/ -- Test3 ------------------ ")
(display "/ the factorial function")
(define (fac n)
  (if (b= n 0)
    1
    (b* n (fac (b- n 1)))))

(fac 5)
