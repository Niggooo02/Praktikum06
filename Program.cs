using System;

namespace Praktikum06 {
    class Program {
        static void Main(string[] args) {
            char[] wort = wortGenerieren();
            char[] wortVerdeckt = new char[wort.Length];        //Neuer char-Array, der zuerst Minuszeichen speichert und nach und nach mit aufgedeckten Buchstaben befüllt wird (-> gleiche Länge)
            char eingabe;
            bool buchstabeGefunden;
            int anzahlFehler = 0;
            int maxAnzahlFehler = 7;

            for (int i = 0; i < wortVerdeckt.Length; i++) {
                wortVerdeckt[i] = '-';  //Standardmäßig: Array voller Minuszeichen
            }

            Console.WriteLine("Hangman");
            Console.WriteLine("======");
            Console.WriteLine($"Gesucht ist ein Wort mit {wort.Length} Buchstaben.");
            Ausgabe(wortVerdeckt);
            Console.WriteLine();

            while (!WortKomplettAufgedeckt(wortVerdeckt) && anzahlFehler < maxAnzahlFehler) {
                buchstabeGefunden = false;      //Auf Standardwert zurücksetzen

                Console.Write("Buchstaben eingeben: ");
                eingabe = Console.ReadKey().KeyChar;
                eingabe = Char.ToLower(eingabe);        //in Kleinbuchstaben umwandeln
                Console.WriteLine();

                //Jeden Buchstaben des Wortes mit Eingabe vergleichen
                for (int i = 0; i < wort.Length; i++) {
                    if (wort[i] == eingabe) {
                        wortVerdeckt[i] = eingabe;
                        buchstabeGefunden = true;
                    }
                }

                if (buchstabeGefunden) {
                    Ausgabe(wortVerdeckt);
                    Console.WriteLine($"\t---> {eingabe} ist richtig!");
                } else {
                    Ausgabe(wortVerdeckt);
                    Console.WriteLine($"\t---> {eingabe} ist falsch!");
                    anzahlFehler++;
                    Console.WriteLine($"{anzahlFehler} von {maxAnzahlFehler} Fehlern.");
                }
                Console.WriteLine();
            }

            if(anzahlFehler >= maxAnzahlFehler) {
                Console.WriteLine("Du hast verloren.");
            } else if (anzahlFehler < maxAnzahlFehler && WortKomplettAufgedeckt(wortVerdeckt) == true) {
                Console.WriteLine("Du hast gewonnen");
            }
        }

        static void Ausgabe(char[] _wortVerdeckt) {
            Console.Write("Das gesuchte Wort ist: ");
            //zur besseren Lesbarkeit wird der erste Buchstabe als Großbuchstabe ausgegeben, wird jedoch als Kleinbuchstabe gespeichert, um diesen mit der Eingabe besser vergleichen zu können
            Console.Write(Char.ToUpper(_wortVerdeckt[0]));
            for (int i = 1; i < _wortVerdeckt.Length; i++) {
                Console.Write(_wortVerdeckt[i]);        //alle anderen Buchstaben werden als Kleinbuchstaben ausgegeben
            }
        }

        static char[] wortGenerieren() {
            //Speichert alle möglichen Wörter und gibt ein zufälliges als char-Array zurück
            Random random = new Random();
            string[] woerterListe = new string[10];

            woerterListe[0] = "Winter";
            woerterListe[1] = "Lebkuchen";
            woerterListe[2] = "Weihnachten";
            woerterListe[3] = "Tannenbaum";
            woerterListe[4] = "Programmieren";
            woerterListe[5] = "Informatik";
            woerterListe[6] = "Nuernberg";
            woerterListe[7] = "Christkind";
            woerterListe[8] = "Array";
            woerterListe[9] = "Schnee";

            for (int i = 0; i < woerterListe.Length; i++) {
                woerterListe[i] = woerterListe[i].ToLower();    //Alle Buchstaben der Strings werden in Kleinbuchstaben umgewandelt
            }

            int zufallszahl = random.Next(0, 10);
            return woerterListe[zufallszahl].ToCharArray();     //Ein zufälliges Wort wird ausgewählt und als char[] zurückgegeben
        }

        static bool WortKomplettAufgedeckt(char[] _wortVerdeckt) {
            for (int i = 0; i < _wortVerdeckt.Length; i++) {
                if (_wortVerdeckt[i] == '-') {
                    return false;       //Wird ein Minuszeichen entdeckt, wird die Methode abgebrochen und false zurückgegeben
                }
            }
            return true;        //Läuft die Schleife komplett durch (kein Abbruch), sind keine Minuszeichen mehr im Wort enthalten -> true wird zurückgegeben
        }
    }
}