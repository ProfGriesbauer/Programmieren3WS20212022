import math as mat
import numpy as np
import matplotlib.pyplot as plt

class MLBattleData:

    def __init__ (self) :

        #Summe großer als halber Maximalwert: Ja/Nein?
        self.nMaxSumNumbers = 5 #Anzahl Zahlen
        self.nMaxSumMaxVal = 10 #Maximaler Wert einer Zahl

        #Bilder: Kreis oder Rechteck, etc.
        self.nPictureSize = 25 #Size*Size=Bildgröße aus 1 und 0

        #NTC-Funktions-Werte vorhersagen (y=A+ax*e^(-b/x)): aus Vorgaben unbekannten Bereich.
        self.nPTCSensorSamples = 100 #https://de.wikipedia.org/wiki/Kaltleiter

    def getMaxSumSampleWithLabel (self) :
        set = []
        label = 0
        sum = 0
        for i in range (self.nMaxSumNumbers):
            val = int(self.nMaxSumMaxVal * np.random.random_sample())
            sum = sum + val
            if sum > int(self.nMaxSumNumbers * self.nMaxSumMaxVal / 2):
                label = 1
            set.append(val)
        return set, label

    def getRandomPTCSamples (self) :
        x = []
        y = []
        for i in range(1, self.nPTCSensorSamples):
            cx = (i + (np.random.random_sample() - 0.5))/10
            x.append(cx)
            y.append(5 + 5 * cx * mat.exp(-5/cx))
        return x, y

    def getRandomFunSamples(self):
        x = []
        y = []
        for i in range(1, self.nPTCSensorSamples):
            cx = (i + (np.random.random_sample() - 0.5)) / 10
            x.append(cx)
            y.append(10 + 10 * cx * mat.sqrt(5 / (cx+1)) + mat.cos(cx*cx*0.1)*10)
        return x, y

    def getPictureSampleWithLabel(self) :
        pic = np.ones(shape=(25, 25, 1)) * (np.random.random_sample()*0.2)
        color = (1 - np.random.random_sample()*0.2)
        label = 0
        if np.random.random_sample() > 0.5 :
            #Kreis
            label = 1
            r = np.random.random_sample() * (self.nPictureSize-5) / 2
            xm = ((self.nPictureSize - 2 * r) * np.random.random_sample()) + r
            ym = ((self.nPictureSize - 2 * r) * np.random.random_sample()) + r
            for i in range(0, 360):
                phi = i / 180.0 * mat.pi
                x = int(xm + r*mat.cos(phi))
                y = int(ym + r*mat.sin(phi))
                pic[x][y][0] = color
        else :
            #Rechteck
            label = 0
            h = int(np.random.random_sample() * (self.nPictureSize-5))
            w = int(np.random.random_sample() * (self.nPictureSize-5))
            xs = int((self.nPictureSize - w) * np.random.random_sample())
            ys = int((self.nPictureSize - h) * np.random.random_sample())
            for i in range(0, w+1) :
                for j in range(0, h) :
                    pic[xs+i][ys][0] = color
                    pic[xs+i][ys+h][0] = color
                    pic[xs][ys+j][0] = color
                    pic[xs+w][ys+j][0] = color
        return pic, label