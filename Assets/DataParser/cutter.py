

"""
Cutting out z
"""

file = open("cutterIN.txt","r+")
newFile = open("cutterOUT.txt", "r+")

for line in file:
    newLine = ""
    con = 0
    for i in range(0, len(line)):
        if con:
            con = 0
            continue
        if (line[i] == 'z' and line[i+1] == ' '):
            con = 1
            continue
        newLine += line[i]
    newFile.write(newLine)




"""
Cutting out <

file = open("cutterIN.txt","r+")
newFile = open("cutterOut.txt", "r+")

for line in file:
    newLine = ""
    for i in range(0, len(line)):
        if line[i] == '<':
            continue
        newLine += line[i]
    newFile.write(newLine)

"""