using System;
using System.Collections.Generic;
using ModelLayer.Data;
using System.Text;

namespace ModelLayer.Business
{
    public class Poste
    {
        private int _id;
        private string _nom;
        private int _escouade;

        public Poste(int id, string nom, int escouade)
        {
            _id = id;
            _nom = nom;
            _escouade = escouade;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public int Escouade { get => _escouade; set => _escouade = value; }
    }
}
