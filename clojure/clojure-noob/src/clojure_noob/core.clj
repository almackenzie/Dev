(ns clojure-noob.core
  (:gen-class))

(defn -main
  "I don't do a whole lot ... yet."
  [& args]
  (println "I'm a little teapot"))

(+ 1 2 3)

(= (list :a :b :c) '(:a :b :c))

(= (vec :a :b :c) (list :a :b :c) (vec '(:a :b :c)) (vector :a :b :c))
(let [x java.lang.Class] (and (= (class x) x) x))
