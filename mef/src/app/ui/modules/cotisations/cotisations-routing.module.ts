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
          import(
            '../../pages/cotisations/main-cotisations/main-cotisations.component'
          ),
        children: [
          {
            path: '',
            loadComponent: () =>
              import(
                '../../pages/cotisations/dashboard-cotisations/dashboard-cotisations.component'
              ),
          },
          {
            path: 'liste',
            loadComponent: () =>
              import(
                '../../pages/cotisations/liste-cotisations/liste-cotisations.component'
              ),
          },
          {
            path: 'nouvelles',
            loadComponent: () =>
              import(
                '../../pages/cotisations/nouvelles-cotisations/nouvelles-cotisations.component'
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
export class CotisationsRoutingModule {}
