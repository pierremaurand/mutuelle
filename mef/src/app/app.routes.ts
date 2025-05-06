import { ParametresModule } from './ui/modules/parametres/parametres.module';
import { Routes } from '@angular/router';
import { AuthService } from './services/auth.service';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./ui/pages/main/main.component'),
    canActivate: [AuthService],
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        loadChildren: () =>
          import('./ui/modules/main/main.module').then((m) => m.MainModule),
      },
      {
        path: 'membres',
        loadChildren: () =>
          import('./ui/modules/membres/membres.module').then(
            (m) => m.MembresModule
          ),
      },
      {
        path: 'cotisations',
        loadChildren: () =>
          import('./ui/modules/cotisations/cotisations.module').then(
            (m) => m.CotisationsModule
          ),
      },
      {
        path: 'avances',
        loadChildren: () =>
          import('./ui/modules/avances/avances.module').then(
            (m) => m.AvancesModule
          ),
      },
      {
        path: 'credits',
        loadChildren: () =>
          import('./ui/modules/credits/credits.module').then(
            (m) => m.CreditsModule
          ),
      },
      {
        path: 'comptabilite',
        loadChildren: () =>
          import('./ui/modules/comptabilite/comptabilite.module').then(
            (m) => m.ComptabiliteModule
          ),
      },
      {
        path: 'parametres',
        loadChildren: () =>
          import('./ui/modules/parametres/parametres.module').then(
            (m) => m.ParametresModule
          ),
      },
    ],
  },
  {
    path: 'login',
    loadComponent: () => import('./ui/pages/login/login.component'),
  },
];
