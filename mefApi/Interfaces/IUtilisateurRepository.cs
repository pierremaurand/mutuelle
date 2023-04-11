using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mefApi.Dtos;
using mefApi.Models;

namespace mefApi.Interfaces
{
    public interface IUtilisateurRepository
    {
        Task<Utilisateur?> Authenticate(string login);
        void Add(Utilisateur utilisateur);
        Task<bool> UtilisateurExists(string nomUtilisateur);
    }
}