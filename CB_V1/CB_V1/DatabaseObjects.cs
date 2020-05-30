using System;
using System.Collections.Generic;
using System.Text;



namespace CB_V1
{
    
    public class Actiune
    {

        public int Id { get; set; } 

        public string Denumire { get; set; }

        public virtual ICollection<RutinaActiune> RutinaActiune { get; set; } = new HashSet<RutinaActiune>();

        public virtual ICollection<GeneratorRutina> GeneratorRutina { get; set; } = new HashSet<GeneratorRutina>();
    }

    public class ParcursRutina
    {
        public int Id { get; set; }

        public int IdRutina { get; set; }
        public string Data { get; set; }
        public int An { get; set; }
        public int Zi_An { get; set; }

       // [ForeignKey("IdRutina")]
        public virtual Rutina Rutina { get; set; }
    }

    public class Rutina
    {
        public int Id { get; set; }
        public int IdUtilizator { get; set; }

        //[ForeignKey("IdUtilizator")]
        public virtual Utilizator Utilizator { get; set; }

        public virtual ICollection<ParcursRutina> ParcursRutina { get; set; } = new HashSet<ParcursRutina>();
        public virtual ICollection<RutinaActiune> RutinaActiune { get; set; } = new HashSet<RutinaActiune>();

    }

    public class Stare
    {
        public int Id { get; set; }
        public string Denumire { get; set; }

    }

    public class Utilizator
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int? IdUltimParcursRutina { get; set; }
        public string Parola { get; set; }


        //[ForeignKey("IdUltimParcursRutina")]
        public virtual ParcursRutina UltimParcursRutina { get; set; }

        public virtual ICollection<Rutina> Rutina { get; set; } = new HashSet<Rutina>();


        public virtual ICollection<GeneratorRutina> GeneratorRutina { get; set; } = new HashSet<GeneratorRutina>();


        public override string ToString()
        {
            return $"({Id}) {Nume} {Parola}";
        }

    }

    public class RutinaActiune
    {
        public int Id { get; set; }
        public int IdActiune { get; set; }
        public int IdRutina { get; set; }
        public int IdStare { get; set; }
        public int? ActiuniCumulate { get; set; }

        //[ForeignKey("IdRutina")]
        public virtual Rutina Rutina { get; set; }

        //[ForeignKey("IdActiune")]
        public virtual Actiune Actiune { get; set; }

        //[ForeignKey("IdStare")]
        public virtual Stare Stare { get; set; }
    }

    public class GeneratorRutina
    {
        public int Id { get; set; }
        public int IdActiune { get; set; }
        public int IdUtilizator { get; set; }

        public int? Activ { get; set; }

        public int? TotalAc { get; set; }

        //[ForeignKey("IdUtilizator")]
        public virtual Utilizator Utilizator { get; set; }

        //[ForeignKey("IdActiune")]
        public virtual Actiune Actiune { get; set; }

    }

}
