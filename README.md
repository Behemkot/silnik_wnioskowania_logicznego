# silnik_wnioskowania_logicznego

# output


-----------------------------------------------------------------------

> iteracja 1

FAKTY OKRESLONE

0 Poziom zadłużenia jest niekorzystny 2

1 Poziom zadłużenia jest korzystny 1

2 Poziom rentowności jest niekorzystny 2

3 Poziom rentowności jest korzystny 1

4 Oferta handlowa nie jest atrakcyjna 1

5 Oferta handlowa jest atrakcyjna 2

6 Sytuacja konkurencyjna jest niekorzystna 1

7 Sytuacja konkurencyjna jest korzystna 2

15 Opracowano wiarygodny plan naprawczy 2

16 Opracowano dyskusyjny plan naprawczy 2

17 Brak planu naprawczego 1


FAKTY NIEOKRESLONE

8 Ocena rynkowa jest negatywna 0
9 Ocena rynkowa jest pozytywna 0
10 Ocena ekonomiczna jest negatywna 0
11 Ocena ekonomiczna jest pozytywna 0
12 Zagrożenie bakructwem jest wysokie 0
13 Zagrożenie bakructwem jest niskie 0
14 Brak zagrożenia bakructwem 0
18 Udzielić wsparcia 0
19 Podjąć negocjacje 0
20 Nie udzielać wsparcia 0

> szukam aktywnych regul

AKTYWNE REGULY

Rule: 1
Rule: 2
Rule: 3
Rule: 4
Rule: 5
Rule: 6
Rule: 7
Rule: 8
Rule: 19

> na podstawie aktywnych regul tworze nowe fakty

ID Reguly 1
0 : 2
2 : 2
Wniosek: 
10 : False

ID Reguly 2
0 : 2
3 : 1
Wniosek: 
10 : False

ID Reguly 3
1 : 1
2 : 2
Wniosek: 
11 : False

ID Reguly 4
1 : 1
3 : 1
Wniosek: 
11 : True

ID Reguly 5
4 : 1
6 : 1
Wniosek: 
8 : True

ID Reguly 6
4 : 1
7 : 2
Wniosek: 
9 : False

ID Reguly 7
5 : 2
6 : 1
Wniosek: 
8 : False

ID Reguly 8
5 : 2
7 : 2
Wniosek: 
9 : False

ID Reguly 19
15 : 2
Wniosek: 
18 : False

NOWE FAKTY

11 Ocena ekonomiczna jest pozytywna 1
8 Ocena rynkowa jest negatywna 1

> usuwam aktywne reguly ze zbioru regul

> czyszcze zbior aktywnych regul

NOWY ZBIOR REGUL

Rule: 9
Rule: 10
Rule: 11
Rule: 12
Rule: 13
Rule: 14
Rule: 15
Rule: 16
Rule: 17
Rule: 18

-----------------------------------------------------------------------

> iteracja 2

FAKTY OKRESLONE

0 Poziom zadłużenia jest niekorzystny 2
1 Poziom zadłużenia jest korzystny 1
2 Poziom rentowności jest niekorzystny 2
3 Poziom rentowności jest korzystny 1
4 Oferta handlowa nie jest atrakcyjna 1
5 Oferta handlowa jest atrakcyjna 2
6 Sytuacja konkurencyjna jest niekorzystna 1
7 Sytuacja konkurencyjna jest korzystna 2
15 Opracowano wiarygodny plan naprawczy 2
16 Opracowano dyskusyjny plan naprawczy 2
17 Brak planu naprawczego 1
11 Ocena ekonomiczna jest pozytywna 1
8 Ocena rynkowa jest negatywna 1

FAKTY NIEOKRESLONE

9 Ocena rynkowa jest pozytywna 0
10 Ocena ekonomiczna jest negatywna 0
12 Zagrożenie bakructwem jest wysokie 0
13 Zagrożenie bakructwem jest niskie 0
14 Brak zagrożenia bakructwem 0
18 Udzielić wsparcia 0
19 Podjąć negocjacje 0
20 Nie udzielać wsparcia 0

