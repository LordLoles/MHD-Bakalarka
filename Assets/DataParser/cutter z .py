

"""
Cutting out z 
"""

file = open("cutterZIN.txt","r+")
newFile = open("cutterZOUT.txt", "r+")

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
