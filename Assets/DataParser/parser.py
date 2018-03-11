import urllib.request
import time
from random import randint
from selenium import webdriver
from selenium.webdriver.common.keys import Keys

def mySleep():
    time.sleep(randint(200, 5300)/1000)


def openLink(element):
    element.click()

    """najdeme zoznam zastavok a casov do zastavok"""
    riadky = driver.find_elements_by_class_name("zastavky_riadok")
    for j in range(0, len(riadky)):
        if (j != 0):
            file.write(" | ")
        riadok = riadky[j]
        slova = riadok.text.split(" ")
        """ziskame cas do zastavky"""
        if (slova[0] == "("):
            file.write("0")
        else:
            file.write(slova[0])
        file.write(" ")
        """ziskame zastavku"""
        for i in range(0, len(slova)):
            if (i == 0 or i == len(slova)-1):
                continue
            file2.write(slova[i])
            file.write(slova[i])
            if (i != len(slova)-2):
                file2.write(" ")
                file.write(" ")
            else:
                file2.write('\n')
    file.write('\n')

    """najdeme casy odchodov z prvej zastavky"""
    odchody = driver.find_element_by_class_name("cp_odchody_tabulka_max")
    odchodyRiadok = odchody.find_elements_by_class_name("cp_odchody")
    for i in range(0, len(odchodyRiadok)):
        slova = odchodyRiadok[i].text.split(" ")
        hodina = slova[0]
        if (len(slova) == 1):
            continue
        for j in range(1, len(slova)):
            if (j != 1):
                file.write(" ")
            file.write(hodina + ":" + slova[j])
        if (i != len(odchodyRiadok)-1):
            file.write(" ")
    file.write('\n')



def cont(continue_link):

    file.write(continue_link.text)
    file.write('\n')
    """otvorime linku"""
    continue_link.click()

    """otvorime prvu trasu linky"""
    tbody2 = driver.find_elements_by_tag_name("tbody")
    element = tbody2[1].find_element_by_css_selector("a")
    openLink(element)

    """ideme spat"""
    driver.back()
    mySleep()

    """otvorime druhu trasu linky"""
    tbody2 = driver.find_elements_by_tag_name("tbody")
    element = tbody2[2].find_element_by_css_selector("a")
    openLink(element)

    """ideme spat"""
    driver.back()
    mySleep()

    driver.back()



file = open("parserOut.txt", "r+")
file2 = open("parserStops.txt", "r+")

file.truncate(0)
file2.truncate(0)

"""otvorime zoznam liniek"""
url = 'https://imhd.sk/ba/cestovne-poriadky'
driver = webdriver.Chrome()
driver.get(url)

"""najdeme linky"""
tbody1 = driver.find_element_by_tag_name("tbody")
continue_links = tbody1.find_elements_by_css_selector("a")
pLiniek = len(continue_links)

for i in range(0, pLiniek):
    tbody1 = driver.find_element_by_tag_name("tbody")
    continue_links = tbody1.find_elements_by_css_selector("a")
    if (continue_links[i].text == "131"):
        continue
    cont(continue_links[i])

driver.close()
