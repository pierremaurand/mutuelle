import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'liste',
    pathMatch: 'full',
  },
  {
    path: 'liste',
    loadComponent: () =>
      import('../../pages/membres/liste-membres/liste-membres.component'),
  },
  {
    path: 'ajouter',
    loadComponent: () =>
      import('../../pages/membres/nouveau-membre/nouveau-membre.component'),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MembresRoutingModule {}
