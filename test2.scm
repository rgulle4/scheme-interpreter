(display "------ should be => a -----------")
(cond 
  ((b< 2 3) 'a)
  ((b< 3 2) 'b))

;; (display "------ should be => c -----------")
          
;; (cond 
;;   ((b< 3 3) 'a)
;;   ((b< 3 3) 'b)
;;   (else 'c))

;; (display "------ should be => c -----------")

;; (cond 
;;   ((b< 3 3) 'a)
;;   ((b< 3 3) 'b)
;;   ((b= 3 3) 'c)
;;   (else     'd)
