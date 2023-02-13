import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ConnexionComponent } from './connexion/connexion.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { StatistiqueComponent } from './dashboard/statistique/statistique.component';
import { HomeComponent } from './home/home.component';
import { MembreListComponent } from './membre/membre-list/membre-list.component';
import { AddMembreComponent } from './membre/add-membre/add-membre.component';
import { SexePageComponent } from './sexe/sexe-page/sexe-page.component';
import { SexeListComponent } from './sexe/sexe-list/sexe-list.component';
import { AddSexeComponent } from './sexe/add-sexe/add-sexe.component';
import { UpdateSexeComponent } from './sexe/update-sexe/update-sexe.component';
import { SexeComponent } from './sexe/sexe/sexe.component';
import { PostePageComponent } from './poste/poste-page/poste-page.component';
import { PosteListComponent } from './poste/poste-list/poste-list.component';
import { AddPosteComponent } from './poste/add-poste/add-poste.component';
import { UpdatePosteComponent } from './poste/update-poste/update-poste.component';
import { PosteComponent } from './poste/poste/poste.component';
import { UpdateMembreComponent } from './membre/update-membre/update-membre.component';
import { MembreComponent } from './membre/membre/membre.component';
import { MembrePageComponent } from './membre/membre-page/membre-page.component';
import { AddImageComponent } from './membre/add-image/add-image.component';
import { CompteComptablePageComponent } from './compte-comptable/compte-comptable-page/compte-comptable-page.component';
import { CompteComptableListComponent } from './compte-comptable/compte-comptable-list/compte-comptable-list.component';
import { AddCompteComptableComponent } from './compte-comptable/add-compte-comptable/add-compte-comptable.component';
import { UpdateCompteComptableComponent } from './compte-comptable/update-compte-comptable/update-compte-comptable.component';
import { CompteComptableComponent } from './compte-comptable/compte-comptable/compte-comptable.component';
import { GabaritPageComponent } from './gabarit/gabarit-page/gabarit-page.component';
import { AddGabaritComponent } from './gabarit/add-gabarit/add-gabarit.component';
import { GabaritListComponent } from './gabarit/gabarit-list/gabarit-list.component';
import { GabaritComponent } from './gabarit/gabarit/gabarit.component';
import { UpdateGabaritComponent } from './gabarit/update-gabarit/update-gabarit.component';
import { ImportMembreComponent } from './membre/import-membre/import-membre.component';
import { SelectMembreComponent } from './membre/select-membre/select-membre.component';
import { CotisationPageComponent } from './cotisation/cotisation-page/cotisation-page.component';
import { AddCotisationComponent } from './cotisation/add-cotisation/add-cotisation.component';
import { CotisationListComponent } from './cotisation/cotisation-list/cotisation-list.component';
import { CotisationComponent } from './cotisation/cotisation/cotisation.component';
import { UpdateCotisationComponent } from './cotisation/update-cotisation/update-cotisation.component';
import { ImportCotisationComponent } from './cotisation/import-cotisation/import-cotisation.component';
import { AddAvanceComponent } from './avance/add-avance/add-avance.component';
import { AvanceListComponent } from './avance/avance-list/avance-list.component';
import { AvancePageComponent } from './avance/avance-page/avance-page.component';
import { ImportAvanceComponent } from './avance/import-avance/import-avance.component';
import { UpdateAvanceComponent } from './avance/update-avance/update-avance.component';
import { AvanceComponent } from './avance/avance/avance.component';
import { AddCreditComponent } from './credit/add-credit/add-credit.component';
import { CreditListComponent } from './credit/credit-list/credit-list.component';
import { CreditPageComponent } from './credit/credit-page/credit-page.component';
import { CreditComponent } from './credit/credit/credit.component';
import { ImportCreditComponent } from './credit/import-credit/import-credit.component';
import { UpdateCreditComponent } from './credit/update-credit/update-credit.component';
import { AddCompteComponent } from './compte/add-compte/add-compte.component';
import { CompteListComponent } from './compte/compte-list/compte-list.component';
import { ComptePageComponent } from './compte/compte-page/compte-page.component';
import { CompteComponent } from './compte/compte/compte.component';
import { ImportCompteComponent } from './compte/import-compte/import-compte.component';
import { UpdateCompteComponent } from './compte/update-compte/update-compte.component';
import { AddComptabiliteComponent } from './comptabilite/add-comptabilite/add-comptabilite.component';
import { ComptabiliteListComponent } from './comptabilite/comptabilite-list/comptabilite-list.component';
import { ComptabilitePageComponent } from './comptabilite/comptabilite-page/comptabilite-page.component';
import { ComptabiliteComponent } from './comptabilite/comptabilite/comptabilite.component';
import { ImportComptabiliteComponent } from './comptabilite/import-comptabilite/import-comptabilite.component';
import { UpdateComptabiliteComponent } from './comptabilite/update-comptabilite/update-comptabilite.component';
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { PageDashboardComponent } from './pages/page-dashboard/page-dashboard.component';
import { PageStatistiquesComponent } from './pages/page-statistiques/page-statistiques.component';
import { PageMembreComponent } from './pages/membres/page-membre/page-membre.component';
import { NouveauMembreComponent } from './pages/membres/nouveau-membre/nouveau-membre.component';
import { PageCompteComponent } from './pages/comptes/page-compte/page-compte.component';
import { PageAvanceComponent } from './pages/avances/page-avance/page-avance.component';
import { PageCreditComponent } from './pages/credits/page-credit/page-credit.component';
import { PageCotisationComponent } from './pages/cotisations/page-cotisation/page-cotisation.component';
import { PageProfilComponent } from './pages/profil/page-profil/page-profil.component';
import { ChangerMotDePasseComponent } from './pages/profil/changer-mot-de-passe/changer-mot-de-passe.component';
import { PageUtilisateurComponent } from './pages/page-utilisateur/page-utilisateur.component';
import { PageCompteComptableComponent } from './pages/page-compte-comptable/page-compte-comptable.component';
import { PageGabaritComponent } from './pages/page-gabarit/page-gabarit.component';
import { PageSexeComponent } from './pages/page-sexe/page-sexe.component';
import { PagePosteComponent } from './pages/page-poste/page-poste.component';

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
        path: 'comptes',
        component: PageCompteComponent,
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
        path: 'gabarits',
        component: PageGabaritComponent,
      },
      {
        path: 'sexes',
        component: PageSexeComponent,
      },
      {
        path: 'postes',
        component: PagePosteComponent,
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
