using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.Data;

namespace ModelLayer.Business
{
    public class Equipe
    {
        private int _id;
        private string _nom;
        private DateTime _dateCreation;
        private List<Joueur> _LstJoueur = new List<Joueur>();

        public Equipe(int id, string nom, DateTime dateCreation)
        {
            _id = id;
            _nom = nom;
            _dateCreation = dateCreation;
            _LstJoueur = new List<Joueur>();
        }
        public Equipe()
        {
            this._id = Id;
            this._nom = Nom;
            this._dateCreation = DateCreation;
            this._LstJoueur = new List<Joueur>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public DateTime DateCreation { get => _dateCreation; set => _dateCreation = value; }
        internal List<Joueur> LstJoueur { get => _LstJoueur; set => _LstJoueur = value; }

        public override string ToString()
        {
            return this.Nom;
        }
    }
}
