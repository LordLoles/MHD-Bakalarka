

"""
Cutting out z

file = open("parserStops.txt","r+")
newFile = open("out.txt", "r+")

for line in file:
    newLine = ""
    if (line[0] == 'z' and line[1] == ' '):
        for i in range(2, len(line)):
            newLine = newLine + line[i]
    else:
        newLine = line
    newFile.write(newLine)
"""

"""
Cutting out <
"""

file = open("parserOut.txt","r+")
newFile = open("out.txt", "r+")

for line in file:
    newLine = ""
    for i in range(0, len(line)):
        if line[i] == '<':
            continue
        newLine = newLine + line[i]
    newFile.write(newLine)
