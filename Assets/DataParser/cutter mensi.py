

"""
Cutting out <
"""

file = open("cutterLessIN.txt","r+")
newFile = open("cutterLessOut.txt", "r+")

for line in file:
    newLine = ""
    for i in range(0, len(line)):
        if line[i] == '<':
            continue
        newLine += line[i]
    newFile.write(newLine)

