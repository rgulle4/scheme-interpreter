;; a test scheme file
(b+ 3 5) ; should return 8

(define (z x) (b+ x y))
(define y 42)
(define x 17)

(z y) ; should return 84

;; example run
;;     cat test1.scm | ./Scheme4101-reference.exe
;; output is
;;     > 8
;;     > > > > 84
;;     >
