using System;
/// <summary>
/// Denne klassen inneholder nyttige metoder som ikke burde være nødvendig å skrive på nytt hver gang de brukes.
/// </summary>
public static class Commons
{

   /// <summary>
   /// Spør brukeren etter en gyldig int
   /// </summary>
   /// <param name="Feilmelding">Feilmelding som skal vises til brukeren</param>
   /// <param name="maxValue">Høyeste verdi vi tillater</param>
   /// <param name="minValue">Laveste verdi vi tillater</param>
   /// <returns>En gyldig int fra bruker</returns>
    public static int GetIntConsole(string Feilmelding = "", int maxValue = Int32.MaxValue, int minValue = Int32.MinValue)
    {
        int i;
        while (!(int.TryParse(Console.ReadLine(), out i)))
        {
            if (Feilmelding.Length > 0)
                Console.WriteLine(Feilmelding);
        }

        if(i<minValue || i> maxValue){
            Console.WriteLine("Out of scope! Skriv inn et tall som er mellom {0} og {1}", minValue, maxValue);
            return GetIntConsole(Feilmelding, maxValue, minValue);
        }
        return i;

    }

    /// <summary>
    /// Spør brukeren etter en gyldig double
    /// </summary>
    /// <param name="Feilmelding">Feilmelding som skal vises til brukeren</param>
    /// <returns>En gyldig double fra brukeren</returns>
    public static double GetDoubleConsole(string Feilmelding = "")
    {
        double i;

        while (!(double.TryParse(Console.ReadLine(), out i)))
        {
            if (Feilmelding.Length > 0)
                Console.WriteLine(Feilmelding);
        }
        return i;

    }

    /// <summary>
    /// Skriver en tekst til fil. Valgfritt om du skal overskrive eller legge til tekst.
    /// </summary>
    /// <param name="filplassering">plasseringen til filen + navnet og filtypen eks: test.txt</param>
    /// <param name="textTilFil">Teskten som skal skrives til fil</param>
    /// <param name="append">true=legg til tekst, false=fjern eksisterende fil og skriv ny</param>
    public static void SkrivTilFil(string filplassering, string textTilFil, bool append = false)
    {
        if (append)
        {
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(filplassering))
            {
                sw.WriteLine(textTilFil);
            }
        }
        else
        {
            System.IO.File.WriteAllText(filplassering, textTilFil);
        }

    }

    /// <summary>
    /// Skriver en tekst til fil. Valgfritt om du skal overskrive eller legge til tekst.
    /// </summary>
    /// <param name="filplassering">plasseringen til filen + navnet og filtypen eks: test.txt</param>
    /// <param name="textTilFil">Teskten som skal skrives til fil. Skriver hver del av tabellen på ny linje</param>
    /// <param name="append">true=legg til tekst, false=fjern eksisterende fil og skriv ny</param>
    public static void SkrivTilFil(string filplassering, string[] textTilFil, bool append = false)
    {
        if (append)
        {
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(filplassering))
            {
                foreach(string line in textTilFil)
                {
                    sw.WriteLine(line);
                }
            }
        }
        else
        {
            System.IO.File.WriteAllLines(filplassering, textTilFil);
        }

    }

    /// <summary>
    /// Åpner en fil og leser den inn i en tabell, linje for linje.
    /// </summary>
    /// <param name="filplassering">Plasseringen til filen + navn og filtype. eks: test.txt</param>
    /// <param name="filefound">Metoden vil indikere om den finner filen eller ikke</param>
    /// <param name="fjernOverskriftLinjer">Hvor mange linjer du vil skippe på starten av filen</param>
    /// <returns>Returnerer en tabell med alle linjene med tekst fra filen. tabell[0] inneholder feilmelding om filefound=false</returns>
    public static string[] LesFraFil(string filplassering, ref bool filefound, int fjernOverskriftLinjer=0)
    {
        try
        {
            string[] textlinjerFraFil = System.IO.File.ReadAllLines(filplassering);
            if (fjernOverskriftLinjer != 0)
                Array.Copy(textlinjerFraFil, fjernOverskriftLinjer, 
                          (textlinjerFraFil=new string[textlinjerFraFil.Length- fjernOverskriftLinjer]),
                          0, textlinjerFraFil.Length);
            filefound = true;
            return textlinjerFraFil;
        }
        catch (System.IO.FileNotFoundException e)
        {
            filefound = false;
            return new string[]{"feilmelding"};
        }
    }

    /// <summary>
    /// Åpner en fil og leser den inn i en tabell, linje for linje.
    /// </summary>
    /// <param name="filplassering">Plasseringen til filen + navn og filtype. eks: test.txt</param>
    /// <param name="fjernOverskriftLinjer">Hvor mange linjer du vil skippe på starten av filen</param>
    /// <returns>Returnerer en tabell med alle linjene med tekst, minus fjernOverskiftLinjer antall linjer fra starten av filen.</returns>
    public static string[] LesFraFil(string filplassering, int fjernOverskriftLinjer = 0)
    {
        string[] textlinjerFraFil = System.IO.File.ReadAllLines(filplassering);

        if (fjernOverskriftLinjer != 0)
        {
            Array.Copy(textlinjerFraFil, fjernOverskriftLinjer, (textlinjerFraFil = new string[textlinjerFraFil.Length - fjernOverskriftLinjer]), 0, textlinjerFraFil.Length);
        }
        return textlinjerFraFil;
    }

}
