using ModelLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Business
{
    public class Joueur
    {
        private int _id;
        private string _nom;
        private DateTime _dateEntree;
        private DateTime _dateNaissance;
        private Poste _lePoste;
        private Pays _lePays;


        public Joueur(int id, string nom, DateTime dateEntree, DateTime dateNaissance, Poste lePoste, Pays lePays)
        {
            _id = id;
            _nom = nom;
            _dateEntree = dateEntree;
            _dateNaissance = dateNaissance;
            _lePoste = lePoste;
            _lePays = lePays;
        }

        public Joueur()
        {
            this._id = Id;
            this._nom = Nom;
            this._dateEntree = DateEntree;
            this._dateNaissance = DateNaissance;
            this._lePoste = LePoste;
            this._lePays = LePays;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime DateEntree { get => _dateEntree; set => _dateEntree = value; }
        public DateTime DateNaissance { get => _dateNaissance; set => _dateNaissance = value; }
        public Poste LePoste { get => _lePoste; set => _lePoste = value; }
        public Pays LePays { get => _lePays; set => _lePays = value; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
