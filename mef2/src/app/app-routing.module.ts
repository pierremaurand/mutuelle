import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { PageDashboardComponent } from './pages/page-dashboard/page-dashboard.component';
import { PageStatistiquesComponent } from './pages/page-statistiques/page-statistiques.component';
import { PageMembreComponent } from './pages/membres/page-membre/page-membre.component';
import { NouveauMembreComponent } from './pages/membres/nouveau-membre/nouveau-membre.component';
import { PageCompteComponent } from './pages/compte/page-compte/page-compte.component';
import { PageAvanceComponent } from './pages/avances/page-avance/page-avance.component';
import { PageCreditComponent } from './pages/credits/page-credit/page-credit.component';
import { PageCotisationComponent } from './pages/cotisations/page-cotisation/page-cotisation.component';
import { PageProfilComponent } from './pages/profil/page-profil/page-profil.component';
import { ChangerMotDePasseComponent } from './pages/profil/changer-mot-de-passe/changer-mot-de-passe.component';
import { PageUtilisateurComponent } from './pages/page-utilisateur/page-utilisateur.component';
import { PageCompteComptableComponent } from './pages/compte-comptable/page-compte-comptable/page-compte-comptable.component';
import { PageGabaritComponent } from './pages/gabarit/page-gabarit/page-gabarit.component';
import { PageSexeComponent } from './pages/sexe/page-sexe/page-sexe.component';
import { PagePosteComponent } from './pages/poste/page-poste/page-poste.component';
import { NouveauSexeComponent } from './pages/sexe/nouveau-sexe/nouveau-sexe.component';
import { NouveauPosteComponent } from './pages/poste/nouveau-poste/nouveau-poste.component';
import { NouveauCompteComptableComponent } from './pages/compte-comptable/nouveau-compte-comptable/nouveau-compte-comptable.component';
import { NouveauGabaritComponent } from './pages/gabarit/nouveau-gabarit/nouveau-gabarit.component';
import { NouveauCompteComponent } from './pages/compte/nouveau-compte/nouveau-compte.component';
import { NouveauLieuAffectationComponent } from './pages/affectation/nouveau-lieu-affectation/nouveau-lieu-affectation.component';
import { PageLieuAffectationComponent } from './pages/affectation/page-lieu-affectation/page-lieu-affectation.component';
import { ProfilMembreComponent } from './pages/membres/profil-membre/profil-membre.component';
import { NouvelleCotisationComponent } from './pages/cotisations/nouvelle-cotisation/nouvelle-cotisation.component';
import { NouvelleAvanceComponent } from './pages/avances/nouvelle-avance/nouvelle-avance.component';
import { NouveauCreditComponent } from './pages/credits/nouveau-credit/nouveau-credit.component';
import { AuthService } from './services/auth.service';
import { AccueilComponent } from './pages/accueil/accueil/accueil.component';
import { DashboardComponent } from './pages/accueil/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: 'login',
    component: PageLoginComponent,
  },
  {
    path: '',
    component: AccueilComponent,
    canActivate: [AuthService],
    children: [
      {
        path: '',
        component: DashboardComponent,
        canActivate: [AuthService],
      },
      {
        path: 'membres',
        component: PageMembreComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaumembre',
        component: NouveauMembreComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaumembre/:id',
        component: NouveauMembreComponent,
        canActivate: [AuthService],
      },
      {
        path: 'detailmembre/:id',
        component: ProfilMembreComponent,
        canActivate: [AuthService],
      },
      {
        path: 'comptes',
        component: PageCompteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucompte',
        component: NouveauCompteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucompte/:id',
        component: NouveauCompteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'cotisations',
        component: PageCotisationComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouvellecotisation',
        component: NouvelleCotisationComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouvellecotisation/:id',
        component: NouvelleCotisationComponent,
        canActivate: [AuthService],
      },
      {
        path: 'avances',
        component: PageAvanceComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouvelleavance',
        component: NouvelleAvanceComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouvelleavance/:id',
        component: NouvelleAvanceComponent,
        canActivate: [AuthService],
      },
      {
        path: 'credits',
        component: PageCreditComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucredit',
        component: NouveauCreditComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucredit/:id',
        component: NouveauCreditComponent,
        canActivate: [AuthService],
      },
      {
        path: 'profil',
        component: PageProfilComponent,
        canActivate: [AuthService],
      },
      {
        path: 'changermotdepasse',
        component: ChangerMotDePasseComponent,
        canActivate: [AuthService],
      },
      {
        path: 'utilisateurs',
        component: PageUtilisateurComponent,
        canActivate: [AuthService],
      },
      {
        path: 'comptecomptables',
        component: PageCompteComptableComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucomptecomptable',
        component: NouveauCompteComptableComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaucomptecomptable/:id',
        component: NouveauCompteComptableComponent,
        canActivate: [AuthService],
      },
      {
        path: 'gabarits',
        component: PageGabaritComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaugabarit',
        component: NouveauGabaritComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaugabarit/:id',
        component: NouveauGabaritComponent,
        canActivate: [AuthService],
      },
      {
        path: 'sexes',
        component: PageSexeComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveausexe',
        component: NouveauSexeComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveausexe/:id',
        component: NouveauSexeComponent,
        canActivate: [AuthService],
      },
      {
        path: 'postes',
        component: PagePosteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveauposte',
        component: NouveauPosteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveauposte/:id',
        component: NouveauPosteComponent,
        canActivate: [AuthService],
      },
      {
        path: 'lieuaffectations',
        component: PageLieuAffectationComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaulieuaffectation',
        component: NouveauLieuAffectationComponent,
        canActivate: [AuthService],
      },
      {
        path: 'nouveaulieuaffectation/:id',
        component: NouveauLieuAffectationComponent,
        canActivate: [AuthService],
      },
    ],
  },
  {
    path: '**',
    component: PageLoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule, ReactiveFormsModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
