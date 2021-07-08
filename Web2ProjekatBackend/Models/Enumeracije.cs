using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2ProjekatBackend.Models
{
    public enum VrsteKorisnika
    {
        CLANEKIPE,
        DISPECER,
        RADNIK,
        POTROSAC,
        ADMINISTRATOR
    }

    public enum TipIncidenta
    {
        PLANIRANI_INCIDENT,
        NEPLANIRANI_INCIDENT
    };

    public enum TipElementa
    {
       PREKIDAC,
       OSIGURAC,
       TRANSFORMATOR,
       DISKONEKTOR
    };

    public enum TipRada
    {
        PLANIRANI_RAD,
        NEPLANIRANI_RAD
    };

    public enum TipPotrosaca
    {
        REZIDENTALNI,
        KOMERCIJALNI
    };

    public enum TipEntiteta
    {
        EKIPE,
        ELEMENTS,
        INCIDENTS,
        NALOZI,
        PLANOVI,
        PORUKE,
        POTROSACI,
        POZIVI,
        RESOLUTIONS,
        SAFETY_DOCUMENTS,
        OPREMA
    };

    public enum TipPoruke
    {
        ERROR,
        WARNING,
        INFO,
        SUCCESS
    };
}
