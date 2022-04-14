import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PropertyCardComponent } from './property/property-card/property-card.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { PropertyDetailResolverService } from './property/property-detail/property-detail-resolver.service';
import { FilterPipe } from './pipes/filter.pipe';
import { SortPipe } from './pipes/sort.pipe';
import { HttpErrorInterceptorService } from './services/httperror-interceptor.service';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { DatePipe } from '@angular/common';
import { DndDirective } from './directives/dnd.directive';
import { AddMembreComponent } from './membre/add-membre/add-membre.component';
import { MembreListComponent } from './membre/membre-list/membre-list.component';
import { MembreDetailComponent } from './membre/membre-detail/membre-detail.component';
import { AddCotisationComponent } from './cotisation/add-cotisation/add-cotisation.component';
import { CotisationListComponent } from './cotisation/cotisation-list/cotisation-list.component';
import { CotisationDetailComponent } from './cotisation/cotisation-detail/cotisation-detail.component';
import { AddAvanceComponent } from './avance/add-avance/add-avance.component';
import { AvanceListComponent } from './avance/avance-list/avance-list.component';
import { AvanceDetailComponent } from './avance/avance-detail/avance-detail.component';
import { AddCreditComponent } from './credit/add-credit/add-credit.component';
import { CreditListComponent } from './credit/credit-list/credit-list.component';
import { CreditDetailComponent } from './credit/credit-detail/credit-detail.component';
import { AddUtilisateurComponent } from './utilisateur/add-utilisateur/add-utilisateur.component';
import { UtilisateurListComponent } from './utilisateur/utilisateur-list/utilisateur-list.component';
import { UtilisateurDetailComponent } from './utilisateur/utilisateur-detail/utilisateur-detail.component';
import { UtilisateurComponent } from './utilisateur/utilisateur/utilisateur.component';
import { CreditComponent } from './credit/credit/credit.component';
import { AvanceComponent } from './avance/avance/avance.component';
import { CotisationComponent } from './cotisation/cotisation/cotisation.component';
import { MembreComponent } from './membre/membre/membre.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { StatistiqueComponent } from './dashboard/statistique/statistique.component';
import { SexeComponent } from './sexe/sexe/sexe.component';
import { AddSexeComponent } from './sexe/add-sexe/add-sexe.component';
import { SexeDetailComponent } from './sexe/sexe-detail/sexe-detail.component';
import { SexeListComponent } from './sexe/sexe-list/sexe-list.component';
import { AddAgenceComponent } from './agence/add-agence/add-agence.component';
import { AgenceComponent } from './agence/agence/agence.component';
import { AgenceDetailComponent } from './agence/agence-detail/agence-detail.component';
import { AgenceListComponent } from './agence/agence-list/agence-list.component';
import { AddServiceComponent } from './service/add-service/add-service.component';
import { ServiceComponent } from './service/service/service.component';
import { ServiceDetailComponent } from './service/service-detail/service-detail.component';
import { ServiceListComponent } from './service/service-list/service-list.component';
import { ParametreComponent } from './parametre/parametre/parametre.component';
import { ParametreDetailComponent } from './parametre/parametre-detail/parametre-detail.component';
import { ParametreListComponent } from './parametre/parametre-list/parametre-list.component';
import { AddParametreComponent } from './parametre/add-parametre/add-parametre.component';
import { CompteComponent } from './compte/compte/compte.component';
import { AddCompteComponent } from './compte/add-compte/add-compte.component';
import { CompteListComponent } from './compte/compte-list/compte-list.component';
import { AdhesionComponent } from './adhesion/adhesion/adhesion.component';
import { AdhesionListComponent } from './adhesion/adhesion-list/adhesion-list.component';
import { AddAdhesionComponent } from './adhesion/add-adhesion/add-adhesion.component';

@NgModule({
  declarations: [
    AppComponent,
    PropertyCardComponent,
    PropertyListComponent,
    NavBarComponent,
    AddPropertyComponent,
    PropertyDetailComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe,
    DndDirective,
    AddMembreComponent,
    MembreListComponent,
    MembreDetailComponent,
    AddCotisationComponent,
    CotisationListComponent,
    CotisationDetailComponent,
    AddAvanceComponent,
    AvanceListComponent,
    AvanceDetailComponent,
    AddCreditComponent,
    CreditListComponent,
    CreditDetailComponent,
    AddUtilisateurComponent,
    UtilisateurListComponent,
    UtilisateurDetailComponent,
    UtilisateurComponent,
    CreditComponent,
    AvanceComponent,
    CotisationComponent,
    MembreComponent,
    DashboardComponent,
    StatistiqueComponent,
    SexeComponent,
    AddSexeComponent,
    SexeDetailComponent,
    SexeListComponent,
    AddAgenceComponent,
    AgenceComponent,
    AgenceDetailComponent,
    AgenceListComponent,
    AddServiceComponent,
    ServiceComponent,
    ServiceDetailComponent,
    ServiceListComponent,
    ParametreComponent,
    ParametreDetailComponent,
    ParametreListComponent,
    AddParametreComponent,
    CompteComponent,
    AddCompteComponent,
    CompteListComponent,
    AdhesionComponent,
    AdhesionListComponent,
    AddAdhesionComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgxGalleryModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true
    },
    HousingService,
    AlertifyService,
    AuthService,
    PropertyDetailResolverService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
