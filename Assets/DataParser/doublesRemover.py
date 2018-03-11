
file = open("parserStopsCutted.txt","r+")
newFile = open("out.txt", "r+")
stops = []

for line in file:
    if line in stops:
        continue
    stops.append(line)

stops.sort()
for x in stops:
    newFile.write(x)
