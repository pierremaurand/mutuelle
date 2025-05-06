import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'utilisateurs',
    pathMatch: 'full',
  },
  {
    path: 'utilisateurs',
    loadComponent: () =>
      import(
        '../../pages/parametres/liste-utilisateurs/liste-utilisateurs.component'
      ),
  },
  {
    path: 'ajouter-utilisateur',
    loadComponent: () =>
      import(
        '../../pages/parametres/ajouter-utilisateur/ajouter-utilisateur.component'
      ),
  },
  {
    path: 'affectations',
    loadComponent: () =>
      import(
        '../../pages/parametres/liste-affectations/liste-affectations.component'
      ),
  },
  {
    path: 'ajouter-affectation',
    loadComponent: () =>
      import(
        '../../pages/parametres/ajouter-affectation/ajouter-affectation.component'
      ),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ParametresRoutingModule {}
