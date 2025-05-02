import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('../../pages/main/main.component'),
    children: [
      {
        path: '',
        loadComponent: () =>
          import('../../pages/membres/main-membres/main-membres.component'),
        children: [
          {
            path: '',
            loadComponent: () =>
              import(
                '../../pages/membres/dashboard-membres/dashboard-membres.component'
              ),
          },
          {
            path: 'liste',
            loadComponent: () =>
              import(
                '../../pages/membres/liste-membres/liste-membres.component'
              ),
          },
          {
            path: 'nouveau',
            loadComponent: () =>
              import(
                '../../pages/membres/nouveau-membre/nouveau-membre.component'
              ),
          },
        ],
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MembresRoutingModule {}
