using Jasmin1.Interfaces;

namespace Jasmin1
{
    internal class BusinessLogik : IBusinessLogik
    {
        INeuerKunde         NeuerKunde          { get; set; }
        INeuerVertrag       NeuerVertrag        { get; set; }
        IReader             Reader              { get; set; }
        IVertragsfactory    Vertragsfactory     { get; set; }
        IKundenfactory      Kundenfactory       { get; set; }
        IGrafik             Spartenauswahl      { get; set; }
        IKundenstamm        Kundenstamm         { get; set; }
        IVertragsbestand    Vertragsbestand     { get; set; }
        string              Datenbank           { get; set; }
        

        public BusinessLogik( INeuerKunde       neuerKunde, 
                              INeuerVertrag     neuerVertrag, 
                              IReader           reader, 
                              IVertragsfactory  vertragsfactory, 
                              IKundenfactory    kundenfactory,
                              IGrafik           spartenauswahl,
                              IKundenstamm      kundenstamm,
                              IVertragsbestand  vertragsbestand,
                              string            datenbank)
        {
            NeuerKunde      = neuerKunde;
            NeuerVertrag    = neuerVertrag;
            Reader          = reader;
            Vertragsfactory = vertragsfactory;
            Kundenfactory   = kundenfactory;
            Spartenauswahl  = spartenauswahl;
            Kundenstamm     = kundenstamm;
            Vertragsbestand = vertragsbestand;
            Datenbank       = datenbank;
        }

        public void HandleChoice( string choice )
        {
            if      (choice == "1")
            {
                var DatenListe = NeuerKunde.GetKundendaten();
                NeuerKunde.WriteKundenDatenToCsvFile(DatenListe);
            }
            else if (choice == "2")
            {
                NeuerVertrag.GetVertragsdaten();
            }
            else if (choice == "3")
            {
                Kundenstamm.GetKundeBy();
            }
            else if(choice == "4")
            {
                Vertragsbestand.GetVertragBy();
            }
        }
    }
}
