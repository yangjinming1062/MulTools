from PIL import Image
from numpy import array
from glob import glob
from os import path
from scipy import stats
import sys
'''
将两张有重叠的图片拼接成一张长图，目标效果：123+234 →1234
'''
def FindBorder(imgA,imgB,similar,low,heigh):
    '''
    对比发现两张图片的结合处应该在哪，imgA为主图，从imgB中查找不同的部分进行拼接
    windowMove：窗口每次移动的距离，基本就是1也没什么好调整的了
    *一切运算的前提是认为AB图是可以拼接的，AB有重合则排除重合，没有则首尾相接
    '''
    a = array(imgA)
    b = array(imgB)
    if a.shape[1] != b.shape[1]:#必须同宽的图片
        return

    if a.shape[0] >= b.shape[0]:#A图不比B图短
        A = a[-b.shape[0]:]
        if not (A - b).any():#全是0表示A已经包含B了，直接over
            return 0
    else:#B图更长则意味着肯定有A不包含的，那么从和A等长的部分往上
        B = b[:a.shape[0]]
        if not (a - B).any():#B的头部和A一样，则交换AB就好了啊，此情况传特殊的-1
            return -1

    length = min(a.shape[0],b.shape[0])
    for i in range(1,length,1):#从1开始是因为0的情况在上面已经判断过了
        B = b[:length-i]#B图从下往上缩小范围
        A = a[-B.shape[0]:]#A图对应的从上往下缩小范围
        #if not (A - B).any():#AB对齐，找到了重合区，返回此时的分界位(这种需要的匹配度太强了，查一点点颜色就完蛋了)
        C = A - B
        CS = stats.mode(C.reshape(-1,3))
        if not CS[0][0].any() and (CS[1][0][0] > float(similar)*C.reshape(-1,3).shape[0]):#模糊之前也得保证超过8成的像素点无差异
            C[(C <int(low)) | (C>int(heigh))] = 0
            if C.max() == 0:#增加一点模糊化，针对单个像素点颜色
                return b.shape[0] - B.shape[0]
    
    return b.shape[0]#到最后都没有重合则首尾相接


def CombinePic(imgA,imgB,fileName,similar,low,heigh):
    '''
    以A为主，在A的下面拼接上B图和A图不重合的部分，达到长图的目的
    '''
    a = Image.open(imgA).convert('RGB')
    b = Image.open(imgB).convert('RGB')
    b_heigth = FindBorder(a,b,similar,low,heigh)
    if b_heigth is None:
        return
    if b_heigth == -1:
        a.close()
        b.save(fileName)
        b.close()
        return

    img_new = Image.new('RGB',(a.width, a.height+b_heigth))
    img_new.paste(a,(0,0))
    rect = 0 , b.height - b_heigth , b.width , b.height
    img_new.paste(b.crop(rect),(0,a.height))
    a.close()
    b.close()
    img_new.save(fileName)
    img_new.close()


def DirCombine(dirPath,fileName = 'temp.jpg',picType = '*',similar = 0.85,low = 50,heigh = 200):
    fileList = glob(path.join(dirPath,"*.%s"%picType))#这里应该保证图片按顺序排列好
    if len(fileList) < 2:
        return
    CombinePic(fileList[0],fileList[1],fileName,similar,low,heigh)#先拿出来前两张生成初始目标图
    for img in fileList[2:]:#一张张追加长度
        CombinePic(fileName,img,fileName,similar,low,heigh)


if __name__ == "__main__":
    if len(sys.argv) > 1:
        eval('DirCombine'+str(tuple(sys.argv[1:])))
    else:
        DirCombine("屏幕截图")
    print('拼接完成')