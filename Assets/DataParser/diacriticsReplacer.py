
file = open("diacriticsIN.txt", "r+")
newFile = open("diacriticsOUT.txt", "r+")

removeThose = ['á','é','í','ó','ú','ý','ě','ř','ť','š','ď','ľ','ž','č','ň','ô','ä','Á','É','Í','Ó','Ú','Ý','Ě','Ř','Ť','Š','Ď','Ľ','Ž','Č','Ň']
insertThose = ['a','e','i','o','u','y','e','r','t','s','d','l','z','c','n','o','a','A','E','I','O','U','Y','E','R','T','S','D','L','Z','C','N']

for line in file:
    newLine = ""
    for i in range(0, len(line)):

        remove = -1
        for j in range(0, len(removeThose)):
            if (line[i] == removeThose[j]):
                remove = j
                break
        if (remove == -1):
            newLine += line[i]
        else:
            newLine += insertThose[remove]

    newFile.write(newLine)
