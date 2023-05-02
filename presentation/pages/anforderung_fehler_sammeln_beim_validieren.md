## Neue Anforderung!

- Beim Anlegen eines Eintrags werden alle Pflichtfelder validiert. Validierungsfehler werden gesammelt und am Ende gebündelt zurückgegeben. Nur wenn alle Validierungen erfolgreich sind, wird der Eintrag angelegt.
- Die Felder und Regeln:
    - Vorname
        - Muss existieren 
        - Darf nicht leer sein oder nur aus Whitespace bestehen 
    - Geburtstag
        - Muss existieren 
        - Darf nicht in der Zukunft liegen 
