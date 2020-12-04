using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModelLayer.Business;
using ModelLayer.Data;
using FootAmericain.viewModel;
using System.Windows;

namespace FootAmericain.viewModel
{
    class viewModelEquipe : viewModelBase
    {
        private DAOPays vmDaoPays;
        private DaoEquipe vmDaoEquipe;
        private DaoJoueur vmDaoJoueur;
        private DaoPoste vmDaoPoste;

        private ObservableCollection<Equipe> listEquipe;
        private ObservableCollection<Joueur> listJoueur;
        private ObservableCollection<Poste> listPoste;
        private ObservableCollection<Pays> listPays;

        private Equipe selectedEquipe = new Equipe();
        private Joueur selectedJoueur = new Joueur();

        private ICommand updateCommand;
        private ICommand supprimerCommand;
        private ICommand ajouterCommand;


        public viewModelEquipe(DaoEquipe thedaoequipe, DaoJoueur thedaojoueur, DAOPays thedaopays,DaoPoste thedaoposte)
        {
            vmDaoPays = thedaopays;
            vmDaoJoueur = thedaojoueur;
            vmDaoPoste = thedaoposte;
            vmDaoEquipe = thedaoequipe;

            listEquipe = new ObservableCollection<Equipe>(thedaoequipe.SelectAll());
            listJoueur = new ObservableCollection<Joueur>(thedaojoueur.SelectAll());
            listPays = new ObservableCollection<Pays>(thedaopays.SelectAll());
            listPoste = new ObservableCollection<Poste>(thedaoposte.SelectAll());

            foreach (Joueur J in ListJoueur)
            {
                int i = 0;
                while (J.Id != listPays[i].Id)
                {
                    i++;
                }
                J.LePays = listPays[i];
            }
            foreach (Joueur J in ListJoueur)
            {
                int i = 0;
                while (J.Id != listPays[i].Id)
                {
                    i++;
                }
                J.LePoste = listPoste[i];
            }
        }
        public ObservableCollection<Equipe> ListEquipe { get => listEquipe; set => listEquipe = value; }
        public ObservableCollection<Joueur> ListJoueur { get => listJoueur; set => listJoueur = value; }
        public ObservableCollection<Poste> ListPoste { get => listPoste; set => listPoste = value; }
        public ObservableCollection<Pays> ListPays { get => listPays; set => listPays = value; }

        public string Nom
        {
            get => SelectedJoueur.Nom;
            set
            {
                if (selectedJoueur.Nom != value)
                {
                    selectedJoueur.Nom = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }

        public DateTime DateEntree
        {
            get => SelectedJoueur.DateEntree;
            set
            {
                if (selectedJoueur.DateEntree != value)
                {
                    selectedJoueur.DateEntree = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }

        public Poste Poste
        {
            get => SelectedJoueur.LePoste;
            set
            {
                if (selectedJoueur.LePoste != value)
                {
                    selectedJoueur.LePoste = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }

        public Pays Pays
        {
            get => SelectedJoueur.LePays;
            set
            {
                if (selectedJoueur.LePays != value)
                {
                    selectedJoueur.LePays = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }



        public DateTime DateNaissance
        {
            get => SelectedJoueur.DateNaissance;
            set
            {
                if (selectedJoueur.DateNaissance!= value)
                {
                    selectedJoueur.DateNaissance = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("Nom");
                }
            }
        }

        public Joueur SelectedJoueur
        {
            get => selectedJoueur;
            set
            {
                if (selectedJoueur != value)
                {
                    selectedJoueur = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("id");
                    OnPropertyChanged("nom");
                    OnPropertyChanged("dateEntree");
                    OnPropertyChanged("dateNaissance");
                    OnPropertyChanged("pays");
                    OnPropertyChanged("poste");
                    OnPropertyChanged("equipe");
                }
            }
        }

        public Equipe SelectedEquipe
        {
            get => selectedEquipe;
            set
            {
                if (selectedEquipe != value)
                {
                    selectedEquipe = value;
                    //création d'un évènement si la propriété Name (bindée dans le XAML) change
                    OnPropertyChanged("id");
                    OnPropertyChanged("nom");
                    OnPropertyChanged("Datecreation");
                }
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(() => UpdateJoueur(), () => true);
                }
                return this.updateCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if (this.DeleteCommand == null)
                {
                    this.DeleteCommand = new RelayCommand(() => DeleteJoueur(), () => true);
                }
                return this.DeleteCommand;
            }
        }  public ICommand AddCommand
        {
            get
            {
                if (this.ajouterCommand == null)
                {
                    this.ajouterCommand = new RelayCommand(() => AddJoueur(), () => true);
                }
                return this.ajouterCommand;
            }
        }
        private void UpdateJoueur()
        {
            Joueur backup = new Joueur();
            backup = SelectedJoueur;
            this.vmDaoJoueur.Update(this.SelectedJoueur,this.selectedEquipe);
            int a = listJoueur.IndexOf(SelectedJoueur);
            listJoueur.Insert(a, SelectedJoueur);
            listJoueur.RemoveAt(a + 1);
            SelectedJoueur = backup;
            MessageBox.Show("Mis à jour réussis");
        }
        private void AddJoueur()
        {
            Joueur select = new Joueur();
            this.vmDaoJoueur.Insert(this.SelectedJoueur);
            listJoueur.Add(this.SelectedJoueur);
            select = this.SelectedJoueur;
            SelectedJoueur = select;
            MessageBox.Show("Joueur ajouté");
        }
        private void DeleteJoueur()
        {
            Joueur backup = new Joueur();
            backup = SelectedJoueur;
            this.vmDaoJoueur.Delete(this.SelectedJoueur);
            int a = listJoueur.IndexOf(SelectedJoueur);
            listJoueur.RemoveAt(a);
            MessageBox.Show("Joueur supprimé");
        }
    }
}
