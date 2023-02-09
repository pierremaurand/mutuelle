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
import { NgxPaginationModule } from 'ngx-pagination';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { FilterPipe } from './pipes/filter.pipe';
import { SortPipe } from './pipes/sort.pipe';
import { HttpErrorInterceptorService } from './services/httperror-interceptor.service';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { DatePipe, DecimalPipe } from '@angular/common';
import { DndDirective } from './directives/dnd.directive';
import { AddMembreComponent } from './membre/add-membre/add-membre.component';
import { MembreListComponent } from './membre/membre-list/membre-list.component';
import { AddUtilisateurComponent } from './utilisateur/add-utilisateur/add-utilisateur.component';
import { UtilisateurListComponent } from './utilisateur/utilisateur-list/utilisateur-list.component';
import { UtilisateurDetailComponent } from './utilisateur/utilisateur-detail/utilisateur-detail.component';
import { UtilisateurComponent } from './utilisateur/utilisateur/utilisateur.component';
import { MembreComponent } from './membre/membre/membre.component';
import { DashboardComponent } from './dashboard/dashboard/dashboard.component';
import { StatistiqueComponent } from './dashboard/statistique/statistique.component';
import { SexeComponent } from './sexe/sexe/sexe.component';
import { AddSexeComponent } from './sexe/add-sexe/add-sexe.component';
import { SexeListComponent } from './sexe/sexe-list/sexe-list.component';
import { PaginationComponent } from './composants/pagination/pagination.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { BoutonActionComponent } from './composants/bouton-action/bouton-action.component';
import { MembrePageComponent } from './membre/membre-page/membre-page.component';
import { HomeComponent } from './home/home.component';
import { ConnexionComponent } from './connexion/connexion.component';
import { LoaderComponent } from './composants/loader/loader.component';
import { WidgetComponent } from './composants/widget/widget.component';
import { SexePageComponent } from './sexe/sexe-page/sexe-page.component';
import { UpdateSexeComponent } from './sexe/update-sexe/update-sexe.component';
import { PosteComponent } from './poste/poste/poste.component';
import { AddPosteComponent } from './poste/add-poste/add-poste.component';
import { PosteListComponent } from './poste/poste-list/poste-list.component';
import { UpdatePosteComponent } from './poste/update-poste/update-poste.component';
import { PostePageComponent } from './poste/poste-page/poste-page.component';
import { UpdateMembreComponent } from './membre/update-membre/update-membre.component';
import { AddImageComponent } from './membre/add-image/add-image.component';
import { CompteComptableComponent } from './compte-comptable/compte-comptable/compte-comptable.component';
import { AddCompteComptableComponent } from './compte-comptable/add-compte-comptable/add-compte-comptable.component';
import { UpdateCompteComptableComponent } from './compte-comptable/update-compte-comptable/update-compte-comptable.component';
import { CompteComptableListComponent } from './compte-comptable/compte-comptable-list/compte-comptable-list.component';
import { CompteComptablePageComponent } from './compte-comptable/compte-comptable-page/compte-comptable-page.component';
import { GabaritComponent } from './gabarit/gabarit/gabarit.component';
import { AddGabaritComponent } from './gabarit/add-gabarit/add-gabarit.component';
import { UpdateGabaritComponent } from './gabarit/update-gabarit/update-gabarit.component';
import { GabaritListComponent } from './gabarit/gabarit-list/gabarit-list.component';
import { GabaritPageComponent } from './gabarit/gabarit-page/gabarit-page.component';
import { SearchBarComponent } from './composants/search-bar/search-bar.component';
import { ProfilMembreComponent } from './membre/profil-membre/profil-membre.component';
import { ImportMembreComponent } from './membre/import-membre/import-membre.component';
import { SelectMembreComponent } from './membre/select-membre/select-membre.component';
import { ProfilUserComponent } from './user/profil-user/profil-user.component';
import { CotisationPageComponent } from './cotisation/cotisation-page/cotisation-page.component';
import { CotisationComponent } from './cotisation/cotisation/cotisation.component';
import { AddCotisationComponent } from './cotisation/add-cotisation/add-cotisation.component';
import { UpdateCotisationComponent } from './cotisation/update-cotisation/update-cotisation.component';
import { CotisationListComponent } from './cotisation/cotisation-list/cotisation-list.component';
import { ImportCotisationComponent } from './cotisation/import-cotisation/import-cotisation.component';
import { AvancePageComponent } from './avance/avance-page/avance-page.component';
import { AvanceListComponent } from './avance/avance-list/avance-list.component';
import { AddAvanceComponent } from './avance/add-avance/add-avance.component';
import { UpdateAvanceComponent } from './avance/update-avance/update-avance.component';
import { ImportAvanceComponent } from './avance/import-avance/import-avance.component';
import { AvanceComponent } from './avance/avance/avance.component';
import { CreditComponent } from './credit/credit/credit.component';
import { AddCreditComponent } from './credit/add-credit/add-credit.component';
import { ImportCreditComponent } from './credit/import-credit/import-credit.component';
import { UpdateCreditComponent } from './credit/update-credit/update-credit.component';
import { CreditPageComponent } from './credit/credit-page/credit-page.component';
import { CreditListComponent } from './credit/credit-list/credit-list.component';
import { CompteComponent } from './compte/compte/compte.component';
import { AddCompteComponent } from './compte/add-compte/add-compte.component';
import { UpdateCompteComponent } from './compte/update-compte/update-compte.component';
import { ComptePageComponent } from './compte/compte-page/compte-page.component';
import { CompteListComponent } from './compte/compte-list/compte-list.component';
import { ImportCompteComponent } from './compte/import-compte/import-compte.component';
import { ComptabiliteComponent } from './comptabilite/comptabilite/comptabilite.component';
import { ComptabilitePageComponent } from './comptabilite/comptabilite-page/comptabilite-page.component';
import { ComptabiliteListComponent } from './comptabilite/comptabilite-list/comptabilite-list.component';
import { AddComptabiliteComponent } from './comptabilite/add-comptabilite/add-comptabilite.component';
import { UpdateComptabiliteComponent } from './comptabilite/update-comptabilite/update-comptabilite.component';
import { ImportComptabiliteComponent } from './comptabilite/import-comptabilite/import-comptabilite.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe,
    DndDirective,
    AddMembreComponent,
    MembreListComponent,
    AddUtilisateurComponent,
    UtilisateurListComponent,
    UtilisateurDetailComponent,
    UtilisateurComponent,
    MembreComponent,
    DashboardComponent,
    StatistiqueComponent,
    SexeComponent,
    AddSexeComponent,
    SexeListComponent,
    PaginationComponent,
    BoutonActionComponent,
    MembrePageComponent,
    HomeComponent,
    ConnexionComponent,
    LoaderComponent,
    WidgetComponent,
    SexePageComponent,
    UpdateSexeComponent,
    PosteComponent,
    AddPosteComponent,
    PosteListComponent,
    UpdatePosteComponent,
    PostePageComponent,
    UpdateMembreComponent,
    AddImageComponent,
    CompteComptableComponent,
    AddCompteComptableComponent,
    UpdateCompteComptableComponent,
    CompteComptableListComponent,
    CompteComptablePageComponent,
    GabaritComponent,
    AddGabaritComponent,
    UpdateGabaritComponent,
    GabaritListComponent,
    GabaritPageComponent,
    SearchBarComponent,
    ProfilMembreComponent,
    ImportMembreComponent,
    SelectMembreComponent,
    ProfilUserComponent,
    CotisationPageComponent,
    CotisationComponent,
    AddCotisationComponent,
    UpdateCotisationComponent,
    CotisationListComponent,
    ImportCotisationComponent,
    AvancePageComponent,
    AvanceListComponent,
    AddAvanceComponent,
    UpdateAvanceComponent,
    ImportAvanceComponent,
    AvanceComponent,
    CreditComponent,
    AddCreditComponent,
    ImportCreditComponent,
    UpdateCreditComponent,
    CreditPageComponent,
    CreditListComponent,
    CompteComponent,
    AddCompteComponent,
    UpdateCompteComponent,
    ComptePageComponent,
    CompteListComponent,
    ImportCompteComponent,
    ComptabiliteComponent,
    ComptabilitePageComponent,
    ComptabiliteListComponent,
    AddComptabiliteComponent,
    UpdateComptabiliteComponent,
    ImportComptabiliteComponent,
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
    NgxGalleryModule,
    ImageCropperModule,
    NgxPaginationModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi: true,
    },
    AlertifyService,
    AuthService,
    DatePipe,
    DecimalPipe,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
