import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { AvanceDetailComponent } from './avance/avance-detail/avance-detail.component';
import { AvanceListComponent } from './avance/avance-list/avance-list.component';
import { CotisationDetailComponent } from './cotisation/cotisation-detail/cotisation-detail.component';
import { CotisationListComponent } from './cotisation/cotisation-list/cotisation-list.component';
import { CreditDetailComponent } from './credit/credit-detail/credit-detail.component';
import { CreditListComponent } from './credit/credit-list/credit-list.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { StatistiqueComponent } from './dashboard/statistique/statistique.component';
import { MembreDetailComponent } from './membre/membre-detail/membre-detail.component';
import { MembreListComponent } from './membre/membre-list/membre-list.component';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailResolverService } from './property/property-detail/property-detail-resolver.service';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UtilisateurDetailComponent } from './utilisateur/utilisateur-detail/utilisateur-detail.component';
import { UtilisateurListComponent } from './utilisateur/utilisateur-list/utilisateur-list.component';

const routes: Routes = [
  {path:'', component: PropertyListComponent},
  {path:'dashboard', component: DashboardComponent},
  {path:'statistiques', component: StatistiqueComponent},
  {path:'membres', component: MembreListComponent},
  {path:'membre-detail/:id', component: MembreDetailComponent},
  {path:'avances', component: AvanceListComponent},
  {path:'avance-detail/:id', component: AvanceDetailComponent},
  {path:'cotisations', component: CotisationListComponent},
  {path:'cotisation-detail/:id', component: CotisationDetailComponent},
  {path:'credits', component: CreditListComponent},
  {path:'credits-detail/:id', component: CreditDetailComponent},
  {path:'utilisateurs', component: UtilisateurListComponent},
  {path:'utilisateur-detail/:id', component: UtilisateurDetailComponent},
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
