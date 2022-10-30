using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class Provisionsrechner : IProvisionsrechner
    {
        private int ProvisionAnteilPartner { get; set; }

        public Provisionsrechner(int provisionAnteilPartner)
        {
            ProvisionAnteilPartner = provisionAnteilPartner;    
        }


        public string BerechneProvision(string sparte, string beitrag, string zahlweise)
        {
            if (sparte is null)     return null;
            if (beitrag is null)    return null;
            if (zahlweise is null)  return null;

            var provisionen = new List<string>();
            var betrag = double.Parse(beitrag);

            switch (zahlweise)
            {
                case "monatlich":
                    betrag *= 12;
                    break;
                case "vierteljährlich":
                    betrag *= 4;
                    break;
                case "halbjährlich":
                    betrag *= 2;
                    break;
                case "jährlich":
                    betrag *= 1;
                    break;
            }

            switch (sparte)
            {
                case "HR":
                    betrag -= betrag / 100 * 16.15;
                    break;
                case "WG":
                    betrag -= betrag / 100 * 16.75;
                    break;
            }

            double gesamtProvision = Math.Round(betrag, 2);

            string provisionPartner = (Math.Round((gesamtProvision / 100 * ProvisionAnteilPartner), 2)).ToString("0.00");

            return provisionPartner;
        }
    }
}
