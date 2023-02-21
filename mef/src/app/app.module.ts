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
import { AddUtilisateurComponent } from './utilisateur/add-utilisateur/add-utilisateur.component';
import { UtilisateurListComponent } from './utilisateur/utilisateur-list/utilisateur-list.component';
import { UtilisateurDetailComponent } from './utilisateur/utilisateur-detail/utilisateur-detail.component';
import { UtilisateurComponent } from './utilisateur/utilisateur/utilisateur.component';
import { PaginationComponent } from './composants/pagination/pagination.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { BoutonActionComponent } from './composants/bouton-action/bouton-action.component';
import { ConnexionComponent } from './connexion/connexion.component';
import { LoaderComponent } from './composants/loader/loader.component';
import { WidgetComponent } from './composants/widget/widget.component';
import { SearchBarComponent } from './composants/search-bar/search-bar.component';
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
import { PageLoginComponent } from './pages/page-login/page-login.component';
import { PageDashboardComponent } from './pages/page-dashboard/page-dashboard.component';
import { PageStatistiquesComponent } from './pages/page-statistiques/page-statistiques.component';
import { MenuComponent } from './composants/menu/menu.component';
import { HeaderComponent } from './composants/header/header.component';
import { PageMembreComponent } from './pages/membres/page-membre/page-membre.component';
import { DetailMembreComponent } from './pages/membres/detail-membre/detail-membre.component';
import { NouveauMembreComponent } from './pages/membres/nouveau-membre/nouveau-membre.component';
import { PageCompteComponent } from './pages/compte/page-compte/page-compte.component';
import { PageCotisationComponent } from './pages/cotisations/page-cotisation/page-cotisation.component';
import { PageAvanceComponent } from './pages/avances/page-avance/page-avance.component';
import { PageCreditComponent } from './pages/credits/page-credit/page-credit.component';
import { PageProfilComponent } from './pages/profil/page-profil/page-profil.component';
import { ChangerMotDePasseComponent } from './pages/profil/changer-mot-de-passe/changer-mot-de-passe.component';
import { PageUtilisateurComponent } from './pages/page-utilisateur/page-utilisateur.component';
import { PageGabaritComponent } from './pages/gabarit/page-gabarit/page-gabarit.component';
import { PageCompteComptableComponent } from './pages/compte-comptable/page-compte-comptable/page-compte-comptable.component';
import { PageSexeComponent } from './pages/sexe/page-sexe/page-sexe.component';
import { PagePosteComponent } from './pages/poste/page-poste/page-poste.component';
import { DetailUtilisateurComponent } from './composants/detail-utilisateur/detail-utilisateur.component';
import { ImageAddComponent } from './composants/image-add/image-add.component';
import { DetailSexeComponent } from './pages/sexe/detail-sexe/detail-sexe.component';
import { NouveauSexeComponent } from './pages/sexe/nouveau-sexe/nouveau-sexe.component';
import { NouveauPosteComponent } from './pages/poste/nouveau-poste/nouveau-poste.component';
import { DetailPosteComponent } from './pages/poste/detail-poste/detail-poste.component';
import { DetailCompteComptableComponent } from './pages/compte-comptable/detail-compte-comptable/detail-compte-comptable.component';
import { NouveauCompteComptableComponent } from './pages/compte-comptable/nouveau-compte-comptable/nouveau-compte-comptable.component';
import { NouveauGabaritComponent } from './pages/gabarit/nouveau-gabarit/nouveau-gabarit.component';
import { DetailGabaritComponent } from './pages/gabarit/detail-gabarit/detail-gabarit.component';
import { NouveauCompteComponent } from './pages/compte/nouveau-compte/nouveau-compte.component';
import { DetailCompteComponent } from './pages/compte/detail-compte/detail-compte.component';
import { InfosMembreComponent } from './composants/infos-membre/infos-membre.component';
import { PageLieuAffectationComponent } from './pages/affectation/page-lieu-affectation/page-lieu-affectation.component';
import { NouveauLieuAffectationComponent } from './pages/affectation/nouveau-lieu-affectation/nouveau-lieu-affectation.component';
import { DetailLieuAffectationComponent } from './pages/affectation/detail-lieu-affectation/detail-lieu-affectation.component';
import { ProfilMembreComponent } from './pages/membres/profil-membre/profil-membre.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe,
    DndDirective,
    AddUtilisateurComponent,
    UtilisateurListComponent,
    UtilisateurDetailComponent,
    UtilisateurComponent,
    PaginationComponent,
    BoutonActionComponent,
    ConnexionComponent,
    LoaderComponent,
    WidgetComponent,
    SearchBarComponent,
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
    PageLoginComponent,
    PageDashboardComponent,
    PageStatistiquesComponent,
    MenuComponent,
    HeaderComponent,
    PageMembreComponent,
    DetailMembreComponent,
    NouveauMembreComponent,
    PageCompteComponent,
    PageCotisationComponent,
    PageAvanceComponent,
    PageCreditComponent,
    PageProfilComponent,
    ChangerMotDePasseComponent,
    PageUtilisateurComponent,
    PageGabaritComponent,
    PageCompteComptableComponent,
    PageSexeComponent,
    PagePosteComponent,
    DetailUtilisateurComponent,
    ImageAddComponent,
    DetailSexeComponent,
    NouveauSexeComponent,
    NouveauPosteComponent,
    DetailPosteComponent,
    DetailCompteComptableComponent,
    NouveauCompteComptableComponent,
    NouveauGabaritComponent,
    DetailGabaritComponent,
    NouveauCompteComponent,
    DetailCompteComponent,
    InfosMembreComponent,
    PageLieuAffectationComponent,
    NouveauLieuAffectationComponent,
    DetailLieuAffectationComponent,
    ProfilMembreComponent,
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
})
export class AppModule {}
