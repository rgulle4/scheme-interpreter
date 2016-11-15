(display "------ should be => a -----------")
(display "(cond   ((b< 2 3) 'a)    ((b< 3 2) 'b))")
(cond 
  ((b< 2 3) 'a)
  ((b< 3 2) 'b))

(display "------ should be => c -----------")
(display "(cond ")
(display "  ((b< 3 3) 'a)")
(display "  ((b< 3 3) 'b)")
(display "  (else 'c))")

(cond 
  ((b< 3 3) 'a)
  ((b< 3 3) 'b)
  (else 'c))

(display "------ should be => nothing -----------")
(cond 
  ((b< 3 3) 'a)
  ((b< 3 3) 'b))

;; (if (b< 3 5) 
;;   'less
;;   'true)

;; (display "------ should be => c -----------")

;; (cond 
;;   ((b< 3 3) 'a)
;;   ((b< 3 3) 'b)
;;   ((b= 3 3) 'c)
;;   (else     'd)
