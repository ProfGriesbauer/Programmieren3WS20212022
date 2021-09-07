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

"""
#####PTC#####
traindata = []
trainlabels = []
fig, ax = plt.subplots(1)

xs, ys = do.getRandomFunSamples()
for i in range(0, len(xs)-1):
    traindata.append([xs[i]])
    trainlabels.append([ys[i]])

testdata = []
testlabels = []

xs, ys = do.getRandomFunSamples()
ax.plot(xs, ys, label='test')
for i in range(0, len(xs)-1, 4):
    testdata.append([xs[i]])
    testlabels.append([ys[i]])

#print (traindata)
#print (trainlabels)

model = kr.Sequential()
#model.add(LSTM(NUMBERS_SIZE*2))
model.add(Dense(1))
model.add(Dense(25*2))
model.add(Dense(25*25*2, activation='relu'))
model.add(Dense(25*25*4))
model.add(Dense(25*25*2,  activation='relu'))
model.add(Dense(25*2))
model.add(Dense(1))

model.compile(optimizer='adam',
              loss='mean_squared_error',
              metrics=[kr.losses.mean_squared_error])
model.fit(np.array(traindata), np.array(trainlabels), epochs=16, batch_size=2)
print(model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1))
print("**************************************************")
prediction = model.predict(np.array(testdata), batch_size=1)
xsp = []
ysp= []
for i in range(0, len(testdata)):
    print("Prediction", prediction[i][0], testdata[i][0], " - Label ", testlabels[i])
    xsp.append(testdata[i][0])
    ysp.append(prediction[i][0])
ax.plot(xsp, ysp, label='pred')
plt.draw()
plt.show()
model.save("MaxSumModels/GriesbauerPTCModel.model")
"""


#####Pictures#####
traindata = []
trainlabels = []
for i in range (0, 1000):
    pic, label = do.getPictureSampleWithLabel()
    traindata.append(pic)
    trainlabels.append([label])

testdata = []
testlabels = []
for i in range (0, 10):
    pic, label = do.getPictureSampleWithLabel()
    testdata.append(pic)
    testlabels.append([label])

#print (traindata)
#print (trainlabels)

model = kr.Sequential()
#model.add(LSTM(NUMBERS_SIZE*2))
model.add(Conv2D(32, (4,4), activation='relu'))
#model.add(Conv2D(64, (2,2), activation='sigmoid'))
#model.add(Conv2D(128, (1,1), activation='sigmoid'))
model.add(MaxPooling2D((4,4)))
model.add(Flatten())
model.add(Dense(25*25))
model.add(Dense(25))
model.add(Dense(1))

model.compile(optimizer='adam',
              loss='mean_squared_error',
              metrics=[kr.losses.mean_squared_error])
model.fit(np.array(traindata), np.array(trainlabels), epochs=16, batch_size=8)
print(model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1))
print("**************************************************")
prediction = model.predict(np.array(testdata), batch_size=1)
for i in range(0, len(testdata)):
    print("Prediction", prediction[i], " - Label ", testlabels[i])

model.save("PicModels/GriesbauerPicModel.model")


"""
#####MAX Number#####
traindata = []
trainlabels = []
test = 0
for i in range (0, 1000):
    set, label = do.getMaxSumSampleWithLabel()
    test = test + label
    traindata.append(set)
    trainlabels.append([label])

testdata = []
testlabels = []
for i in range (0, 10):
    set, label = do.getMaxSumSampleWithLabel()
    testdata.append(set)
    testlabels.append([label])

print (traindata)
print (trainlabels)
print (test)

NUMBERS_SIZE = 5
model = kr.Sequential()
#model.add(LSTM(NUMBERS_SIZE*2))
model.add(Dense(NUMBERS_SIZE, input_dim=NUMBERS_SIZE))
#model.add(RepeatVector(NUMBERS_SIZE))
model.add(Dense(NUMBERS_SIZE*NUMBERS_SIZE))
model.add(Dense(NUMBERS_SIZE*NUMBERS_SIZE*NUMBERS_SIZE))
model.add(Dense(NUMBERS_SIZE*NUMBERS_SIZE*NUMBERS_SIZE*NUMBERS_SIZE))
model.add(Dense(NUMBERS_SIZE*NUMBERS_SIZE*NUMBERS_SIZE))
#model.add(Flatten())
model.add(Dense(NUMBERS_SIZE*NUMBERS_SIZE))
model.add(Dense(NUMBERS_SIZE))
model.add(Dense(1))

model.compile(optimizer='adam',
              loss='mean_squared_error',
              metrics=[kr.losses.mean_squared_error])
model.fit(np.array(traindata), np.array(trainlabels), epochs=10, batch_size=1)
print(model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1))
print("**************************************************")
prediction = model.predict(np.array(testdata), batch_size=1)
for i in range(0, len(testdata)):
    print("Prediction", prediction[i], " - Label ", testlabels[i])

model.save("MaxSumModels/GriesbauerMaxSumModel.model")
"""