## Option, Value Object - Aufgabe

- Fachdomäne: **Grußkartenversand**


<img style="object-fit:contain; width: 50%; margin-top: 2rem;" src="/images/briefe--mediamodifier-IQpZZ5wnrgA-unsplash.jpg">


----

### Datenmodell

- Es gibt Empfänger
- Diese haben einen Vornamen (Pflichtfeld, darf nicht leer und auch nicht nur Whitespace sein) und einen Nachnamen (Pflichtfeld, darf nicht leer und auch nicht nur Whitespace sein)
- Diese haben eine Anrede (Optional, leer oder nur Whitespace zählt als nicht vorhanden)
- Diese haben eine Postanschrift (Pflichtfeld, nur Text, darf nicht leer und auch nicht nur Whitespace sein)
- Es gibt Grußkarten
- Diese haben einen Grußkartentext (Pflichtfeld, darf nicht leer und auch nicht nur Whitespace sein, darf nicht länger als 160 Zeichen sein)
- Diese haben einen Empfänger
