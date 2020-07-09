# Tricky

Het programma krijgt als input een set letters. Het is de bedoeling deze letters op alfabetische volgorde te zetten. Er zijn drie acties om de volgorde te veranderen:
- (A) De eerste twee letters met elkaar verwisselen. "abcd" wordt dus "bacd".
- (B) De laatste twee letters met elkaar verwisselen. "abcd" wordt dus "abdc:.
- (X) De middelste letters allemaal een stap naar rechts verplaatsen, de meest rechter komt helemaal links te staan. "abcdefg" wordt dus "afbcdeg"

Het is de bedoeling met deze acties in zo weinig mogelijk stappen een alfabetische volgorde te maken. De input is een reeks van deze strings, en de output een reeks stappen per string. Bijvoorbeeld:
- 3 AXA zou betekenen dat het minstens drie stappen kost, namelijk de stappen A, X en A.

Om dit te doen wordt een er door middel van een Breadth-First Search algoritme een graaf gemaakt. Deze graaf is een deel van de graaf met als knopen alle mogelijke volgordes van letters die gemaakt kunnen worden met de genoemde acties. Nieuwe knopen worden gevonden door acties toe te passen op de al gevonden knopen. De knopen zijn objecten van een zelf geimplementeerde class. Die hebben als properties:
- De volgorde van letters
- Een pointer naar de vorige knoop in de graaf van waaruit deze knoop is gevonden
- De actie die is toegepast op de vorige knoop om deze volgorde te krijgen
- De te vinden (alfabetische) volgorde van deze letters
Ook hebben ze methods die A, B of X toepassen op de volgorde en daar een nieuwe knoop mee maken.
Als er een knoop is gevonden met alfabetische volgorde, wordt de route teruggelopen en opgeslagen om als output te geven.

Als eerst de hele graaf gemaakt zou worden en vervolgens de kortste route van de oorspronkelijke volgorde naar de alfabetische volgorde gezocht zou worden, zou dat O(n!) tijd kosten. Dit is in de meeste gevallen sneller.