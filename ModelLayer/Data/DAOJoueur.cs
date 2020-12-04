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
    public class DaoJoueur
    {
        private Dbal thedbal;
        private DAOPays theDaoPays;
        private DaoPoste theDaoPoste;
        private DaoEquipe theDaoEquipe;
        public DaoJoueur(Dbal mydbal,DAOPays theDaoPays, DaoPoste theDaoPoste,DaoEquipe theDaoEquipe)
        {
            this.thedbal = mydbal;
            this.theDaoPays = theDaoPays;
            this.theDaoPoste = theDaoPoste;
            this.theDaoEquipe = theDaoEquipe;
        }

        public void Insert(Joueur theJoueur,Equipe theEquipe)
        {
            string query = "Joueur " 
                +"(id, nom,dateEntree,dateNaissance) " 
                +"" + "VALUES " +"(" 
                + theJoueur.Id+ ",'" 
                + theJoueur.Nom.Replace("'", "''") 
                + theJoueur.DateEntree + ",'" 
                + theJoueur.DateNaissance 
                + ",'" + theJoueur.LePays 
                + ",'" + theJoueur.LePoste + ",'"
                + theEquipe.Nom + ",'"
                + "')";
            this.thedbal.Insert(query);
        }
        public List<Joueur> SelectAll()
        {
            List<Joueur> listJoueur = new List<Joueur>();
            DataTable myTable = this.thedbal.SelectAll("Joueur");

            foreach (DataRow r in myTable.Rows)
            {
                Pays myPays = this.theDaoPays.SelectById((int)r["pays"]);
                Poste myPoste = this.theDaoPoste.SelectById((int)r["poste"]);
                listJoueur.Add(new Joueur((int)r["id"], (string)r["nom"], (DateTime)r["dateEntree"], (DateTime)r["dateNaissance"],myPoste,myPays));
            }
            return listJoueur;
        }

        public Joueur SelectByName(string nameJoueur)
        {
            DataTable result = new DataTable();
            result = this.thedbal.SelectByField("Joueur", "nom = '" + nameJoueur.Replace("'", "''") + "'");
            Joueur foundJoueur = new Joueur((int)result.Rows[0]["id"], (string)result.Rows[0]["nom"], (DateTime)result.Rows[0]["dateCreation"], (DateTime)result.Rows[0]["dateNaissance"], (Poste)result.Rows[0]["nom"], (Pays)result.Rows[0]["nom"]);
            return foundJoueur;
        }

        public Joueur SelectById(int idPays)
        {
            DataRow result = this.thedbal.SelectById("Joueur", idPays);
            return new Joueur((int)result["id"], (string)result["nom"], (DateTime)result["dateCreation"], (DateTime)result["dateNaissance"], (Poste)result["nom"], (Pays)result["nom"]);
        }

        public void Update(Joueur monJoueur,Equipe monEquipe)
        {
            string query = "Joueur SET id = " + monJoueur.Id
               + ", nom = '" + monJoueur.Nom.Replace("'", "''")
               + "', dateEntree = '" + monJoueur.DateEntree.ToString("yyyy-MM-dd")
               + "', dateNaissance = '" + monJoueur.DateNaissance.ToString("yyyy-MM-dd")
               + "', pays = '" + monJoueur.LePays.Id
               + "', poste = '" + monJoueur.LePoste.Id
               + "', equipe = '" + monEquipe.Id
               + "' "
               + "WHERE id = " + monJoueur.Id;
            this.thedbal.Update(query);
        }
        public void Delete(Joueur leJoueur)
        {
            string requete = "Joueur where id = '" + leJoueur.Id + "'";
            this.thedbal.Delete(requete);
        }
    }
}
