
#main.py
# encoding: utf-8
import numpy as np
import multi
import sys
 
def func(a,b):
    result=np.sqrt(multi.multiplication(int(a),int(b)))
    #print (" hhhh ")
    return result
 
 
if __name__ == '__main__':
    result1=func(sys.argv[1],sys.argv[2])
    #result1="1111"
    print(result1,"a----------------------a")
    

