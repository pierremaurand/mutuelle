import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AddAgenceComponent } from './agence/add-agence/add-agence.component';
import { AgenceDetailComponent } from './agence/agence-detail/agence-detail.component';
import { AgenceListComponent } from './agence/agence-list/agence-list.component';
import { AddAvanceComponent } from './avance/add-avance/add-avance.component';
import { AvanceDetailComponent } from './avance/avance-detail/avance-detail.component';
import { AvanceListComponent } from './avance/avance-list/avance-list.component';
import { AddCompteComponent } from './compte/add-compte/add-compte.component';
import { CompteListComponent } from './compte/compte-list/compte-list.component';
import { AddCotisationComponent } from './cotisation/add-cotisation/add-cotisation.component';
import { CotisationDetailComponent } from './cotisation/cotisation-detail/cotisation-detail.component';
import { CotisationListComponent } from './cotisation/cotisation-list/cotisation-list.component';
import { AddCreditComponent } from './credit/add-credit/add-credit.component';
import { CreditDetailComponent } from './credit/credit-detail/credit-detail.component';
import { CreditListComponent } from './credit/credit-list/credit-list.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { StatistiqueComponent } from './dashboard/statistique/statistique.component';
import { AddMembreComponent } from './membre/add-membre/add-membre.component';
import { MembreDetailComponent } from './membre/membre-detail/membre-detail.component';
import { MembreListComponent } from './membre/membre-list/membre-list.component';
import { ProfileComponent } from './membre/profile/profile.component';
import { AddParametreComponent } from './parametre/add-parametre/add-parametre.component';
import { ParametreDetailComponent } from './parametre/parametre-detail/parametre-detail.component';
import { ParametreListComponent } from './parametre/parametre-list/parametre-list.component';
import { AddPeriodeComponent } from './periode/add-periode/add-periode.component';
import { PeriodeListComponent } from './periode/periode-list/periode-list.component';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailResolverService } from './property/property-detail/property-detail-resolver.service';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { AddServiceComponent } from './service/add-service/add-service.component';
import { ServiceDetailComponent } from './service/service-detail/service-detail.component';
import { ServiceListComponent } from './service/service-list/service-list.component';
import { AddSexeComponent } from './sexe/add-sexe/add-sexe.component';
import { SexeDetailComponent } from './sexe/sexe-detail/sexe-detail.component';
import { SexeListComponent } from './sexe/sexe-list/sexe-list.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { AddUtilisateurComponent } from './utilisateur/add-utilisateur/add-utilisateur.component';
import { UtilisateurDetailComponent } from './utilisateur/utilisateur-detail/utilisateur-detail.component';
import { UtilisateurListComponent } from './utilisateur/utilisateur-list/utilisateur-list.component';

const routes: Routes = [
  {path:'', component: PropertyListComponent},
  {path:'dashboard', component: DashboardComponent},
  {path:'statistiques', component: StatistiqueComponent},

  {path:'membres', component: MembreListComponent},
  {path:'membre-detail/:id', component: MembreDetailComponent},
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
  {path:'**', component: PropertyListComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
