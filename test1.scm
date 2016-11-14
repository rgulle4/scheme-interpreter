;; a test scheme file
(b+ 3 5) ; should return 8

(define (z x) (b+ x y))
(define y 42)
(define x 17)

(z y) ; should return 84

;(eval '(z y) env) ; should return 84, but doesn't work in reference
;(eval '(z y) interaction-environment) ; should return 84, but doesn't work in reference

;; -- symbol? -------------------------- ;;
(symbol? 'foo) ; => #t
;(symbol? foo)  ; => undefined variable, #f
(symbol? 3)    ; => #f
(symbol? 'b+)  ; => #t

;; -- number? -------------------------- ;;
(number? 3) ; => #t
(number? '3) ; => #t
(define three 3)
(number? three) ; => #t
(number? 'three) ; => #f
;(number? zcvio) ; => undefined variable, #f

;; -- binary arithmetic operations ----- ;;
(b+ 5 8) ; => 13
(b- 9 3) ; => 6
(b* 3 8) ; => 24
(b/ 8 4) ; => 2

(b= 3 3) ; => #t
(b= 3 5) ; => #f

(b< 5 3) ; => #t
(b< 3 5) ; => #f

;; -- list operations ------------------ ;;

; TODO: add tests for car 
; TODO: add tests for cdr 
; TODO: add tests for cons 
; TODO: add tests for set-car! 
; TODO: add tests for set-cdr! 
; TODO: add tests for null? 
; TODO: add tests for pair? 
; TODO: add tests for eq?

;; -- procedure? ----------------------- ;;

; TODO: add tests procedure?

;; -- I/O functions -------------------- ;;

; TODO: add tests for read 
; TODO: add tests for write 
; TODO: add tests for display 
; TODO: add tests for newline

;; -- eval, apply, interaction-environment -- ;;

; TODO: add tests for eval

; tests for apply
(define (threetimes y) 
  (b* 3 y))
(apply threetimes '(2))    ; => 6

(define (addthreetimes y) 
  (b+ y (b+ y y)))
(apply addthreetimes '(2)) ; => 6
(addthreetimes 2)          ; => 6

; TODO: add more tests for apply

; TODO: add tests for interaction-environment

;NB: The function `eval` needs to perform the following tasks:

;- extend the environment for variable or function definitions,
;- extend the environment for `let` expressions,
;- update the environment for `set!` assignments,
;- look up variables in the environment,
;- handle the special forms `quote`, `lambda`, `begin`, `if`,
  ;and `cond` (including the `else` keyword in `cond`), and
;- recursively call `apply` for function calls.


;; -- eval, apply, interaction-environment -- ;;

;; example run
;;     cat test1.scm | ./Scheme4101-reference.exe
;; output is
;;     TODO paste this in
