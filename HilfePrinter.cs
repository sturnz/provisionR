using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1
{
    public static class HilfePrinter
    {
        public static void Print()
        {
            Console.WriteLine(  "Provisionsrechner Version 1.0\n\n"                     +

                                "[Optional arguments]\n\n"                              +

                                "-dir       Arbeitsverzeichnis\n" +
                                "-pa        Provisionsanteil in Prozent (Ganzzahl)\n"   +
                                "-dak       Name der Datenbank für Kundendaten\n"       +
                                "-dav       Name der Datenbank für Vertragsdaten\n"     +
                                "-ft        Filetype der Datenbanken (.csv, .txt)\n"    +
                                "-h         Help\n\n"                                   +

                                "Für nicht eingegebene Argumente werden die Default Einstellungen aus App.config verwendet.");
           
        }
    }
}
