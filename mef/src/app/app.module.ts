import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { FilterPipe } from './pipes/filter.pipe';
import { SortPipe } from './pipes/sort.pipe';
import { HttpErrorInterceptorService } from './services/httperror-interceptor.service';
import { DatePipe, DecimalPipe } from '@angular/common';
import { DndDirective } from './directives/dnd.directive';
import { PaginationComponent } from './composants/pagination/pagination.component';
import { ImageCropperModule } from 'ngx-image-cropper';
import { BoutonActionComponent } from './composants/bouton-action/bouton-action.component';
import { ConnexionComponent } from './connexion/connexion.component';
import { LoaderComponent } from './composants/loader/loader.component';
import { WidgetComponent } from './composants/widget/widget.component';
import { SearchBarComponent } from './composants/search-bar/search-bar.component';
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
import { PageLoginComponent } from './pages/utilisateur/page-login/page-login.component';
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
import { PageUtilisateurComponent } from './pages/utilisateur/page-utilisateur/page-utilisateur.component';
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
import { InfosMembreComponent } from './composants/infos-membre/infos-membre.component';
import { PageLieuAffectationComponent } from './pages/affectation/page-lieu-affectation/page-lieu-affectation.component';
import { NouveauLieuAffectationComponent } from './pages/affectation/nouveau-lieu-affectation/nouveau-lieu-affectation.component';
import { DetailLieuAffectationComponent } from './pages/affectation/detail-lieu-affectation/detail-lieu-affectation.component';
import { NouvelleCotisationComponent } from './pages/cotisations/nouvelle-cotisation/nouvelle-cotisation.component';
import { DetailCompteComponent } from './pages/compte/detail-compte/detail-compte.component';
import { DetailCotisationComponent } from './pages/cotisations/detail-cotisation/detail-cotisation.component';
import { DetailAvanceComponent } from './pages/avances/detail-avance/detail-avance.component';
import { NouvelleAvanceComponent } from './pages/avances/nouvelle-avance/nouvelle-avance.component';
import { NouveauCreditComponent } from './pages/credits/nouveau-credit/nouveau-credit.component';
import { DetailCreditComponent } from './pages/credits/detail-credit/detail-credit.component';
import { MenuLateralComponent } from './composants/menu-lateral/menu-lateral.component';
import { EnteteComponent } from './composants/entete/entete.component';
import { PiedPageComponent } from './composants/pied-page/pied-page.component';
import { VueEnsembleComponent } from './pages/accueil/vue-ensemble/vue-ensemble.component';
import { StatistiquesComponent } from './pages/accueil/statistiques/statistiques.component';
import { AccueilComponent } from './pages/accueil/accueil/accueil.component';
import { DetailsMembreComponent } from './composants/details-membre/details-membre.component';
import { NouvelUtilisateurComponent } from './pages/utilisateur/nouvel-utilisateur/nouvel-utilisateur.component';
import { PageProfileComponent } from './pages/utilisateur/page-profile/page-profile.component';
import { ListeChoixMembreComponent } from './composants/liste-choix-membre/liste-choix-membre.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    FilterPipe,
    SortPipe,
    DndDirective,
    PaginationComponent,
    BoutonActionComponent,
    ConnexionComponent,
    LoaderComponent,
    WidgetComponent,
    SearchBarComponent,
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
    MenuComponent,
    HeaderComponent,
    PageMembreComponent,
    DetailMembreComponent,
    NouveauMembreComponent,
    PageCompteComponent,
    PageCotisationComponent,
    DetailCotisationComponent,
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
    NouvelleCotisationComponent,
    DetailAvanceComponent,
    NouvelleAvanceComponent,
    NouveauCreditComponent,
    DetailCreditComponent,
    MenuLateralComponent,
    EnteteComponent,
    PiedPageComponent,
    AccueilComponent,
    VueEnsembleComponent,
    StatistiquesComponent,
    DetailsMembreComponent,
    NouvelUtilisateurComponent,
    PageProfileComponent,
    ListeChoixMembreComponent,
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
    ImageCropperModule,
  ],
})
export class AppModule {}
