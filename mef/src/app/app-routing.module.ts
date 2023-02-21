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

const routes: Routes = [
  {
    path: 'login',
    component: PageLoginComponent,
  },
  {
    path: '',
    component: PageDashboardComponent,
    children: [
      {
        path: 'statistiques',
        component: PageStatistiquesComponent,
      },
      {
        path: 'membres',
        component: PageMembreComponent,
      },
      {
        path: 'nouveaumembre',
        component: NouveauMembreComponent,
      },
      {
        path: 'nouveaumembre/:id',
        component: NouveauMembreComponent,
      },
      {
        path: 'detailmembre/:id',
        component: ProfilMembreComponent,
      },
      {
        path: 'comptes',
        component: PageCompteComponent,
      },
      {
        path: 'nouveaucompte',
        component: NouveauCompteComponent,
      },
      {
        path: 'nouveaucompte/:id',
        component: NouveauCompteComponent,
      },
      {
        path: 'cotisations',
        component: PageCotisationComponent,
      },
      {
        path: 'avances',
        component: PageAvanceComponent,
      },
      {
        path: 'credits',
        component: PageCreditComponent,
      },
      {
        path: 'profil',
        component: PageProfilComponent,
      },
      {
        path: 'changermotdepasse',
        component: ChangerMotDePasseComponent,
      },
      {
        path: 'utilisateurs',
        component: PageUtilisateurComponent,
      },
      {
        path: 'comptecomptables',
        component: PageCompteComptableComponent,
      },
      {
        path: 'nouveaucomptecomptable',
        component: NouveauCompteComptableComponent,
      },
      {
        path: 'nouveaucomptecomptable/:id',
        component: NouveauCompteComptableComponent,
      },
      {
        path: 'gabarits',
        component: PageGabaritComponent,
      },
      {
        path: 'nouveaugabarit',
        component: NouveauGabaritComponent,
      },
      {
        path: 'nouveaugabarit/:id',
        component: NouveauGabaritComponent,
      },
      {
        path: 'sexes',
        component: PageSexeComponent,
      },
      {
        path: 'nouveausexe',
        component: NouveauSexeComponent,
      },
      {
        path: 'nouveausexe/:id',
        component: NouveauSexeComponent,
      },
      {
        path: 'postes',
        component: PagePosteComponent,
      },
      {
        path: 'nouveauposte',
        component: NouveauPosteComponent,
      },
      {
        path: 'nouveauposte/:id',
        component: NouveauPosteComponent,
      },
      {
        path: 'lieuaffectations',
        component: PageLieuAffectationComponent,
      },
      {
        path: 'nouveaulieuaffectation',
        component: NouveauLieuAffectationComponent,
      },
      {
        path: 'nouveaulieuaffectation/:id',
        component: NouveauLieuAffectationComponent,
      },
    ],
  },
  // { path: '', component: PageLoginComponent },
  // {
  //   path: 'home',
  //   component: HomeComponent,
  //   children: [
  //     { path: '', component: DashboardComponent },
  //     { path: 'statistiques', component: StatistiqueComponent },
  //     {
  //       path: 'membres',
  //       component: MembrePageComponent,
  //       children: [
  //         { path: '', component: MembreListComponent },
  //         { path: 'add', component: AddMembreComponent },
  //         { path: 'update/:id', component: UpdateMembreComponent },
  //         { path: 'show/:id', component: MembreComponent },
  //         { path: 'add-image/:id', component: AddImageComponent },
  //         { path: 'import', component: ImportMembreComponent },
  //       ],
  //     },
  //     {
  //       path: 'sexes',
  //       component: SexePageComponent,
  //       children: [
  //         { path: '', component: SexeListComponent },
  //         { path: 'add', component: AddSexeComponent },
  //         { path: 'update/:id', component: UpdateSexeComponent },
  //         { path: 'show/:id', component: SexeComponent },
  //       ],
  //     },
  //     {
  //       path: 'postes',
  //       component: PostePageComponent,
  //       children: [
  //         { path: '', component: PosteListComponent },
  //         { path: 'add', component: AddPosteComponent },
  //         { path: 'update/:id', component: UpdatePosteComponent },
  //         { path: 'show/:id', component: PosteComponent },
  //       ],
  //     },
  //     {
  //       path: 'plan-comptable',
  //       component: CompteComptablePageComponent,
  //       children: [
  //         { path: '', component: CompteComptableListComponent },
  //         { path: 'add', component: AddCompteComptableComponent },
  //         { path: 'update/:id', component: UpdateCompteComptableComponent },
  //         { path: 'show/:id', component: CompteComptableComponent },
  //       ],
  //     },
  //     {
  //       path: 'gabarits',
  //       component: GabaritPageComponent,
  //       children: [
  //         { path: '', component: GabaritListComponent },
  //         { path: 'add', component: AddGabaritComponent },
  //         { path: 'update/:id', component: UpdateGabaritComponent },
  //         { path: 'show/:id', component: GabaritComponent },
  //       ],
  //     },
  //     {
  //       path: 'cotisations',
  //       component: CotisationPageComponent,
  //       children: [
  //         { path: '', component: CotisationListComponent },
  //         { path: 'add', component: AddCotisationComponent },
  //         { path: 'update/:id', component: UpdateCotisationComponent },
  //         { path: 'show/:id', component: CotisationComponent },
  //         { path: 'import', component: ImportCotisationComponent },
  //       ],
  //     },
  //     {
  //       path: 'avances',
  //       component: AvancePageComponent,
  //       children: [
  //         { path: '', component: AvanceListComponent },
  //         { path: 'add', component: AddAvanceComponent },
  //         { path: 'update/:id', component: UpdateAvanceComponent },
  //         { path: 'show/:id', component: AvanceComponent },
  //         { path: 'import', component: ImportAvanceComponent },
  //       ],
  //     },
  //     {
  //       path: 'credits',
  //       component: CreditPageComponent,
  //       children: [
  //         { path: '', component: CreditListComponent },
  //         { path: 'add', component: AddCreditComponent },
  //         { path: 'update/:id', component: UpdateCreditComponent },
  //         { path: 'show/:id', component: CreditComponent },
  //         { path: 'import', component: ImportCreditComponent },
  //       ],
  //     },
  //     {
  //       path: 'comptes',
  //       component: ComptePageComponent,
  //       children: [
  //         { path: '', component: CompteListComponent },
  //         { path: 'add', component: AddCompteComponent },
  //         { path: 'update/:id', component: UpdateCompteComponent },
  //         { path: 'show/:id', component: CompteComponent },
  //         { path: 'import', component: ImportCompteComponent },
  //       ],
  //     },
  //     {
  //       path: 'comptabilite',
  //       component: ComptabilitePageComponent,
  //       children: [
  //         { path: '', component: ComptabiliteListComponent },
  //         { path: 'add', component: AddComptabiliteComponent },
  //         { path: 'update/:id', component: UpdateComptabiliteComponent },
  //         { path: 'show/:id', component: ComptabiliteComponent },
  //         { path: 'import', component: ImportComptabiliteComponent },
  //       ],
  //     },
  //   ],
  // },
  // { path: '**', component: PageLoginComponent },
  /*
  {path:'membre-page', component: MembrePageComponent,
  children: [
    {path:'', component: ProfileComponent},
    {path: 'infos-membre', component: ProfileComponent},
    {path: 'cotisations-membre', component: CotisationPageComponent},
    {path: 'avances-membre', component: AvancePageComponent},
    {path: 'credits-membre', component: CreditPageComponent}
  ]
  },
  {path:'add-membre/:id', component: AddMembreComponent,
    data: {
      origin: 'membre'
    }
  },
  {path:'update-membre-detail/:id', component: AddMembreComponent,
    data: {
      origin: 'detail'
    },
    children: [
      {
        path: 'profile-membre',
        component: ProfileComponent
      }
    ]
  },

  {path:'avances', component: AvanceListComponent},
  {path:'avance-detail/:id', component: AvanceDetailComponent},
  {path:'add-avance/:id', component: AddAvanceComponent},

  {path:'cotisations', component: CotisationListComponent},
  {path:'cotisation-detail/:id', component: CotisationDetailComponent},
  {path:'add-cotisation/:id', component: AddCotisationComponent},

  {path:'credits', component: CreditListComponent},
  {path:'credits-detail/:id', component: CreditDetailComponent},
  {path:'add-credits/:id', component: AddCreditComponent},

  {path:'utilisateurs', component: UtilisateurListComponent},
  {path:'utilisateur-detail/:id', component: UtilisateurDetailComponent},
  {path:'add-utilisateur/:id', component: AddUtilisateurComponent},

  {path:'sexes', component: SexeListComponent},
  {path:'sexe-detail/:id', component: SexeDetailComponent},
  {path:'add-sexe/:id', component: AddSexeComponent},

  {path:'agences', component: AgenceListComponent},
  {path:'agence-detail/:id', component: AgenceDetailComponent},
  {path:'add-agence/:id', component: AddAgenceComponent},

  {path:'services', component: ServiceListComponent},
  {path:'service-detail/:id', component: ServiceDetailComponent},
  {path:'add-service/:id', component: AddServiceComponent},

  {path:'parametres', component: ParametreListComponent},
  {path:'parametre-detail/:id', component: ParametreDetailComponent},
  {path:'add-parametre/:id', component: AddParametreComponent},

  {path:'comptes', component: CompteListComponent},
  {path:'add-compte/:id', component: AddCompteComponent},

  {path:'periodes', component: PeriodeListComponent},
  {path:'add-periode/:id', component: AddPeriodeComponent},


  {path:'rent-property', component: PropertyListComponent},
  {path:'add-property', component: AddPropertyComponent},
  {path:'property-detail/:id', component: PropertyDetailComponent, resolve: {prp: PropertyDetailResolverService}},
  {path:'user/login', component: UserLoginComponent},
  {path:'user/register', component: UserRegisterComponent},
  {path:'**', component: PropertyListComponent}*/
];

@NgModule({
  imports: [RouterModule.forRoot(routes), FormsModule, ReactiveFormsModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}
