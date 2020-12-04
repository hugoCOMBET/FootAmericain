using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using ModelLayer.Data;
using ModelLayer.Business;

namespace ModelLayer.Data
{
    public class DaoEquipe
    {
        private Dbal thedbal;

        public DaoEquipe(Dbal mydbal)
        {
            this.thedbal = mydbal;
        }

        public void Insert(Equipe theEquipe)
        {
            string query = "Equipe (id, nom) VALUES (" + theEquipe.Id + ",'" + theEquipe.Nom.Replace("'", "''") + theEquipe.DateCreation + ",'" + theEquipe.LstJoueur + ",'" + "')";
            this.thedbal.Insert(query);
        }
        public List<Equipe> SelectAll()
        {
            List<Equipe> listEquipe = new List<Equipe>();
            DataTable myTable = this.thedbal.SelectAll("Equipe");

            foreach (DataRow r in myTable.Rows)
            {
                listEquipe.Add(new Equipe((int)r["id"], (string)r["nom"], (DateTime)r["dateCreation"]));
            }
            return listEquipe;
        }

        public Equipe SelectByName(string nameEquipe)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("Equipe", "nom = '" + nameEquipe.Replace("'", "''") + "'");
            Equipe foundEquipe = new Equipe((int)result.Rows[0]["id"], (string)result.Rows[0]["nom"], (DateTime)result.Rows[0]["dateCreation"]);
            return foundEquipe;
        }

        public Equipe SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Equipe", idPays);
            return new Equipe((int)result["id"], (string)result["nom"], (DateTime)result["dateCreation"]);
        }
    }
}
