import MLBattleData as mlbd
import matplotlib.pyplot as plt
import numpy as np
import keras as kr
import os as os
import tensorflow as tf
from keras.models import Sequential
from keras.layers import Dense, RepeatVector, Reshape, Conv2D, MaxPooling2D, Flatten, LSTM
import matplotlib.pyplot as plt

do = mlbd.MLBattleData()

#####PTC#####
traindata = []
trainlabels = []
testdata = []
testlabels = []
fig, ax = plt.subplots(1)

xs, ys = do.getRandomFunSamples()
for i in range(0, len(xs)-1):
###############
#########...Etc.
###############

model = kr.Sequential()
###############
#########...Etc.
###############

model.compile(optimizer='adam'

###############
#########...Etc.
###############
ax.plot(xsp, ysp, label='pred')
plt.draw()
plt.show()
model.save("MaxSumModels/GriesbauerPTCModel.model")

###############
#########...Andere Modelle, etc.
###############
