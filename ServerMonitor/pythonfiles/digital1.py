# encoding: utf-8

def sum(a,b):
    print ('digita1 aaa ')
    return a+b


def regSearch(module):
    import re
    str="\\b[-a-z]*"+module+"\\b"
    str="\\b[-a-z]*"+module+"\\b"
    print (str)
    p=re.compile(str)
    with open("city.txt") as f:
         print ("opened")
         result = re.findall(p,f.read())
         print ("lll")
         print (result)
         return sorted(set(result))
    return 99
#不知道为什么，这段代码如果添加了汉字注释 加上# encoding: utf-8就可以了
#在vs里面就报错。
#其中包括了搜索相关单词
#对结果去重（set（result））
#然后排序几项。sorted（）

def regSearch1(filename,findstr):
    import re
    import sys
    f = open(filename,'r')
    #f = open("e:\\city.txt",'r')
    la = f.encoding
    print ( "python++" )
    print ( la )
    sss = f.read()
    print (sss)
    sss1=sss.decode('utf-8')
    print (sss1)

    #print(filename)
    #print(type(filename))
    #print(findstr)
    #print(type(findstr))
    print (type(sss))
    print (type(sss1))
    #str="\\b[-a-z]*."+"北"+".\\b"
    str="\\b[-a-z]*."+ findstr +".\\b"
    print ( str )
    p=re.compile(str,re.S)
    b=p.findall(sss1)
    print ( b )
    i=0
    for v in b:
        #c=v.decode('utf-8')
        i=i+1
        c=v
        print (i," ",v,c)
        print (v)
    f.close()
    result=sorted(set(b))
    print (result)
    print ( "--python" )
    return result