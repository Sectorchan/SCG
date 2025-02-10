using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PL;

namespace SCG;

public class S2
{
    #region Private members
    private Dictionary<string, string> _serverDetails { get; set; } = new Dictionary<string, string>    {
        { "name", "" },
        { "user", "" },
        { "passs", "" }
    };
    private static Dictionary<string, string> _serverDetails2;

    private string _Details;
    private static string _Details2;
    #endregion

    private static Dictionary<string, string> _hostInformation = new Dictionary<string, string>
    {
        { "name", "" },
        { "user", "" },
        { "passs", "" }
    };
    // Methode zum Ändern von Werten, aber nur für existierende Keys
    public static bool setValue(string schluessel, string neuerWert)
    {
        if (_hostInformation.ContainsKey(schluessel))
        {
            _hostInformation[schluessel] = neuerWert;
            return true;
        }
        return false; // Änderung nicht möglich, da Schlüssel nicht existiert
    }

    public static string getValue(string schluessel)
    {
        string wert = string.Empty;
        if (_hostInformation.TryGetValue(schluessel, out wert))
        {
            return wert;
        }
        else
        {
            return wert = "nix";
        }
    }

    string s = getValue("host");

    public Dictionary<string, string> ServerDetails
    {
        get
        {
            return _serverDetails;
        }
        set
        {
            //if (value == null) throw new ArgumentNullException(nameof(value), "Dictionary darf nicht null sein.");
            _serverDetails = value;
        }
    }


    public string Details
    {
        get
        {
            return _Details;
        }
        set
        {
            _Details = value;
        }
    }
    public static Dictionary<string, string> ServerDetails2
    {
        get
        {
            return _serverDetails2;
        }
        set
        {
            _serverDetails2 = value;
        }
    }
}