> szukam aktywnych regul

AKTYWNE REGULY

Rule: 11

> na podstawie aktywnych regul tworze nowe fakty

ID Reguly 11
11 : 1
8 : 1
Wniosek: 
13 : True

NOWE FAKTY

13 Zagrożenie bakructwem jest niskie 1

> usuwam aktywne reguly ze zbioru regul

> czyszcze zbior aktywnych regul

NOWY ZBIOR REGUL

Rule: 9
Rule: 10
Rule: 12
Rule: 13
Rule: 14
Rule: 15
Rule: 16
Rule: 17
Rule: 18

-----------------------------------------------------------------------

> iteracja 3

FAKTY OKRESLONE

0 Poziom zadłużenia jest niekorzystny 2
1 Poziom zadłużenia jest korzystny 1
2 Poziom rentowności jest niekorzystny 2
3 Poziom rentowności jest korzystny 1
4 Oferta handlowa nie jest atrakcyjna 1
5 Oferta handlowa jest atrakcyjna 2
6 Sytuacja konkurencyjna jest niekorzystna 1
7 Sytuacja konkurencyjna jest korzystna 2
15 Opracowano wiarygodny plan naprawczy 2
16 Opracowano dyskusyjny plan naprawczy 2
17 Brak planu naprawczego 1
11 Ocena ekonomiczna jest pozytywna 1
8 Ocena rynkowa jest negatywna 1
13 Zagrożenie bakructwem jest niskie 1

FAKTY NIEOKRESLONE

9 Ocena rynkowa jest pozytywna 0
10 Ocena ekonomiczna jest negatywna 0
12 Zagrożenie bakructwem jest wysokie 0
14 Brak zagrożenia bakructwem 0
18 Udzielić wsparcia 0
19 Podjąć negocjacje 0
20 Nie udzielać wsparcia 0

> szukam aktywnych regul

AKTYWNE REGULY

Rule: 13
Rule: 14

> na podstawie aktywnych regul tworze nowe fakty

ID Reguly 13
13 : 1
16 : 2
Wniosek: 
18 : False

ID Reguly 14
13 : 1
17 : 1
Wniosek: 
20 : True

NOWE FAKTY

20 Nie udzielać wsparcia 1

> usuwam aktywne reguly ze zbioru regul

> czyszcze zbior aktywnych regul

NOWY ZBIOR REGUL

Rule: 9
Rule: 10
Rule: 12
Rule: 15
Rule: 16
Rule: 17
Rule: 18

-----------------------------------------------------------------------

> iteracja 4

FAKTY OKRESLONE

0 Poziom zadłużenia jest niekorzystny 2
1 Poziom zadłużenia jest korzystny 1
2 Poziom rentowności jest niekorzystny 2
3 Poziom rentowności jest korzystny 1
4 Oferta handlowa nie jest atrakcyjna 1
5 Oferta handlowa jest atrakcyjna 2
6 Sytuacja konkurencyjna jest niekorzystna 1
7 Sytuacja konkurencyjna jest korzystna 2
15 Opracowano wiarygodny plan naprawczy 2
16 Opracowano dyskusyjny plan naprawczy 2
17 Brak planu naprawczego 1
11 Ocena ekonomiczna jest pozytywna 1
8 Ocena rynkowa jest negatywna 1
13 Zagrożenie bakructwem jest niskie 1
20 Nie udzielać wsparcia 1

FAKTY NIEOKRESLONE

9 Ocena rynkowa jest pozytywna 0
10 Ocena ekonomiczna jest negatywna 0
12 Zagrożenie bakructwem jest wysokie 0
14 Brak zagrożenia bakructwem 0
18 Udzielić wsparcia 0
19 Podjąć negocjacje 0

> szukam aktywnych regul

> brak aktywnych regul

> koncze petle na iteracji = 4
