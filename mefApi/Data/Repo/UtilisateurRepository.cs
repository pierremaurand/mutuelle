using System.Security.Cryptography;
using mefApi.Dtos;
using mefApi.Interfaces;
using mefApi.Models;
using Microsoft.EntityFrameworkCore;

namespace mefApi.Data.Repo
{
    public class UtilisateurRepository : IUtilisateurRepository
    {
        public readonly DataContext dc;

        public UtilisateurRepository(DataContext dc)
        {
            this.dc = dc;
        }

        public async Task<Utilisateur?> Authenticate(string login)
        {
            if(dc.Utilisateurs is not null)
                return await dc.Utilisateurs.FirstOrDefaultAsync(u => u.NomUtilisateur == login);

            return null;
        }

        public void Add(Utilisateur utilisateur) 
        {
            if(dc.Utilisateurs is not null)
            {
                 dc.Utilisateurs.Add(utilisateur);
            }  
        }

        public async Task<bool> UtilisateurExists(string nomUtilisateur)
        {
            if(dc.Utilisateurs is not null)
                return await dc.Utilisateurs.AnyAsync(x => x.NomUtilisateur == nomUtilisateur);
            return false;
        }
    }
}