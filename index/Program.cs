using System;
using System.Data;
using MySql.Data.MySqlClient;

using ModelLayer.Data;
using ModelLayer.Business;
using System.Collections.Generic;

namespace index
{
    public class Program
    {
        private static Dbal mondbal;

        private static DAOPays myDaoPays;
        private static Pays myPays;

        private static DaoPoste myDaoPoste;
        private static Pays myPoste;

        private static DaoJoueur myDaoJoueur;
        private static Joueur myJoueur;

        private static DaoEquipe myDaoEquipe;
        private static Equipe myEquipe;

        static void Main(string[] args)
        {
            mondbal = new Dbal("dsfootamericain");
            myDaoPays = new DAOPays(mondbal);
            myDaoPoste = new DaoPoste(mondbal);
            myDaoJoueur = new DaoJoueur(mondbal, myDaoPays, myDaoPoste,myDaoEquipe);

            #region testPays
            //afficher liste pays
            List<Pays> listPays = myDaoPays.SelectAll();
            foreach (Pays p in listPays)
            {
                Console.WriteLine(p.Nom);
            }

            //afficher nom pays par id

            //Pays myPays = myDaoPays.SelectById(1);
            //Console.WriteLine(myPays.Nom);

            //afficher nom pays par nom

            //Pays myPays = myDaoPays.SelectByName("France");
            //Console.WriteLine(myPays.Nom);

            //insert pays
            //Pays myPays = new Pays(4, "Allemagne");
            //myDaoPays.Insert(myPays);
            #endregion

            #region testJoueur
            List<Joueur> listeJoueur = myDaoJoueur.SelectAll();
            foreach (Joueur j in listeJoueur)
            {
                Console.WriteLine(j.Nom);
            }
            #endregion
        }
    }
}
