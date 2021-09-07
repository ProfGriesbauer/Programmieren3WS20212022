import MLBattleData as mlbd
import matplotlib.pyplot as plt
import numpy as np
import keras as kr
import os as os
import tensorflow as tf
import tkinter as tk


###Window###
window = tk.Tk()
window.title("ML Battle Arena")
window.geometry("1400x700")

framePTC = tk.Frame(master=window, width = 150, height=200, borderwidth=2, relief=tk.SOLID, bg="white")
framePTC.pack(fill=tk.BOTH, side=tk.LEFT, expand=True)
labelPTC = tk.Label(master=framePTC, text="PTC Fitting", font='Arial 15 bold', bg="white")
labelPTC.pack()
subFramesPTC = []
for file in os.listdir("PTCModels"):
    if file.endswith(".model"):
        subFrame = tk.Frame(master=framePTC, width=150, height=50, borderwidth=1, relief=tk.SOLID)
        subFrame.pack(fill=tk.BOTH, expand=True)
        subLabel = tk.Label(master=subFrame, text=file.title(), font='Arial 12 bold')
        subLabel.pack()
        subText = tk.Text(master=subFrame)
        subText.configure(height=1, width=1)
        subText.pack(fill=tk.BOTH, expand=True)
        subFramesPTC.append([file, subText])

frameMaxSum = tk.Frame(master=window, width=150, height=200, borderwidth=2, relief=tk.SOLID, bg="white")
frameMaxSum.pack(fill=tk.BOTH, side=tk.LEFT, expand=True)
labelMaxSum = tk.Label(master=frameMaxSum, text="Maximal Sum", font='Arial 15 bold', bg="white")
labelMaxSum.pack()
subFramesMaxSum = []
for file in os.listdir("MaxSumModels"):
    if file.endswith(".model"):
        subFrame = tk.Frame(master=frameMaxSum, width=150, height=50, borderwidth=1, relief=tk.SOLID)
        subFrame.pack(fill=tk.BOTH, expand=True)
        subLabel = tk.Label(master=subFrame, text=file.title(), font='Arial 12 bold')
        subLabel.pack()
        subText = tk.Text(master=subFrame)
        subText.configure(height=1, width=1)
        subText.pack(fill=tk.BOTH, expand=True)
        subFramesMaxSum.append([file, subText])

framePic = tk.Frame(master=window, width=150, height=200, borderwidth=2, relief=tk.SOLID, bg="white")
framePic.pack(fill=tk.BOTH, side=tk.LEFT, expand=True)
labelPic = tk.Label(master=framePic, text="Picture Recognition", font='Arial 15 bold', bg="white")
labelPic.pack()
subFramesPic = []
for file in os.listdir("PicModels"):
    if file.endswith(".model"):
        subFrame = tk.Frame(master=framePic, width=150, height=50, borderwidth=1, relief=tk.SOLID)
        subFrame.pack(fill=tk.BOTH, expand=True)
        subLabel = tk.Label(master=subFrame, text=file.title(), font='Arial 12 bold')
        subLabel.pack()
        subText = tk.Text(master=subFrame)
        subText.configure(height=1, width=1)
        subText.pack(fill=tk.BOTH, expand=True)
        subFramesPic.append([file, subText])


###Data, Test and Evaluation
do = mlbd.MLBattleData()

####PTC
testdata = []
testlabels = []
xs, ys = do.getRandomFunSamples()
for i in range(0, len(xs)-1, 4):
    testdata.append([xs[i]])
    testlabels.append([ys[i]])

best = "No one"
bestval = 100.0
for subFrame in subFramesPTC:
    model = kr.models.load_model("PTCModels/" + subFrame[0].title())
    eval = model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1)
    pred = model.predict(np.array(testdata), batch_size=1)
    subFrame[1].insert("1.0", "Evaluation: " + "{:.5f}".format(eval[0]))
    for i in range(0,5):
        subFrame[1].insert("{}.0".format(i+2), "\nPrediction - Label = {0:.5f} - {1:.5f} = {2:.5f}".format(pred[i][0], testlabels[i][0], pred[i][0] - testlabels[i][0]))
    err = kr.losses.mean_squared_error(testlabels, pred)[0]
    if err < bestval:
        best = subFrame[0].title()
        bestval = err
    subFrame[1].insert("7.0", "\n...")
    subFrame[1].insert("8.0", "\nMean-SQR: {:10f}".format(err))

labelPTCWinner = tk.Label(master=framePTC, text="Winner: {}".format(best), font='Arial 15 bold', bg="white")
labelPTCWinner.pack()

####MaxSum
testdata = []
testlabels = []
for i in range (0, 10):
    set, label = do.getMaxSumSampleWithLabel()
    testdata.append(set)
    testlabels.append([label])

best = "No one"
bestval = 0
for subFrame in subFramesMaxSum:
    model = kr.models.load_model("MaxSumModels/" + subFrame[0].title())
    eval = model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1)
    pred = model.predict(np.array(testdata), batch_size=1)
    subFrame[1].insert("1.0", "Evaluation: " + "{:.5f}".format(eval[0]))
    for i in range(0,5):
        subFrame[1].insert("{}.0".format(i+2), "\nPrediction <-> Label = {0:.5f} <-> {1:.5f}".format(pred[i][0], testlabels[i][0]))
    cur = 0
    for i in range(0, len(pred)):
        if (pred[i][0] < 0.5 and testlabels[i][0] < 0.5) or (pred[i][0] > 0.5 and testlabels[i][0] > 0.5):
            cur = cur + 1
    if cur > bestval:
        best = best = subFrame[0].title()
        bestval = cur
    subFrame[1].insert("7.0", "\n...")
    subFrame[1].insert("8.0", "\nCorrect: {0} of {1}".format(cur, len(pred)))

labelMaxSumWinner = tk.Label(master=frameMaxSum, text="Winner: {}".format(best), font='Arial 15 bold', bg="white")
labelMaxSumWinner.pack()

####Pic
testdata = []
testlabels = []
for i in range (0, 10):
    pic, label = do.getPictureSampleWithLabel()
    testdata.append(pic)
    testlabels.append([label])

best = "No one"
bestval = 0
for subFrame in subFramesPic:
    model = kr.models.load_model("PicModels/" + subFrame[0].title())
    eval = model.evaluate(np.array(testdata), np.array(testlabels), batch_size=1)
    pred = model.predict(np.array(testdata), batch_size=1)
    subFrame[1].insert("1.0", "Evaluation: " + "{:.5f}".format(eval[0]))
    for i in range(0,5):
        subFrame[1].insert("{}.0".format(i+2), "\nPrediction <-> Label = {0:.5f} <-> {1:.5f}".format(pred[i][0], testlabels[i][0]))
    cur = 0
    for i in range(0, len(pred)):
        if (pred[i][0] < 0.5 and testlabels[i][0] < 0.5) or (pred[i][0] > 0.5 and testlabels[i][0] > 0.5):
            cur = cur + 1
    if cur > bestval:
        best = best = subFrame[0].title()
        bestval = cur
    subFrame[1].insert("7.0", "\n...")
    subFrame[1].insert("8.0", "\nCorrect: {0} of {1}".format(cur, len(pred)))

labelPicWinner = tk.Label(master=framePic, text="Winner: {}".format(best), font='Arial 15 bold', bg="white")
labelPicWinner.pack()

window.mainloop()