file = open("timeIN.txt","r+")
newFile = open("timeOUT.txt", "r+")

count = -1;

for line in file:
    newLine = ""
    count += 1
    tmp = count % 5
    if (tmp == 0 or tmp == 1 or tmp == 3):
        newLine = line
    else:
        times = line.split(" ")
        first = 1
        for i in range (0, len(times)):
            time = times[i]
            if (len(time) < 2) : continue
            if first : first = 0
            else : newLine += " "
            tmp = time.split(":")
            newLine += tmp[0] + ":" + tmp[1][:2]
        newLine += '\n'
    newFile.write(newLine)
