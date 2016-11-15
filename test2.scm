(cond ((> 3 2) 'greater)
      ((< 3 2) 'less))
          
; =>  greater

(cond ((> 3 3) 'greater)
      ((< 3 3) 'less)
      (else 'equal))

; =>  equal
