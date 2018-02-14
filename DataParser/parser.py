import urllib2
try:
    from BeautifulSoup import BeautiflSoup
except ImportError:
    from bs4 import BeautifulSoup

page = urllib2.urlopen('http://www.dpb.sk/pre-cestujucich/cestovne-poriadky-2/?page=3')
soup = BeautifulSoap(page)
x = soup.body.find('div', attrs={'class':'container'}).text
print x`
